using emv_qrcps.QrCode.Consumer;
using emv_qrcps.QrCode.Merchant;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace emv_qrcps_tests
{
    class ConsumertTests
    {
        [Test]
        public void _01_EMVQR_with_Complete_information()
        {
            var emv_qrcode = new ConsumerEMVQR();
            emv_qrcode.SetDataPayloadFormatIndicator("CPV01");

            var applicationTemplate1 = new ApplicationTemplate();

            var berTLV1 = new BERTLV();
            berTLV1.SetDataApplicationDefinitionFileName("A0000000555555");
            berTLV1.SetDataApplicationLabel("Product1");
            applicationTemplate1.SetBERTLV(berTLV1);
            emv_qrcode.AddApplicationTemplate(applicationTemplate1);

            var applicationTemplate2 = new ApplicationTemplate();

            var berTLV2 = new BERTLV();
            berTLV2.SetDataApplicationDefinitionFileName("A0000000666666");
            berTLV2.SetDataApplicationLabel("Product2");
            applicationTemplate2.SetBERTLV(berTLV2);
            emv_qrcode.AddApplicationTemplate(applicationTemplate2);

            var commonDataTemplate = new CommonDataTemplate();

            var berTLV3 = new BERTLV();
            berTLV3.SetDataApplicationPAN("1234567890123458");
            berTLV3.SetDataCardholderName("CARDHOLDER/EMV");
            berTLV3.SetDataLanguagePreference("ruesdeen");
            commonDataTemplate.SetBERTLV(berTLV3);

            var commonDataTransparentTemplate = new CommonDataTransparentTemplate();

            var berTLV4 = new BERTLV();
            berTLV4.SetDataIssuerApplicationData("06010A03000000");
            berTLV4.SetDataApplicationCryptogram("584FD385FA234BCC");
            berTLV4.SetDataApplicationTransactionCounter("0001");
            berTLV4.SetDataUnpredictableNumber("6D58EF13");
            commonDataTransparentTemplate.SetBERTLV(berTLV4);

            commonDataTemplate.AddCommonAppTemplate(commonDataTransparentTemplate);

            emv_qrcode.AddCommonDataTemplate(commonDataTemplate);

            var expected_qr_code = QRCodesResults.Consumer();

            var binary = emv_qrcode.ToBinary();
            Assert.That(expected_qr_code.StringVal == emv_qrcode.GeneratePayload());
            Assert.That(expected_qr_code.RawData == emv_qrcode.RawData());
            Assert.That(expected_qr_code.BinaryData == emv_qrcode.ToBinary());
        }
    }
}
