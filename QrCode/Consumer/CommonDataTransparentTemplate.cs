using static emv_qrcps.QrCode.Consumer.ConsumerConsts;

namespace emv_qrcps.QrCode.Consumer
{
    public class CommonDataTransparentTemplate : TransparentTemplate
    {
        public CommonDataTransparentTemplate(BERTLV berTLV) : base(berTLV) { }

        public CommonDataTransparentTemplate() : base() { }


        public override string DataWithType(string dataType, string indent)
        {
            string str = getDataWithType(dataType, indent);
            return indent + StaticMethods.formatDataWithTypeTemplate(PAYLOAD.IDCommonDataTransparentTemplate, dataType, str);
        }


        public override string Format()
        {
            string template = getFormat();
            return StaticMethods.buildFormat(PAYLOAD.IDCommonDataTransparentTemplate, template);
        }
    }
}

