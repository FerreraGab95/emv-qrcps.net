namespace emv_qrcps.QrCode.Merchant
{
    public class PaymentSystemSpecific : IdContextTemplate
    {
        public PaymentSystemSpecific(Template globallyUniqueIdentifier, Template[] paymentSystemSpecific) :
            base(globallyUniqueIdentifier, paymentSystemSpecific)
        {}


        public override void SetGloballyUniqueIdentifier(string v)
        {
            globallyUniqueIdentifier = new TLV(
                MerchantConsts.MERCHANT_ACCOUNT_INFORMATION.MerchantAccountInformationIDGloballyUniqueIdentifier, 
                v.Length, v);
        }
    }
}
