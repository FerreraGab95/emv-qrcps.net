using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace emv_qrcps.QrCode.Merchant
{
    public static class MerchantParser
    {
        private static TLV[] buildTags(string value)
        {
            List<TLV> accumulator = new List<TLV>();

            string currentTagLength = string.Empty;
            string currentTagId = string.Empty;
            string currentTagValue = string.Empty;

            foreach (string currentCharacter in value.ToCharArray().Select(x => x.ToString()))
            {
               
                if (string.IsNullOrEmpty(currentTagId))
                {
                    currentTagId = currentCharacter;
                }
                else if (currentTagId.Length < 2)
                {
                    currentTagId += currentCharacter;
                }
                else if (string.IsNullOrEmpty(currentTagLength))
                {
                    currentTagLength = currentCharacter;
                }
                else if (currentTagLength.Length < 2)
                {
                    currentTagLength += currentCharacter;
                }
                else if (string.IsNullOrEmpty(currentTagValue))
                {
                    currentTagValue = currentCharacter;
                }
                else if (currentTagValue.Length < int.Parse(currentTagLength))
                {
                    currentTagValue += currentCharacter;
                }

                if (currentTagId.Length == 2 && currentTagLength.Length == 2 &&
                   currentTagValue.Length == int.Parse(currentTagLength))
                {
                    accumulator.Add(new TLV(currentTagId, int.Parse(currentTagLength), currentTagValue));

                    currentTagLength = string.Empty;
                    currentTagId = string.Empty;
                    currentTagValue = string.Empty;
                }
            }

            return accumulator.ToArray();
        }


        private static AdditionalDataFieldTemplate parseAdditionalDataFieldTemplate(TLV[] tags)
        {
            var additionalDataFieldTemplate = new AdditionalDataFieldTemplate();

            foreach (var tag in tags)
            {
                switch (tag.tag)
                {
                    case MerchantConsts.ADDITIONAL_FIELD.AdditionalIDBillNumber:
                        additionalDataFieldTemplate.SetBillNumber(tag.value);
                        break;
                    case MerchantConsts.ADDITIONAL_FIELD.AdditionalIDMobileNumber:
                        additionalDataFieldTemplate.SetMobileNumber(tag.value);
                        break;
                    case MerchantConsts.ADDITIONAL_FIELD.AdditionalIDStoreLabel:
                        additionalDataFieldTemplate.SetStoreLabel(tag.value);
                        break;
                    case MerchantConsts.ADDITIONAL_FIELD.AdditionalIDLoyaltyNumber:
                        additionalDataFieldTemplate.SetLoyaltyNumber(tag.value);
                        break;
                    case MerchantConsts.ADDITIONAL_FIELD.AdditionalIDReferenceLabel:
                        additionalDataFieldTemplate.SetReferenceLabel(tag.value);
                        break;
                    case MerchantConsts.ADDITIONAL_FIELD.AdditionalIDCustomerLabel:
                        additionalDataFieldTemplate.SetCustomerLabel(tag.value);
                        break;
                    case MerchantConsts.ADDITIONAL_FIELD.AdditionalIDTerminalLabel:
                        additionalDataFieldTemplate.SetTerminalLabel(tag.value);
                        break;
                    case MerchantConsts.ADDITIONAL_FIELD.AdditionalIDPurposeTransaction:
                        additionalDataFieldTemplate.SetPurposeTransaction(tag.value);
                        break;
                    case MerchantConsts.ADDITIONAL_FIELD.AdditionalIDAdditionalConsumerDataRequest:
                        additionalDataFieldTemplate.SetAdditionalConsumerDataRequest(tag.value);
                        break;
                    default:
                        if (tag.tag.CompareTo(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDPaymentSystemSpecificTemplatesRangeStart) >= 0 && tag.tag.CompareTo(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDPaymentSystemSpecificTemplatesRangeEnd) <= 0)
                        {
                            TLV[] paymentSystemSpecificTags = buildTags(tag.value);

                            var t = parseMerchantAccountInformation(paymentSystemSpecificTags);
                            additionalDataFieldTemplate.AddPaymentSystemSpecific(tag.tag, t);
                        }
                        else if (tag.tag.CompareTo(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDRFUforEMVCoRangeStart) >= 0 && tag.tag.CompareTo(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDRFUforEMVCoRangeEnd) <= 0)
                        {
                            additionalDataFieldTemplate.AddRFUforEMVCo(tag.tag, tag.value);
                        }
                        break;
                }
            }

            return additionalDataFieldTemplate;
        }



        private static MerchantInformationLanguageTemplate parseMerchantInformationLanguageTemplate(TLV[] tags)
        {
            var merchantInformationLanguageTemplate = new MerchantInformationLanguageTemplate();

            foreach (var tag in tags)
            {
                switch (tag.tag)
                {
                    case MerchantConsts.MERCHANT_INFORMATION.MerchantInformationIDLanguagePreference:
                        merchantInformationLanguageTemplate.SetLanguagePreference(tag.value);
                        break;
                    case MerchantConsts.MERCHANT_INFORMATION.MerchantInformationIDMerchantName:
                        merchantInformationLanguageTemplate.SetMerchantName(tag.value);
                        break;
                    case MerchantConsts.MERCHANT_INFORMATION.MerchantInformationIDMerchantCity:
                        merchantInformationLanguageTemplate.SetMerchantCity(tag.value);
                        break;
                    default:
                        if (tag.tag.CompareTo(MerchantConsts.MERCHANT_INFORMATION.MerchantInformationIDRFUforEMVCoRangeStart) >= 0 && tag.tag.CompareTo(MerchantConsts.MERCHANT_INFORMATION.MerchantInformationIDRFUforEMVCoRangeEnd) <= 0)
                        {
                            merchantInformationLanguageTemplate.AddRFUforEMVCo(tag.tag, tag.value);
                        }
                        break;
                }
            }

            return merchantInformationLanguageTemplate;
        }


        private static MerchantAccountInformation parseMerchantAccountInformation(TLV[] tags)
        {
            var merchantAccountInformation = new MerchantAccountInformation();

            foreach (var tag in tags)
            {
                switch (tag.tag)
                {
                    case MerchantConsts.MERCHANT_ACCOUNT_INFORMATION.MerchantAccountInformationIDGloballyUniqueIdentifier:
                        merchantAccountInformation.SetGloballyUniqueIdentifier(tag.value);
                        break;
                    default:
                        if (tag.tag.CompareTo(MerchantConsts.MERCHANT_ACCOUNT_INFORMATION.MerchantAccountInformationIDPaymentNetworkSpecificStart) >= 0 && tag.tag.CompareTo(MerchantConsts.MERCHANT_ACCOUNT_INFORMATION.MerchantAccountInformationIDPaymentNetworkSpecificEnd) <= 0)
                        {
                            merchantAccountInformation.AddContextSpecificData(tag.tag, tag.value);
                        }
                        break;
                }
            }

            return merchantAccountInformation;
        }


        private static UnreservedTemplate parseUnreservedTemplate(TLV[] tags)
        {
            var unreservedTemplate = new UnreservedTemplate(null, new Template[] { });

            foreach (var tag in tags)
            {
                switch (tag.tag)
                {
                    case MerchantConsts.UNRESERVED_TEMPLATE.UnreservedTemplateIDGloballyUniqueIdentifier:
                        unreservedTemplate.SetGloballyUniqueIdentifier(tag.value);
                        break;
                    default:
                        if (tag.tag.CompareTo(MerchantConsts.UNRESERVED_TEMPLATE.UnreservedTemplateIDContextSpecificDataStart) >= 0 && tag.tag.CompareTo(MerchantConsts.UNRESERVED_TEMPLATE.UnreservedTemplateIDContextSpecificDataEnd) <= 0)
                        {
                            unreservedTemplate.AddContextSpecificData(tag.tag, tag.value);
                        }
                        break;
                }
            }

            return unreservedTemplate;
        }


        public static EMVQR ToEMVQR(string qrcodeValue)
        {
            var emvqr = new EMVQR();

            TLV[] tags = buildTags(qrcodeValue);

            foreach (var tag in tags) {
                switch (tag.tag)
                {
                    case MerchantConsts.ID.IDPayloadFormatIndicator:
                        emvqr.SetPayloadFormatIndicator(tag.value);
                        break;
                    case MerchantConsts.ID.IDPointOfInitiationMethod:
                        emvqr.SetPointOfInitiationMethod(tag.value);
                        break;
                    case MerchantConsts.ID.IDMerchantCategoryCode:
                        emvqr.SetMerchantCategoryCode(tag.value);
                        break;
                    case MerchantConsts.ID.IDTransactionCurrency:
                        emvqr.SetTransactionCurrency(tag.value);
                        break;
                    case MerchantConsts.ID.IDTransactionAmount:
                        emvqr.SetTransactionAmount(tag.value);
                        break;
                    case MerchantConsts.ID.IDTipOrConvenienceIndicator:
                        emvqr.SetTipOrConvenienceIndicator(tag.value);
                        break;
                    case MerchantConsts.ID.IDValueOfConvenienceFeeFixed:
                        emvqr.SetValueOfConvenienceFeeFixed(tag.value);
                        break;
                    case MerchantConsts.ID.IDValueOfConvenienceFeePercentage:
                        emvqr.SetValueOfConvenienceFeePercentage(tag.value);
                        break;
                    case MerchantConsts.ID.IDCountryCode:
                        emvqr.SetCountryCode(tag.value);
                        break;
                    case MerchantConsts.ID.IDMerchantName:
                        emvqr.SetMerchantName(tag.value);
                        break;
                    case MerchantConsts.ID.IDMerchantCity:
                        emvqr.SetMerchantCity(tag.value);
                        break;
                    case MerchantConsts.ID.IDPostalCode:
                        emvqr.SetPostalCode(tag.value);
                        break;
                    case MerchantConsts.ID.IDAdditionalDataFieldTemplate:
                        var additionalDataFieldTemplateTags = buildTags(tag.value);
                        var adft = parseAdditionalDataFieldTemplate(additionalDataFieldTemplateTags);
                        emvqr.SetAdditionalDataFieldTemplate(adft);
                        break;
                    case MerchantConsts.ID.IDCRC:
                        emvqr.SetCRC(tag.value);
                        break;
                    case MerchantConsts.ID.IDMerchantInformationLanguageTemplate:
                        var merchantInformarionLanguageTemplateTags = buildTags(tag.value);
                        var t = parseMerchantInformationLanguageTemplate(merchantInformarionLanguageTemplateTags);
                        emvqr.SetMerchantInformationLanguageTemplate(t);
                        break;
                    default:
                        if (tag.tag.CompareTo(MerchantConsts.ID.IDMerchantAccountInformationRangeStart) >= 0 && tag.tag.CompareTo(MerchantConsts.ID.IDMerchantAccountInformationRangeEnd) <= 0)
                        {
                            var merchantAccountInformationTags = buildTags(tag.value);
                            var merchantInfo = parseMerchantAccountInformation(merchantAccountInformationTags);
                            emvqr.AddMerchantAccountInformation(tag.tag, merchantInfo);
                        }
                        else if (tag.tag.CompareTo(MerchantConsts.ID.IDRFUForEMVCoRangeStart) >= 0 && tag.tag.CompareTo(MerchantConsts.ID.IDRFUForEMVCoRangeEnd) <= 0)
                        {
                            emvqr.AddRFUforEMVCo(tag.tag, tag.value);
                        }
                        else if (tag.tag.CompareTo(MerchantConsts.ID.IDUnreservedTemplatesRangeStart) >= 0 && tag.tag.CompareTo(MerchantConsts.ID.IDUnreservedTemplatesRangeEnd) <= 0)
                        {
                            var unreservedTemplateTags = buildTags(tag.value);
                            var unreservedTemp = parseUnreservedTemplate(unreservedTemplateTags);
                            emvqr.AddUnreservedTemplates(tag.tag, unreservedTemp);
                        }
                        break;
                }
            }
            return emvqr;
        }
    }
}
