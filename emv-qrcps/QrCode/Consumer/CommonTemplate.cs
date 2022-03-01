using System.Linq;

namespace emv_qrcps.QrCode.Consumer
{
    public abstract class CommonTemplate : AppTemplate
    {
        protected BERTLV berTLV;
        protected AppTemplate[] applicationSpecificTransparentTemplates;

        public CommonTemplate(BERTLV berTLV, AppTemplate[] applicationSpecificTransparentTemplates)
        {
            this.berTLV = berTLV;
            this.applicationSpecificTransparentTemplates = applicationSpecificTransparentTemplates;
        }

        public CommonTemplate()
        {
            this.berTLV = new BERTLV();
            this.applicationSpecificTransparentTemplates = new AppTemplate[] { };
        }

        public void SetBERTLV(BERTLV value)
        {
            berTLV = value;
        }

        public void AddCommonAppTemplate(AppTemplate value)
        {
            var append = applicationSpecificTransparentTemplates.Append(value);
            applicationSpecificTransparentTemplates = append.ToArray();
        }


        protected virtual string getDataWithType(string dataType, string indent)
        {
            string str = string.Empty;
            str += berTLV.DataWithType(dataType, indent);
            str += applicationSpecificTransparentTemplates.Select(x => x.DataWithType(dataType, indent))
            .Aggregate(string.Empty, (accumulator, a) => accumulator += a);
            return str;
        }


        protected virtual string getFormat()
        {
            string template = string.Empty;
            template += berTLV.Format();
            template += applicationSpecificTransparentTemplates.Select(x => x.Format()).
            Aggregate(string.Empty, (accumulator, b) => accumulator += b);
            return template;
        }

    }
}

