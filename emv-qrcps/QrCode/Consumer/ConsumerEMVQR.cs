using System;
using System.Linq;
using static emv_qrcps.QrCode.Consumer.ConsumerConsts;

namespace emv_qrcps.QrCode.Consumer
{
    public class ConsumerEMVQR : Template
    {
        private string dataPayloadFormatIndicator;
        private AppTemplate[] applicationTemplates;
        private CommonTemplate[] commonDataTemplates;

        public ConsumerEMVQR(string dataPayloadFormatIndicator, AppTemplate[] applicationTemplates, CommonTemplate[] commonDataTemplates)
        {
            this.dataPayloadFormatIndicator = dataPayloadFormatIndicator;
            this.applicationTemplates = applicationTemplates;
            this.commonDataTemplates = commonDataTemplates;
        }

        public ConsumerEMVQR()
        {
            this.dataPayloadFormatIndicator = string.Empty;
            this.applicationTemplates = new AppTemplate[] { };
            this.commonDataTemplates = new CommonTemplate[] { };
        }


        public void SetDataPayloadFormatIndicator(string value)
        {
            dataPayloadFormatIndicator = value;
        }

        public void AddApplicationTemplate(AppTemplate value)
        {
            var append = applicationTemplates.Append(value);
            applicationTemplates = append.ToArray();
        }

        public void AddCommonDataTemplate(CommonTemplate value)
        {
            var append = commonDataTemplates.Append(value);
            commonDataTemplates = append.ToArray();
        }

        public override string DataWithType(string dataType, string indent = "")
        {
            indent = string.Empty;
            string str = string.Empty;
            str += StaticMethods.formatDataWithType(dataType, indent, StaticMethods.buildFormat(
                PAYLOAD.IDPayloadFormatIndicator, StaticMethods.toHex(dataPayloadFormatIndicator)));

            str += applicationTemplates.Select(x => x.DataWithType(dataType, " "))
            .Aggregate(string.Empty, (accumulator, a) => accumulator += a);
            str += commonDataTemplates.Select(x => x.DataWithType(dataType, " "))
            .Aggregate(string.Empty, (accumulator, c) => accumulator += c);
            return str;
        }

        public string ToBinary()
        {
            return DataWithType(DATA_TYPE.BINARY);
        }

        public string RawData()
        {
            return DataWithType(DATA_TYPE.RAW);
        }
        

        public string GeneratePayload()
        {
            string template = string.Empty;
            template += StaticMethods.buildFormat(PAYLOAD.IDPayloadFormatIndicator, StaticMethods.toHex(dataPayloadFormatIndicator));
            template += applicationTemplates.Select(x => x.Format()).Aggregate(string.Empty, (accumulator, a) => accumulator += a);
            template += commonDataTemplates.Select(x => x.Format()).Aggregate(string.Empty, (accumulator, c) => accumulator += c);
            Byte[] templateByteArray = StaticMethods.hexStringtoByteArray(template);
            return Convert.ToBase64String(templateByteArray);
        }
    }
}

