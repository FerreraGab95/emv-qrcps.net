using static emv_qrcps.QrCode.Consumer.ConsumerConsts;

namespace emv_qrcps.QrCode.Consumer
{
    public class CommonDataTemplate : CommonTemplate
    {
        public CommonDataTemplate(BERTLV berTLV, AppTemplate[] applicationSpecificTransparentTemplates) :
            base(berTLV, applicationSpecificTransparentTemplates)
        {
        }

        public CommonDataTemplate() : base() { }

        public override string DataWithType(string dataType, string indent)
        {
            string str = getDataWithType(dataType, indent);
            return StaticMethods.formatDataWithTypeTemplate(PAYLOAD.IDCommonDataTemplate, dataType, str);
        }

        public override string Format()
        {
            string template = getFormat();
            return StaticMethods.buildFormat(PAYLOAD.IDCommonDataTemplate, template);
        }
    }
}

