using System;
using System.Collections.Generic;
using System.Linq;

namespace emv_qrcps.QrCode.Merchant
{
    public class EMVQR : Template
    {
        private TLV payloadFormatIndicator;
        private TLV pointOfInitiationMethod;
        private Dictionary<string, Template> merchantAccountInformation;
        private TLV merchantCategoryCode;
        private TLV transactionCurrency;
        private TLV transactionAmount;
        private TLV tipOrConvenienceIndicator;
        private TLV valueOfConvenienceFeeFixed;
        private TLV valueOfConvenienceFeePercentage;
        private TLV countryCode;
        private TLV merchantName;
        private TLV merchantCity;
        private TLV postalCode;
        private AdditionalDataFieldTemplate additionalDataFieldTemplate;
        private TLV crc;
        private MerchantInformationLanguageTemplate merchantInformationLanguageTemplate;
        private Template[] rfuForEMVCo;
        private Dictionary<string, Template> unreservedTemplates;


        public EMVQR()
        {
            payloadFormatIndicator = new TLV(MerchantConsts.ID.IDPayloadFormatIndicator, string.Empty.Length, string.Empty);
            pointOfInitiationMethod = new TLV(MerchantConsts.ID.IDPointOfInitiationMethod, string.Empty.Length, string.Empty);
            merchantAccountInformation = new Dictionary<string, Template>();
            merchantCategoryCode = new TLV(MerchantConsts.ID.IDMerchantCategoryCode, string.Empty.Length, string.Empty);
            transactionCurrency = new TLV(MerchantConsts.ID.IDTransactionCurrency, string.Empty.Length, string.Empty);
            transactionAmount = new TLV(MerchantConsts.ID.IDTransactionAmount, string.Empty.Length, string.Empty);
            tipOrConvenienceIndicator = new TLV(MerchantConsts.ID.IDTipOrConvenienceIndicator, string.Empty.Length, string.Empty);
            valueOfConvenienceFeeFixed = new TLV(MerchantConsts.ID.IDValueOfConvenienceFeeFixed, string.Empty.Length, string.Empty);
            valueOfConvenienceFeePercentage = new TLV(MerchantConsts.ID.IDValueOfConvenienceFeePercentage, string.Empty.Length, string.Empty);
            countryCode = new TLV(MerchantConsts.ID.IDCountryCode, string.Empty.Length, string.Empty);
            merchantName = new TLV(MerchantConsts.ID.IDMerchantName, string.Empty.Length, string.Empty);
            merchantCity = new TLV(MerchantConsts.ID.IDMerchantCity, string.Empty.Length, string.Empty);
            postalCode = new TLV(MerchantConsts.ID.IDPostalCode, string.Empty.Length, string.Empty);
            additionalDataFieldTemplate = new AdditionalDataFieldTemplate();
            crc = new TLV(MerchantConsts.ID.IDCRC, string.Empty.Length, string.Empty);
            merchantInformationLanguageTemplate = new MerchantInformationLanguageTemplate();
            rfuForEMVCo = new Template[] { };
            unreservedTemplates = new Dictionary<string, Template>();
        }


        public EMVQR(TLV payloadFormatIndicator, TLV pointOfInitiationMethod, Dictionary<string, Template> merchantAccountInformation, 
            TLV merchantCategoryCode, TLV transactionCurrency, TLV transactionAmount, TLV tipOrConvenienceIndicator, 
            TLV valueOfConvenienceFeeFixed, TLV valueOfConvenienceFeePercentage, TLV countryCode, TLV merchantName, 
            TLV merchantCity, TLV postalCode, AdditionalDataFieldTemplate additionalDataFieldTemplate, TLV crc,
            MerchantInformationLanguageTemplate merchantInformationLanguageTemplate, Template[] rfuForEMVCo, 
            Dictionary<string, Template> unreservedTemplates)
        {
            this.payloadFormatIndicator = payloadFormatIndicator;
            this.pointOfInitiationMethod = pointOfInitiationMethod;
            this.merchantAccountInformation = merchantAccountInformation;
            this.merchantCategoryCode = merchantCategoryCode;
            this.transactionCurrency = transactionCurrency;
            this.transactionAmount = transactionAmount;
            this.tipOrConvenienceIndicator = tipOrConvenienceIndicator;
            this.valueOfConvenienceFeeFixed = valueOfConvenienceFeeFixed;
            this.valueOfConvenienceFeePercentage = valueOfConvenienceFeePercentage;
            this.countryCode = countryCode;
            this.merchantName = merchantName;
            this.merchantCity = merchantCity;
            this.postalCode = postalCode;
            this.additionalDataFieldTemplate = additionalDataFieldTemplate;
            this.crc = crc;
            this.merchantInformationLanguageTemplate = merchantInformationLanguageTemplate;
            this.rfuForEMVCo = rfuForEMVCo;
            this.unreservedTemplates = unreservedTemplates;
        }


        public override string DataWithType(string dataType, string indent = "")
        {
            string str = string.Empty;
            str += payloadFormatIndicator.DataWithType(dataType, indent);
            str += pointOfInitiationMethod.DataWithType(dataType, indent);

            foreach (KeyValuePair<string, Template> kv in merchantAccountInformation) 
            {
                str += kv.Value.DataWithType(dataType, " ");
            }

            str += merchantCategoryCode.DataWithType(dataType, indent);
            str += transactionCurrency.DataWithType(dataType, indent);
            str += transactionAmount.DataWithType(dataType, indent);
            str += tipOrConvenienceIndicator.DataWithType(dataType, indent);
            str += valueOfConvenienceFeeFixed.DataWithType(dataType, indent);
            str += valueOfConvenienceFeePercentage.DataWithType(dataType, indent);
            str += countryCode.DataWithType(dataType, indent);
            str += merchantName.DataWithType(dataType, indent);
            str += merchantCity.DataWithType(dataType, indent);
            str += postalCode.DataWithType(dataType, indent);
            str += additionalDataFieldTemplate.DataWithType(dataType, " ");
            str += merchantInformationLanguageTemplate.DataWithType(dataType, " ");
            
            foreach(var r in rfuForEMVCo)
            {
                str += r.DataWithType(dataType, indent);
            }

            foreach (KeyValuePair<string, Template> kv in unreservedTemplates)
            {
                str += kv.Value.DataWithType(dataType, " ");
            }

            str += crc.DataWithType(dataType, indent);
            return str;
        }


        public string ToBinary()
        {
            return DataWithType(MerchantConsts.DATA_TYPE.BINARY);
        }

        public string RawData ()
        {
            return DataWithType(MerchantConsts.DATA_TYPE.RAW);
        }


        public string GeneratePayload()
        {
            string str = string.Empty;
            str += payloadFormatIndicator != null ? payloadFormatIndicator.ToString() : string.Empty;
            str += pointOfInitiationMethod.ToString();

            foreach (KeyValuePair<string, Template> kv in merchantAccountInformation)
            {
                str += kv.Value.ToString();
            }

            str += merchantCategoryCode.ToString();
            str += transactionCurrency.ToString();
            str += transactionAmount.ToString();
            str += tipOrConvenienceIndicator.ToString();
            str += valueOfConvenienceFeeFixed.ToString();
            str += valueOfConvenienceFeePercentage.ToString();
            str += countryCode.ToString();
            str += merchantName.ToString();
            str += merchantCity.ToString();
            str += postalCode.ToString();
            str += additionalDataFieldTemplate.ToString();
            str += merchantInformationLanguageTemplate.ToString();
            str += rfuForEMVCo.Select(x => x.ToString()).Aggregate(string.Empty, (accumulator, r) => accumulator + r);

            foreach (KeyValuePair<string, Template> kv in unreservedTemplates)
            {
                str += kv.Value.ToString();
            }

            str += StaticMethods.formatCrc(str);
            return str;
        }


        public bool Validate()
        {
            if (payloadFormatIndicator == null || string.IsNullOrEmpty(payloadFormatIndicator.ToString()))
            {
                throw new InvalidOperationException("payloadFormatIndicator is mandatory");
            }
            if (merchantAccountInformation == null ||merchantAccountInformation.Count <= 0)
            {
                throw new InvalidOperationException("merchantAccountInformation is mandatory");
            }
            if (merchantCategoryCode == null || string.IsNullOrEmpty(merchantCategoryCode.ToString()))
            {
                throw new InvalidOperationException("merchantCategoryCode is mandatory");
            }
            if (transactionCurrency == null || string.IsNullOrEmpty(transactionCurrency.ToString()))
            {
                throw new InvalidOperationException("transactionCurrency is mandatory");
            }
            if (countryCode == null || string.IsNullOrEmpty(countryCode.ToString()))
            {
                throw new InvalidOperationException("countryCode is mandatory");
            }
            if (merchantName == null || string.IsNullOrEmpty(merchantName.ToString()))
            {
                throw new InvalidOperationException("merchantName is mandatory");
            }
            if (merchantCity == null || string.IsNullOrEmpty(merchantCity.ToString()))
            {
                throw new InvalidOperationException("merchantCity is mandatory");
            }

            if (pointOfInitiationMethod != null && !string.IsNullOrEmpty(pointOfInitiationMethod.value))
            {
                // eslint-disable-next-line eqeqeq
                if (pointOfInitiationMethod.value != MerchantConsts.INITIAL_METHOD.PointOfInitiationMethodStatic && pointOfInitiationMethod.value != MerchantConsts.INITIAL_METHOD.PointOfInitiationMethodDynamic)
                {
                    throw new InvalidOperationException($"PointOfInitiationMethod should be \"11\" or \"12\", PointOfInitiationMethod: { pointOfInitiationMethod }");
                }
            }

            if (merchantInformationLanguageTemplate != null)
            {
                merchantInformationLanguageTemplate.Validate();
            }
            return true;
        }

        public void SetPayloadFormatIndicator(string v)
        {
            payloadFormatIndicator = new TLV(MerchantConsts.ID.IDPayloadFormatIndicator, v.Length, v);
        }

        public void SetPointOfInitiationMethod (string v) {
            pointOfInitiationMethod = new TLV(MerchantConsts.ID.IDPointOfInitiationMethod, v.Length, v);
        }

        public void SetMerchantCategoryCode (string v) {
            merchantCategoryCode = new TLV(MerchantConsts.ID.IDMerchantCategoryCode, v.Length, v);
        }

        public void SetTransactionCurrency (string v) {
            transactionCurrency = new TLV(MerchantConsts.ID.IDTransactionCurrency, v.Length, v);
        }

        public void SetTransactionAmount (string v) {
            transactionAmount = new TLV(MerchantConsts.ID.IDTransactionAmount, v.Length, v);
        }

        public void SetTipOrConvenienceIndicator (string v) {
            tipOrConvenienceIndicator = new TLV(MerchantConsts.ID.IDTipOrConvenienceIndicator, v.Length, v);
        }

        public void SetValueOfConvenienceFeeFixed (string v) {
            valueOfConvenienceFeeFixed = new TLV(MerchantConsts.ID.IDValueOfConvenienceFeeFixed, v.Length, v);
        }

        public void SetValueOfConvenienceFeePercentage (string v) {
            // eslint-disable-next-line no-undef
            valueOfConvenienceFeePercentage = new TLV(MerchantConsts.ID.IDValueOfConvenienceFeePercentage, v.Length, v);
        }

        public void SetCountryCode (string v) {
            countryCode = new TLV(MerchantConsts.ID.IDCountryCode, v.Length, v);
        }

        public void SetMerchantName (string v) {
            merchantName = new TLV(MerchantConsts.ID.IDMerchantName, v.Length, v);
        }

        public void SetMerchantCity (string v) {
            merchantCity = new TLV(MerchantConsts.ID.IDMerchantCity, v.Length, v);
        }

        public void SetPostalCode (string v) {
            postalCode = new TLV(MerchantConsts.ID.IDPostalCode, v.Length, v);
        }

        public void SetCRC (string v) {
            crc = new TLV(MerchantConsts.ID.IDCRC, v.Length, v);
        }

        public void SetAdditionalDataFieldTemplate (AdditionalDataFieldTemplate v) 
        {
            additionalDataFieldTemplate = v;
        }

        public void SetMerchantInformationLanguageTemplate (MerchantInformationLanguageTemplate v) 
        {
            merchantInformationLanguageTemplate = v;
        }


        public void AddMerchantAccountInformation (string id, Template v) 
        {
            if (merchantAccountInformation == null)
            {
                merchantAccountInformation = new Dictionary<string, Template>();
            }

            merchantAccountInformation[id] = new MerchantAccountInformationTLV(id, v.ToString().Length, v);
        }

        public void AddUnreservedTemplates (string id, Template v) {
            if (unreservedTemplates == null)
            {
                unreservedTemplates = new Dictionary<string, Template>();
            }

            unreservedTemplates[id] = new UnreservedTemplateTLV(id, v.ToString().Length, v);
        }

        public void AddRFUforEMVCo (string id, string v) 
        {
            var append = rfuForEMVCo.Append(new TLV(id, v.Length, v));
            rfuForEMVCo = append.ToArray();
        }

    }
}
