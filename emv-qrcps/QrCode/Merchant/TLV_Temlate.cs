namespace emv_qrcps.QrCode.Merchant
{
    internal abstract class TLV_Temlate : Template
    {
        protected string tag;
        protected int length;
        protected Template value;

        internal TLV_Temlate(string tag, int length, Template value)
        {
            this.tag = tag;
            this.length = length;
            this.value = value;
        }

        public override string DataWithType(string dataType, string indent)
        {
            if (!string.IsNullOrEmpty(tag) && value != null)
            {
                return tag + ' ' + length + "\r\n" + value.DataWithType(dataType, indent);
            }
            return string.Empty;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(tag) && value != null)
            {
                return tag + length + value.ToString();
            }
            return string.Empty;
        }
    }
}
