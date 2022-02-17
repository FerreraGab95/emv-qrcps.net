using System.Linq;

namespace emv_qrcps.QrCode.Merchant
{
    public abstract class IdContextTemplate : Template
    {
        protected Template globallyUniqueIdentifier;
        protected Template[] contextSpecificData;


        public IdContextTemplate(Template globallyUniqueIdentifier, Template[] contextSpecificData)
        {
            this.globallyUniqueIdentifier = globallyUniqueIdentifier;
            this.contextSpecificData = contextSpecificData;
        }


        public IdContextTemplate()
        {
            globallyUniqueIdentifier = null;
            contextSpecificData = new Template[] { };
        }


        public override string DataWithType(string dataType, string indent)
        {
            if (globallyUniqueIdentifier != null && contextSpecificData != null)
            {
                //string csData = contextSpecificData.Select(x => x.ToString())
                //.Aggregate(string.Empty, (accumulator, c) => accumulator += c.ToString());
                string csData = string.Empty;

                foreach(var context in contextSpecificData)
                {
                    csData += context.DataWithType(dataType, indent);
                }

                return globallyUniqueIdentifier.DataWithType(dataType, indent) + csData;
            }

            return string.Empty;
        }


        public void AddContextSpecificData(string id, string v)
        {
            var append = contextSpecificData.Append(new TLV(id, v.Length, v));
            contextSpecificData = append.ToArray();
        }


        public abstract void SetGloballyUniqueIdentifier(string v);


        public override string ToString()
        {
            if (globallyUniqueIdentifier != null && contextSpecificData != null)
            {
                string t = string.Empty;
                t += globallyUniqueIdentifier;
                t += contextSpecificData.Select(x => x.ToString())
                    .Aggregate(string.Empty, (accumulator, c) => accumulator += c.ToString());

                string s = string.Empty;

                return t;
            }

            return string.Empty;
        }
    }
}
