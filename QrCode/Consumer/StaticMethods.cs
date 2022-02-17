using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static emv_qrcps.QrCode.Consumer.ConsumerConsts;

namespace emv_qrcps.QrCode.Consumer
{
    internal static class StaticMethods
    {
        internal static string hexLength(string value)
        {
            int length = value.Length / 2;
            string lengthStr = "00" + length.ToString("X");//BitConverter.ToString(Encoding.Default.GetBytes(length.ToString())).Replace("-", "");
            return lengthStr.Substring(lengthStr.Length - 2);
        }

        internal static string buildFormat(string id, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                string length = hexLength(value);
                return id + length + value;
            }
            return string.Empty;
        }


        internal static string toHex(string s)
        {
            return BitConverter.ToString(Encoding.Default.GetBytes(s)).Replace("-", "");
        }


        internal static byte[] hexStringtoByteArray(string hexString)
        {
            List<byte> result = new List<byte>();
            string byteString = string.Empty;

            for(int i = 0; i < hexString.Length; i++)
            {
                byteString += hexString[i].ToString();

                if(byteString.Length == 2 || (i + 1 == hexString.Length && !string.IsNullOrEmpty(byteString)))
                {
                    result.Add(byte.Parse(byteString, System.Globalization.NumberStyles.HexNumber));
                    byteString = string.Empty;
                }
            }

            return result.ToArray();
        }


        internal static string formatDataWithType(string dataType, string indent, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (dataType == DATA_TYPE.BINARY)
                {
                    string REGEX_PATTERN = "(.{2})";
                    var regex = new Regex(REGEX_PATTERN);
                    string[] hexArray = Regex.Matches(value, REGEX_PATTERN).Select(x => x.Value).ToArray();

                    return indent + string.Join(" ", hexArray) + "\r\n";
                }
                else if (dataType == DATA_TYPE.RAW)
                {
                    return indent + value + "\r\n";
                }
            }
            return string.Empty;
        }


        internal static string formatDataWithTypeTemplate(string id, string dataType, string value)
        {
            string length = hexLength(value.Replace("\r\n", "").Replace("\n", "").Replace("\r", "").Replace(" ", ""));

            if (dataType == DATA_TYPE.BINARY)
            {
                return $"{id} {length}\r\n{value}";
            }
            else
            {
                return $"{ id}{length}\r\n{value}";
            }
        }

    }
}