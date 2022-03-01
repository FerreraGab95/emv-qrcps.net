namespace emv_qrcps.QrCode.Merchant
{
    public class UnreservedTemplate : IdContextTemplate
    {
        public UnreservedTemplate(Template globallyUniqueIdentifier, Template[] contextSpecificData) :
            base(globallyUniqueIdentifier, contextSpecificData)
        {}

        public UnreservedTemplate() : base() { }

        public override void SetGloballyUniqueIdentifier(string v)
        {
            globallyUniqueIdentifier = new TLV(MerchantConsts.UNRESERVED_TEMPLATE.UnreservedTemplateIDGloballyUniqueIdentifier,
                v.Length, v);
        }
    }
}
