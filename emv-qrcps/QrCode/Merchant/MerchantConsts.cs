using System;
using System.Collections.Generic;
using System.Text;

namespace emv_qrcps.QrCode.Merchant
{
    internal class MerchantConsts
    {
        internal const string PAD_ZERO = "00";

        public static class ID
        {
            public const string IDPayloadFormatIndicator = "00"; // (M) Payload Format Indicator
            public const string IDPointOfInitiationMethod = "01"; // (O) Point of Initiation Method
            public const string IDMerchantAccountInformationRangeStart = "02"; // (M) 2-51 Merchant Account Information
            public const string IDMerchantAccountInformationRangeEnd = "51"; // (M) 2-51 Merchant Account Information
            public const string IDMerchantCategoryCode = "52"; // (M) Merchant Category Code
            public const string IDTransactionCurrency = "53"; // (M) Transaction Currency
            public const string IDTransactionAmount = "54"; // (C) Transaction Amount
            public const string IDTipOrConvenienceIndicator = "55"; // (O) Tip or Convenience Indicator
            public const string IDValueOfConvenienceFeeFixed = "56"; // (C) Value of Convenience Fee Fixed
            public const string IDValueOfConvenienceFeePercentage = "57"; // (C) Value of Convenience Fee Percentage
            public const string IDCountryCode = "58"; // (M) Country Code
            public const string IDMerchantName = "59"; // (M) Merchant Name
            public const string IDMerchantCity = "60"; // (M) Merchant City
            public const string IDPostalCode = "61"; // (O) Postal Code
            public const string IDAdditionalDataFieldTemplate = "62"; // (O) Additional Data Field Template
            public const string IDCRC = "63"; // (M) CRC
            public const string IDMerchantInformationLanguageTemplate = "64"; // (O) Merchant Information— Language Template
            public const string IDRFUForEMVCoRangeStart = "65"; // (O) 65-79 RFU for EMVCo
            public const string IDRFUForEMVCoRangeEnd = "79"; // (O) 65-79 RFU for EMVCo
            public const string IDUnreservedTemplatesRangeStart = "80"; // (O) 80-99 Unreserved Templates
            public const string IDUnreservedTemplatesRangeEnd = "99"; // (O) 80-99 Unreserved Templates
        }

        public static class ADDITIONAL_FIELD
        {
            public const string AdditionalIDBillNumber = "01"; // (O) Bill Number
            public const string AdditionalIDMobileNumber = "02"; // (O) Mobile Number
            public const string AdditionalIDStoreLabel = "03"; // (O) Store Label
            public const string AdditionalIDLoyaltyNumber = "04"; // (O) Loyalty Number
            public const string AdditionalIDReferenceLabel = "05"; // (O) Reference Label
            public const string AdditionalIDCustomerLabel = "06"; // (O) Customer Label
            public const string AdditionalIDTerminalLabel = "07"; // (O) Terminal Label
            public const string AdditionalIDPurposeTransaction = "08"; // (O) Purpose Transaction
            public const string AdditionalIDAdditionalConsumerDataRequest = "09"; // (O) Additional Consumer Data Request
            public const string AdditionalIDRFUforEMVCoRangeStart = "10"; // (O) RFU for EMVCo
            public const string AdditionalIDRFUforEMVCoRangeEnd = "49"; // (O) RFU for EMVCo
            public const string AdditionalIDPaymentSystemSpecificTemplatesRangeStart = "50"; // (O) Payment System Specific Templates
            public const string AdditionalIDPaymentSystemSpecificTemplatesRangeEnd = "99"; // (O) Payment System Specific Templates
        }

        public static class MERCHANT_ACCOUNT_INFORMATION
        {
            public const string MerchantAccountInformationIDGloballyUniqueIdentifier = "00";
            public const string MerchantAccountInformationIDPaymentNetworkSpecificStart = "01"; // (O) 03-99 RFU for EMVCo
            public const string MerchantAccountInformationIDPaymentNetworkSpecificEnd = "99"; // (O) 03-99 RFU for EMVCo
        }

        public static class MERCHANT_INFORMATION
        {
            public const string MerchantInformationIDLanguagePreference = "00"; // (M) Language Preference
            public const string MerchantInformationIDMerchantName = "01"; // (M) Merchant Name
            public const string MerchantInformationIDMerchantCity = "02"; // (O) Merchant City
            public const string MerchantInformationIDRFUforEMVCoRangeStart = "03"; // (O) 03-99 RFU for EMVCo
            public const string MerchantInformationIDRFUforEMVCoRangeEnd = "99"; // (O) 03-99 RFU for EMVCo
        }

        public static class UNRESERVED_TEMPLATE
        {
            public const string UnreservedTemplateIDGloballyUniqueIdentifier = "00";
            public const string UnreservedTemplateIDContextSpecificDataStart = "01"; // (O) 03-99 RFU for EMVCo
            public const string UnreservedTemplateIDContextSpecificDataEnd = "99"; // (O) 03-99 RFU for EMVCo
        }

        internal static class INITIAL_METHOD
        {
            internal const string PointOfInitiationMethodStatic = "11";
            internal const string PointOfInitiationMethodDynamic = "12";
        }

        public static class DATA_TYPE
        {
            public const string BINARY = "binary";
            public const string RAW = "raw";
        }
    }
}
