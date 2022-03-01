using System;
using System.Collections.Generic;
using System.Text;

namespace emv_qrcps.QrCode.Consumer
{
    public static class ConsumerConsts
    {
        public static class DATA_TYPE
        {
            public const string BINARY = "binary";
            public const string RAW = "raw";
        }

        public static class PAYLOAD
        {
            public const string IDPayloadFormatIndicator = "85"; // (M) Payload Format Indicator
            public const string IDApplicationTemplate = "61"; // (M) Application Template
            public const string IDCommonDataTemplate = "62"; // (O) Common Data Template
            public const string IDApplicationSpecificTransparentTemplate = "63"; // (O) Application Specific Transparent Template
            public const string IDCommonDataTransparentTemplate = "64"; // (O) Common Data Transparent Template
        }

        public static class TAG
        {
            public const string TagApplicationDefinitionFileName = "4F";
            public const string TagApplicationLabel = "50";
            public const string TagTrack2EquivalentData = "57";
            public const string TagApplicationPAN = "5A";
            public const string TagCardholderName = "5F20";
            public const string TagLanguagePreference = "5F2D";
            public const string TagIssuerURL = "5F50";
            public const string TagApplicationVersionNumber = "9F08";
            public const string TagIssuerApplicationData = "9F10";
            public const string TagTokenRequestorID = "9F19";
            public const string TagPaymentAccountReference = "9F24";
            public const string TagLast4DigitsOfPAN = "9F25";
            public const string TagApplicationCryptogram = "9F26";
            public const string TagApplicationTransactionCounter = "9F36";
            public const string TagUnpredictableNumber = "9F37";
        }
    }
}
