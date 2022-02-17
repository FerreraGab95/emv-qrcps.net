using System;
using System.Collections.Generic;
using System.Text;
using System.Data.HashFunction.CRC;
using System.Linq;
using System.Data.HashFunction.Core.Utilities;
using emv_qrcps.QrCode.Merchant;

namespace emv_qrcps.QrCode.Merchant
{
    internal class StaticMethods
    {

        internal static string pad2(int num)
        {
            if (num < 10)
            {
                string s = num + string.Empty;
                while (s.Length < 2) s = '0' + s;
                return s;
            }

            return num + string.Empty;
        }


        internal static string ll(string v)
        {
            if (!string.IsNullOrEmpty(v))
            {
                return pad2(v.Length - 4);
            }

            return MerchantConsts.PAD_ZERO;
        }


        internal static string format(string id, string value)
        {
            int valueLength = value.Length;
            return id + pad2(valueLength) + value;
        }


        internal static string formatCrc(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                string newValue = value + MerchantConsts.ID.IDCRC + "04";

                var crc = CRCFactory.Instance.Create(CRCConfig.CRC16_CCITTFALSE);
                var hash = crc.ComputeHash(Encoding.Default.GetBytes(newValue));

                /*
                 * Por alguma razão, o valor do hash sempre é devolvido com os
                 * bytes invertidos do resultado esperado, então, no código abaixo, 
                 * a ordem dos bytes é revertida, para que o resultado seja correto.
                 */
                HashValue revertedHash = new HashValue(hash.Hash.Reverse(), hash.BitLength);
                string crcValue = revertedHash.AsHexString().ToUpper();

                return format(MerchantConsts.ID.IDCRC, crcValue);
            }

            return string.Empty;
        }





    }
}
