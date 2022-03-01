using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace emv_qrcps.QrCode.Merchant
{
    public class TLV : Template
    {
        internal string tag;
        private int _length;
        internal int length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
                _sLength = StaticMethods.pad2(length);
            }
        }

        internal string value;
        internal string sLength
        {
            get
            {
                return _sLength;
            }
            set
            {
                _sLength = value;
                _length = int.Parse(sLength);
            }
        }

        private string _sLength;

        public TLV(string tag, int length, string value)
        {
            this.tag = tag;
            this.length = length;
            this.value = value;
        }

        public override string DataWithType(string dataType, string indent)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (dataType == MerchantConsts.DATA_TYPE.BINARY)
                {
                    string REGEX_PATTERN = "(.{2})";

                    string hexStr = string.Join("", value.Select(c => String.Format("{0:X2}",
                        Convert.ToInt32(c)))).ToUpper(); //Método Original Buffer.from(value).toString('hex').toUpperCase();

                    var hexMatch = Regex.Matches(hexStr, REGEX_PATTERN);
                    string[] hexArray = Regex.Matches(hexStr, REGEX_PATTERN).Cast<Match>().Select(x => x.Value).ToArray();

                    hexArray = hexArray == null ? new string[] { } : hexArray;

                    return indent + tag + ' ' + sLength + ' ' + String.Join(" ", hexArray) + "\r\n"; //TEST
                }
                else if (dataType == MerchantConsts.DATA_TYPE.RAW)
                {
                    return indent + tag + ' ' + sLength + ' ' + value + "\r\n"; //TEST
                }
            }
            return string.Empty;
        }


        public override string ToString()
        {
            if (!string.IsNullOrEmpty(value))
            {
                return tag + sLength + value;
            }
            return string.Empty;
        }
    }
}
