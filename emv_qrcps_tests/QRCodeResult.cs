using System;
using System.Collections.Generic;
using System.Text;

namespace emv_qrcps_tests
{
    public class QRCodeResult
    {
        public QRCodeResult (string stringVal, string rawData, string binaryData)
        {
            StringVal = stringVal;
            RawData = rawData;
            BinaryData = binaryData;
        }

        public string StringVal { get; }
        public string RawData { get; }
        public string BinaryData { get; }
    }
}
