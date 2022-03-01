using System.Collections.Generic;
using System.Linq;

namespace emv_qrcps.QrCode.Merchant
{
    public class AdditionalDataFieldTemplate : Template
    {
        private TLV billNumber;
        private TLV mobileNumber;
        private TLV storeLabel;
        private TLV loyaltyNumber;
        private TLV referenceLabel;
        private TLV customerLabel;
        private TLV terminalLabel;
        private TLV purposeTransaction;
        private TLV additionalConsumerDataRequest;
        private Template[] rfuForEMVCo;
        private Dictionary<string, Template> paymentSystemSpecific;

        public AdditionalDataFieldTemplate()
        {
            this.billNumber = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDBillNumber, string.Empty.Length, string.Empty);
            this.mobileNumber = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDMobileNumber, string.Empty.Length, string.Empty);
            this.storeLabel = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDStoreLabel, string.Empty.Length, string.Empty);
            this.loyaltyNumber = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDLoyaltyNumber, string.Empty.Length, string.Empty);
            this.referenceLabel = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDReferenceLabel, string.Empty.Length, string.Empty);
            this.customerLabel = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDCustomerLabel, string.Empty.Length, string.Empty);
            this.terminalLabel = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDTerminalLabel, string.Empty.Length, string.Empty);
            this.purposeTransaction = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDPurposeTransaction, string.Empty.Length, string.Empty);
            this.additionalConsumerDataRequest = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDAdditionalConsumerDataRequest, string.Empty.Length, string.Empty);
            this.rfuForEMVCo = new Template[] { };
            this.paymentSystemSpecific = new Dictionary<string, Template>();
        }

        public AdditionalDataFieldTemplate(TLV billNumber, TLV mobileNumber, TLV storeLabel, TLV loyaltyNumber,
            TLV referenceLabel, TLV customerLabel, TLV terminalLabel, TLV purposeTransaction,
            TLV additionalConsumerDataRequest, Template[] rfuForEMVCo, Dictionary<string, Template> paymentSystemSpecific)
        {
            this.billNumber = billNumber;
            this.mobileNumber = mobileNumber;
            this.storeLabel = storeLabel;
            this.loyaltyNumber = loyaltyNumber;
            this.referenceLabel = referenceLabel;
            this.customerLabel = customerLabel;
            this.terminalLabel = terminalLabel;
            this.purposeTransaction = purposeTransaction;
            this.additionalConsumerDataRequest = additionalConsumerDataRequest;
            this.rfuForEMVCo = rfuForEMVCo;
            this.paymentSystemSpecific = paymentSystemSpecific;
        }

        public override string DataWithType(string dataType, string indent)
        {
            string t = string.Empty;
            t += billNumber.DataWithType(dataType, indent);
            t += mobileNumber.DataWithType(dataType, indent);
            t += storeLabel.DataWithType(dataType, indent);
            t += loyaltyNumber.DataWithType(dataType, indent);
            t += referenceLabel.DataWithType(dataType, indent);
            t += customerLabel.DataWithType(dataType, indent);
            t += terminalLabel.DataWithType(dataType, indent);
            t += purposeTransaction.DataWithType(dataType, indent);
            t += additionalConsumerDataRequest.DataWithType(dataType, indent);
            t += rfuForEMVCo.Select(x => x.ToString()).Aggregate(string.Empty, (accumulator, r) => accumulator + r);

            foreach(KeyValuePair<string, Template> kv in paymentSystemSpecific)
            {
                t += indent + kv.Value.DataWithType(dataType, "  ");
            }

            if (!string.IsNullOrEmpty(t))
            {
                return MerchantConsts.ID.IDAdditionalDataFieldTemplate + ' ' + StaticMethods.ll(ToString()) + "\r\n" + t;
            }

            return string.Empty;
        }


        public override string ToString()
        {
            string str = string.Empty;
            str += billNumber.ToString();
            str += mobileNumber.ToString();
            str += storeLabel.ToString();
            str += loyaltyNumber.ToString();
            str += referenceLabel.ToString();
            str += customerLabel.ToString();
            str += terminalLabel.ToString();
            str += purposeTransaction.ToString();
            str += additionalConsumerDataRequest.ToString();
            str += rfuForEMVCo.Select(x => x.ToString()).Aggregate(string.Empty, (accumulator, r) => accumulator + r);

            foreach (KeyValuePair<string, Template> kv in paymentSystemSpecific)
            {
                str += kv.Value.ToString();
            }

            if (!string.IsNullOrEmpty(str))
            {
                return StaticMethods.format(MerchantConsts.ID.IDAdditionalDataFieldTemplate, str);
            }
            return string.Empty;
        }


        public void SetBillNumber(string v)
        {
            billNumber = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDBillNumber, v.Length, v);
        }

        public void SetMobileNumber(string v)
        {
            mobileNumber = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDMobileNumber, v.Length, v);
        }

        public void SetStoreLabel(string v)
        {
            storeLabel = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDStoreLabel, v.Length, v);
        }

        public void SetLoyaltyNumber(string v)
        {
            loyaltyNumber = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDLoyaltyNumber, v.Length, v);
        }

        public void SetReferenceLabel(string v)
        {
            referenceLabel = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDReferenceLabel, v.Length, v);
        }

        public void  SetCustomerLabel(string v)
        {
            customerLabel = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDCustomerLabel, v.Length, v);
        }

        public void SetTerminalLabel(string v)
        {
            terminalLabel = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDTerminalLabel, v.Length, v);
        }

        public void SetPurposeTransaction (string v)
        {
            purposeTransaction = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDPurposeTransaction, v.Length, v);
        }

        public void SetAdditionalConsumerDataRequest(string v)
        {
            additionalConsumerDataRequest = new TLV(MerchantConsts.ADDITIONAL_FIELD.AdditionalIDAdditionalConsumerDataRequest, 
                v.Length, v);
        }

        public void AddRFUforEMVCo(string id, string v)
        {
            var append = rfuForEMVCo.Append(new TLV(id, v.Length, v));
            rfuForEMVCo = append.ToArray();
        }

        public void AddPaymentSystemSpecific(string id, Template v)
        {
            if (paymentSystemSpecific == null)
            {
                paymentSystemSpecific = new Dictionary<string, Template>();
            }

            paymentSystemSpecific.Add(id, new PaymentSystemSpecificTLV(id, v.ToString().Length, v));
        }
    }
}
