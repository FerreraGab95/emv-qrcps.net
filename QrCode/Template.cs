using System;
using System.Collections.Generic;
using System.Text;

namespace emv_qrcps.QrCode
{
    public abstract class Template
    {
        public abstract string DataWithType(string dataType, string indent);

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
