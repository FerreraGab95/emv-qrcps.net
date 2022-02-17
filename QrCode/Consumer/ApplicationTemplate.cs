using static emv_qrcps.QrCode.Consumer.ConsumerConsts;

namespace emv_qrcps.QrCode.Consumer
{
    public class ApplicationTemplate : CommonTemplate
    {
        public ApplicationTemplate(BERTLV berTLV, AppTemplate[] applicationSpecificTransparentTemplates) : 
            base(berTLV, applicationSpecificTransparentTemplates)
        {
        }

        public ApplicationTemplate() : base()
        {
        }


        public override string DataWithType(string dataType, string indent)
        {
            string str = getDataWithType(dataType, indent);
            return StaticMethods.formatDataWithTypeTemplate(PAYLOAD.IDApplicationTemplate, dataType, str);
        }

        public override string Format()
        {
            string template = getFormat();
            return StaticMethods.buildFormat(PAYLOAD.IDApplicationTemplate, template);
        }
    }
}

