using static emv_qrcps.QrCode.Consumer.ConsumerConsts;

namespace emv_qrcps.QrCode.Consumer
{
    public class ApplicationSpecificTransparentTemplate : TransparentTemplate
    {
        public ApplicationSpecificTransparentTemplate(BERTLV berTLV) : base(berTLV) { }

        public ApplicationSpecificTransparentTemplate() : base() { }

        public override string Format()
        {
            string template = getFormat();
            return StaticMethods.buildFormat(PAYLOAD.IDApplicationSpecificTransparentTemplate, template);
        }

        public override string DataWithType(string dataType, string indent)
        {
            string str = getDataWithType(dataType, indent);
            return indent + StaticMethods.formatDataWithTypeTemplate(PAYLOAD.IDApplicationSpecificTransparentTemplate, dataType, str);
        }
    }
}

