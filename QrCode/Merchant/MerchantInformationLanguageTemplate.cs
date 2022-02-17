using System;
using System.Linq;

namespace emv_qrcps.QrCode.Merchant
{
    public class MerchantInformationLanguageTemplate : Template
    {
        private TLV languagePreference;
        private TLV merchantName;
        private TLV merchantCity;
        private Template[] rfuForEMVCo;

        public MerchantInformationLanguageTemplate()
        {
            languagePreference = new TLV(MerchantConsts.MERCHANT_INFORMATION.MerchantInformationIDLanguagePreference, string.Empty.Length, string.Empty);
            merchantName = new TLV(MerchantConsts.MERCHANT_INFORMATION.MerchantInformationIDMerchantName, string.Empty.Length, string.Empty);
            merchantCity = new TLV(MerchantConsts.MERCHANT_INFORMATION.MerchantInformationIDMerchantCity, string.Empty.Length, string.Empty);
            rfuForEMVCo = new Template[] { };
        }


        public MerchantInformationLanguageTemplate(TLV languagePreference, TLV merchantName, TLV merchantCity, Template[] rfuForEMVCo)
        {
            this.languagePreference = languagePreference;
            this.merchantName = merchantName;
            this.merchantCity = merchantCity;
            this.rfuForEMVCo = rfuForEMVCo;
        }


        public override string DataWithType(string dataType, string indent)
        {
            string str = string.Empty;
            str += languagePreference.DataWithType(dataType, indent);
            str += merchantName.DataWithType(dataType, indent);
            str += merchantCity.DataWithType(dataType, indent);
            str += rfuForEMVCo.Select(x=>x.DataWithType(dataType, indent)).Aggregate(string.Empty, (accumulator, r) => accumulator + r);

            if (!string.IsNullOrEmpty(str))
            {
                return MerchantConsts.ID.IDMerchantInformationLanguageTemplate + ' ' + StaticMethods.ll(ToString()) + "\r\n" + str;
            }
            return string.Empty;
        }

        public override string ToString()
        {
            string str = string.Empty;
            str += languagePreference.ToString();
            str += merchantName.ToString();
            str += merchantCity.ToString();
            str += rfuForEMVCo.Select(x => x.ToString()).Aggregate(string.Empty, (accumulator, r) => accumulator + r);
            if (!string.IsNullOrEmpty(str))
            {
                return StaticMethods.format(MerchantConsts.ID.IDMerchantInformationLanguageTemplate, str);
            }
            return string.Empty;
        }


        public bool Validate()
        {
            //if (languagePreference == null || string.IsNullOrEmpty(languagePreference.ToString()))
            if (languagePreference == null)
            {
                throw new InvalidOperationException("languagePreference is mandatory");
            }
            //if (merchantName == null || string.IsNullOrEmpty(merchantName.ToString()))
            if (merchantName == null)
            {
                throw new InvalidOperationException("merchantName is mandatory");
            }
            return true;
        }


        public void SetLanguagePreference(string v)
        {
            languagePreference = new TLV(MerchantConsts.MERCHANT_INFORMATION.MerchantInformationIDLanguagePreference,
                v.Length, v);
        }

        
        public void SetMerchantName(string v)
        {
            merchantName = new TLV(MerchantConsts.MERCHANT_INFORMATION.MerchantInformationIDMerchantName, v.Length, v);
        }

        public void SetMerchantCity(string v)
        {
            merchantCity = new TLV(MerchantConsts.MERCHANT_INFORMATION.MerchantInformationIDMerchantCity, v.Length, v);
        }

        public void AddRFUforEMVCo(string id, string v)
        {
            var append = rfuForEMVCo.Append(new TLV(id, v.Length, v));
            rfuForEMVCo = append.ToArray();
        }
    }
}
