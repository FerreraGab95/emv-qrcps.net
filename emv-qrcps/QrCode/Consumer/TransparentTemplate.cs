namespace emv_qrcps.QrCode.Consumer
{
    public abstract class TransparentTemplate : CommonTemplate
    {

        public TransparentTemplate(BERTLV berTLV) : base(berTLV, null)
        {
        }


        public TransparentTemplate() : base() { }


        protected override string getDataWithType(string dataType, string indent)
        {
            string str = string.Empty;
            str += berTLV.DataWithType(dataType, indent + indent);
            return str;
        }


        protected override string getFormat()
        {
            string template = berTLV.Format();
            return template;
        }

    }
}

