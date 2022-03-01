namespace emv_qrcps.QrCode.Merchant
{
    public class MerchantAccountInformation : IdContextTemplate
    {
        public MerchantAccountInformation(Template globallyUniqueIdentifier, Template[] paymentNetworkSpecific) :
            base(globallyUniqueIdentifier, paymentNetworkSpecific)
        { }

        public MerchantAccountInformation() : base() { }



        public override void SetGloballyUniqueIdentifier(string v)
        {
            globallyUniqueIdentifier = new TLV(
                MerchantConsts.MERCHANT_ACCOUNT_INFORMATION.MerchantAccountInformationIDGloballyUniqueIdentifier, v.Length, v);
        }
    }
}
