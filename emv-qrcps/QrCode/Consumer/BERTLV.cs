using System.Collections.Generic;
using System.Text;
using static emv_qrcps.QrCode.Consumer.ConsumerConsts;

namespace emv_qrcps.QrCode.Consumer
{
    public class BERTLV : AppTemplate
    {
        private string dataApplicationDefinitionFileName;
        private string dataApplicationLabel;
        private string dataTrack2EquivalentData;
        private string dataApplicationPAN;
        private string dataCardholderName;
        private string dataLanguagePreference;
        private string dataIssuerURL;
        private string dataApplicationVersionNumber;
        private string dataIssuerApplicationData;
        private string dataTokenRequestorID;
        private string dataPaymentAccountReference;
        private string dataLast4DigitsOfPAN;
        private string dataApplicationCryptogram;
        private string dataApplicationTransactionCounter;
        private string dataUnpredictableNumber;


        public BERTLV(string dataApplicationDefinitionFileName = "",
                      string dataApplicationLabel = "",
                      string dataTrack2EquivalentData = "",
                      string dataApplicationPAN = "",
                      string dataCardholderName = "",
                      string dataLanguagePreference = "",
                      string dataIssuerURL = "",
                      string dataApplicationVersionNumber = "",
                      string dataIssuerApplicationData = "",
                      string dataTokenRequestorID = "",
                      string dataPaymentAccountReference = "",
                      string dataLast4DigitsOfPAN = "",
                      string dataApplicationCryptogram = "",
                      string dataApplicationTransactionCounter = "",
                      string dataUnpredictableNumber = "")
        {
            this.dataApplicationDefinitionFileName = dataApplicationDefinitionFileName;
            this.dataApplicationLabel = dataApplicationLabel;
            this.dataTrack2EquivalentData = dataTrack2EquivalentData;
            this.dataApplicationPAN = dataApplicationPAN;
            this.dataCardholderName = dataCardholderName;
            this.dataLanguagePreference = dataLanguagePreference;
            this.dataIssuerURL = dataIssuerURL;
            this.dataApplicationVersionNumber = dataApplicationVersionNumber;
            this.dataIssuerApplicationData = dataIssuerApplicationData;
            this.dataTokenRequestorID = dataTokenRequestorID;
            this.dataPaymentAccountReference = dataPaymentAccountReference;
            this.dataLast4DigitsOfPAN = dataLast4DigitsOfPAN;
            this.dataApplicationCryptogram = dataApplicationCryptogram;
            this.dataApplicationTransactionCounter = dataApplicationTransactionCounter;
            this.dataUnpredictableNumber = dataUnpredictableNumber;
        }


        public override string Format()
        {
            string template = string.Empty;
            template += StaticMethods.buildFormat(TAG.TagApplicationDefinitionFileName, dataApplicationDefinitionFileName);
            template += StaticMethods.buildFormat(TAG.TagApplicationLabel, StaticMethods.toHex(dataApplicationLabel));
            template += StaticMethods.buildFormat(TAG.TagTrack2EquivalentData, dataTrack2EquivalentData);
            template += StaticMethods.buildFormat(TAG.TagApplicationPAN, dataApplicationPAN);
            template += StaticMethods.buildFormat(TAG.TagCardholderName, StaticMethods.toHex(dataCardholderName));
            template += StaticMethods.buildFormat(TAG.TagLanguagePreference, StaticMethods.toHex(dataLanguagePreference));
            template += StaticMethods.buildFormat(TAG.TagIssuerURL, StaticMethods.toHex(dataIssuerURL));
            template += StaticMethods.buildFormat(TAG.TagApplicationVersionNumber, dataApplicationVersionNumber);
            template += StaticMethods.buildFormat(TAG.TagIssuerApplicationData, dataIssuerApplicationData);
            template += StaticMethods.buildFormat(TAG.TagTokenRequestorID, dataTokenRequestorID);
            template += StaticMethods.buildFormat(TAG.TagPaymentAccountReference, dataPaymentAccountReference);
            template += StaticMethods.buildFormat(TAG.TagLast4DigitsOfPAN, dataLast4DigitsOfPAN);
            template += StaticMethods.buildFormat(TAG.TagApplicationCryptogram, dataApplicationCryptogram);
            template += StaticMethods.buildFormat(TAG.TagApplicationTransactionCounter, dataApplicationTransactionCounter);
            template += StaticMethods.buildFormat(TAG.TagUnpredictableNumber, dataUnpredictableNumber);
            return template;
        }

        public override string DataWithType(string dataType, string indent)
        {
            string str = string.Empty;
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagApplicationDefinitionFileName, dataApplicationDefinitionFileName));
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagApplicationLabel, StaticMethods.toHex(dataApplicationLabel)));
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagTrack2EquivalentData, dataTrack2EquivalentData));
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagApplicationPAN, dataApplicationPAN));
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagCardholderName, StaticMethods.toHex(dataCardholderName)));
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagLanguagePreference, StaticMethods.toHex(dataLanguagePreference)));
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagIssuerURL, StaticMethods.toHex(dataIssuerURL)));
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagApplicationVersionNumber, dataApplicationVersionNumber));
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagIssuerApplicationData, dataIssuerApplicationData));
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagTokenRequestorID, dataTokenRequestorID));
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagPaymentAccountReference, dataPaymentAccountReference));
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagLast4DigitsOfPAN, dataLast4DigitsOfPAN));
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagApplicationCryptogram, dataApplicationCryptogram));
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagApplicationTransactionCounter, dataApplicationTransactionCounter));
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(TAG.TagUnpredictableNumber, dataUnpredictableNumber));
            return str;
        }

        public void SetDataApplicationDefinitionFileName(string value)
        {
            dataApplicationDefinitionFileName = value;
        }

        public void SetDataApplicationLabel(string value)
        {
            dataApplicationLabel = value;
        }

        public void SetDataTrack2EquivalentData(string value)
        {
            dataTrack2EquivalentData = value;
        }

        public void SetDataApplicationPAN(string value)
        {
            dataApplicationPAN = value;
        }

        public void SetDataCardholderName(string value)
        {
            dataCardholderName = value;
        }

        public void SetDataLanguagePreference(string value)
        {
            dataLanguagePreference = value;
        }

        public void SetDataIssuerURL(string value)
        {
            dataIssuerURL = value;
        }

        public void SetDataApplicationVersionNumber(string value)
        {
            dataApplicationVersionNumber = value;
        }

        public void SetDataIssuerApplicationData(string value)
        {
            dataIssuerApplicationData = value;
        }

        public void SetDataTokenRequestorID(string value)
        {
            dataTokenRequestorID = value;
        }

        public void SetDataPaymentAccountReference(string value)
        {
            dataPaymentAccountReference = value;
        }

        public void SetDataLast4DigitsOfPAN(string value)
        {
            dataLast4DigitsOfPAN = value;
        }

        public void SetDataApplicationCryptogram(string value)
        {
            dataApplicationCryptogram = value;
        }

        public void SetDataApplicationTransactionCounter(string value)
        {
            dataApplicationTransactionCounter = value;
        }

        public void SetDataUnpredictableNumber(string value)
        {
            dataUnpredictableNumber = value;
        }
    }
}

