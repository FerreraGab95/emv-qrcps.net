using NUnit.Framework;
using emv_qrcps.QrCode.Merchant;

namespace emv_qrcps_tests
{
    public class MerchantServiceTests
    {
        [Test]
        public void _01_EMVQR_with_Complete_information()
        {
            var emv_qrcode = new MerchantEMVQR();

            emv_qrcode.SetPayloadFormatIndicator("01");
            emv_qrcode.SetPointOfInitiationMethod("12");
            emv_qrcode.SetMerchantCategoryCode("4111");
            emv_qrcode.SetTransactionAmount("23.72");
            emv_qrcode.SetTransactionCurrency("156");
            emv_qrcode.SetCountryCode("CN");
            emv_qrcode.SetMerchantName("BEST TRANSPORT");
            emv_qrcode.SetMerchantCity("BEIJING");
            emv_qrcode.SetCRC("A13A");

            var merchantAccountInformation = new MerchantAccountInformation();
            merchantAccountInformation.SetGloballyUniqueIdentifier("D15600000000");
            merchantAccountInformation.AddContextSpecificData("05", "A93FO3230Q");
            emv_qrcode.AddMerchantAccountInformation("29", merchantAccountInformation);

            merchantAccountInformation = new MerchantAccountInformation();
            merchantAccountInformation.SetGloballyUniqueIdentifier("D15600000001");
            merchantAccountInformation.AddContextSpecificData("03", "12345678");
            emv_qrcode.AddMerchantAccountInformation("31", merchantAccountInformation);

            var merchantInformationLanguageTemplate = new MerchantInformationLanguageTemplate();
            merchantInformationLanguageTemplate.SetLanguagePreference("ZH");
            merchantInformationLanguageTemplate.SetMerchantName("最佳运输");
            merchantInformationLanguageTemplate.SetMerchantCity("北京");
            emv_qrcode.SetMerchantInformationLanguageTemplate(merchantInformationLanguageTemplate);

            emv_qrcode.SetTipOrConvenienceIndicator("01");

            var AdditionalDataFieldTemplate = new AdditionalDataFieldTemplate();
            AdditionalDataFieldTemplate.SetStoreLabel("1234");
            AdditionalDataFieldTemplate.SetCustomerLabel("***");
            AdditionalDataFieldTemplate.SetTerminalLabel("A6008667");
            AdditionalDataFieldTemplate.SetAdditionalConsumerDataRequest("ME");
            emv_qrcode.SetAdditionalDataFieldTemplate(AdditionalDataFieldTemplate);

            var unreservedTemplate = new UnreservedTemplate();
            unreservedTemplate.SetGloballyUniqueIdentifier("A011223344998877");
            unreservedTemplate.AddContextSpecificData("07", "12345678");
            emv_qrcode.AddUnreservedTemplates("91", unreservedTemplate);

            var qrcode_expected = QRCodesResults._01();
            Assert.That(emv_qrcode.Validate());
            string genPayLoad = emv_qrcode.GeneratePayload();
            Assert.That(qrcode_expected.StringVal == genPayLoad);
        }


        [Test]
        public void _02_EMVQR_static_information()
        {
            var emv_qrcode = new MerchantEMVQR();

            emv_qrcode.SetPayloadFormatIndicator("01");
            emv_qrcode.SetPointOfInitiationMethod("11");
            emv_qrcode.SetMerchantCategoryCode("0000");
            emv_qrcode.SetTransactionCurrency("986");
            emv_qrcode.SetCountryCode("BR");
            emv_qrcode.SetMerchantName("FULANO DE TAL");
            emv_qrcode.SetMerchantCity("BRASILIA");
            // emv_qrcode.SetCRC("DFE3");

            var merchantAccountInformation = new MerchantAccountInformation();
            merchantAccountInformation.SetGloballyUniqueIdentifier("br.gov.bcb.spi");
            merchantAccountInformation.AddContextSpecificData("01", "fulano2019@example.com");
            emv_qrcode.AddMerchantAccountInformation("26", merchantAccountInformation);


            var qrcode_expected = QRCodesResults._05();
            Assert.That(emv_qrcode.Validate());
            Assert.That(emv_qrcode.GeneratePayload() == qrcode_expected.StringVal);


            var raw_expected = qrcode_expected.RawData;
            Assert.That(emv_qrcode.Validate());
            var raw = emv_qrcode.RawData();
            Assert.That(raw_expected == emv_qrcode.RawData());
        }


        [Test]
        public void _03_EMVQR_static_information_with_3_CRC_numbers()
        {
            var emv_qrcode = new MerchantEMVQR();

            emv_qrcode.SetPayloadFormatIndicator("01");
            emv_qrcode.SetPointOfInitiationMethod("12");
            emv_qrcode.SetMerchantCategoryCode("4829");
            emv_qrcode.SetTransactionCurrency("032");
            emv_qrcode.SetTransactionAmount("1.0");
            emv_qrcode.SetCountryCode("AR");
            emv_qrcode.SetMerchantName("Ruth Araceli Fetter Alcala");
            emv_qrcode.SetMerchantCity("CABA");
            emv_qrcode.SetPostalCode("C1038 AAH");
            // emv_qrcode.SetCRC("076B");

            var merchantAccountInformation = new MerchantAccountInformation();
            merchantAccountInformation.SetGloballyUniqueIdentifier("com.witta.merchant");
            merchantAccountInformation.AddContextSpecificData("01", "10035");
            merchantAccountInformation.AddContextSpecificData("02", "27335265287");
            merchantAccountInformation.AddContextSpecificData("03", "+5491156720969");
            emv_qrcode.AddMerchantAccountInformation("26", merchantAccountInformation);

            var qrcode_expected = QRCodesResults._07();
            Assert.That(emv_qrcode.Validate());
            Assert.That(qrcode_expected.StringVal == emv_qrcode.GeneratePayload());
            Assert.That(qrcode_expected.RawData == emv_qrcode.RawData());
        }


        [Test]
        public void _04_EMVQR_dynamic_information()
        {
            var emv_qrcode = new MerchantEMVQR();

            emv_qrcode.SetPayloadFormatIndicator("01");
            emv_qrcode.SetPointOfInitiationMethod("12");
            emv_qrcode.SetMerchantCategoryCode("0000");
            emv_qrcode.SetTransactionAmount("123.45");
            emv_qrcode.SetTransactionCurrency("986");
            emv_qrcode.SetCountryCode("BR");
            emv_qrcode.SetMerchantName("FULANO DE TAL");
            emv_qrcode.SetMerchantCity("BRASILIA");
            emv_qrcode.SetCRC("34D1");

            var merchantAccountInformation = new MerchantAccountInformation();
            merchantAccountInformation.SetGloballyUniqueIdentifier("br.gov.bcb.spi");
            merchantAccountInformation.AddContextSpecificData("21", "12345678");
            merchantAccountInformation.AddContextSpecificData("22", "1234");
            merchantAccountInformation.AddContextSpecificData("23", "12345678");
            merchantAccountInformation.AddContextSpecificData("24", "00112233445566778899");
            emv_qrcode.AddMerchantAccountInformation("26", merchantAccountInformation);

            var AdditionalDataFieldTemplate = new AdditionalDataFieldTemplate();
            AdditionalDataFieldTemplate.SetReferenceLabel("RP12345678-2019");
            emv_qrcode.SetAdditionalDataFieldTemplate(AdditionalDataFieldTemplate);

            var unreservedTemplate = new UnreservedTemplate();
            unreservedTemplate.SetGloballyUniqueIdentifier("br.gov.bcb.spi");
            unreservedTemplate.AddContextSpecificData("25", "bx.com.br/spi/U0VHUkVET1RPVEFMTUVOVEVBTEVBVE9SSU8=");
            emv_qrcode.AddUnreservedTemplates("80", unreservedTemplate);

            var qrcode_expected = QRCodesResults._06();
            Assert.That(emv_qrcode.Validate());
            Assert.That(qrcode_expected.StringVal == emv_qrcode.GeneratePayload());
            var raw = emv_qrcode.RawData();
            Assert.That(qrcode_expected.RawData == emv_qrcode.RawData());
        }


        [Test]
        public void _05_EMVQR_without_Transaction_Amount()
        {
            var emv_qrcode = new MerchantEMVQR();

            emv_qrcode.SetPayloadFormatIndicator("01");
            emv_qrcode.SetPointOfInitiationMethod("11");
            emv_qrcode.SetMerchantCategoryCode("6016");
            emv_qrcode.SetTransactionCurrency("608");
            emv_qrcode.SetCountryCode("PH");
            emv_qrcode.SetMerchantName("PayMaya User");
            emv_qrcode.SetMerchantCity("Mandaluyong");
            emv_qrcode.SetCRC("75C3");

            var merchantAccountInformation = new MerchantAccountInformation();
            merchantAccountInformation.SetGloballyUniqueIdentifier("com.p2pqrpay");
            merchantAccountInformation.AddContextSpecificData("01", "PAPHPHM1XXX");
            merchantAccountInformation.AddContextSpecificData("02", "99964403");
            merchantAccountInformation.AddContextSpecificData("04", "09985903943");
            merchantAccountInformation.AddContextSpecificData("05", "+639985903943");

            emv_qrcode.AddMerchantAccountInformation("27", merchantAccountInformation);

            var qrcode_expected = QRCodesResults._02();
            Assert.That(emv_qrcode.Validate());
            Assert.That(qrcode_expected.StringVal == emv_qrcode.GeneratePayload());
            Assert.That(emv_qrcode.RawData() == qrcode_expected.RawData);
            Assert.That(emv_qrcode.Validate());
            string bin = emv_qrcode.ToBinary();
            Assert.That(qrcode_expected.BinaryData == emv_qrcode.ToBinary());
        }


        [Test]
        public void _06_EMVQR_with_Transaction_Amount()
        {

            var emv_qrcode = new MerchantEMVQR();

            emv_qrcode.SetPayloadFormatIndicator("01");
            emv_qrcode.SetPointOfInitiationMethod("11");
            emv_qrcode.SetMerchantCategoryCode("6016");
            emv_qrcode.SetTransactionCurrency("608");
            emv_qrcode.SetTransactionAmount("390.8");
            emv_qrcode.SetCountryCode("PH");
            emv_qrcode.SetMerchantName("PayMaya User");
            emv_qrcode.SetMerchantCity("Mandaluyong");
            emv_qrcode.SetCRC("75C3");

            var merchantAccountInformation = new MerchantAccountInformation();
            merchantAccountInformation.SetGloballyUniqueIdentifier("com.p2pqrpay");
            merchantAccountInformation.AddContextSpecificData("01", "PAPHPHM1XXX");
            merchantAccountInformation.AddContextSpecificData("02", "99964403");
            merchantAccountInformation.AddContextSpecificData("04", "09985903943");
            merchantAccountInformation.AddContextSpecificData("05", "+639985903943");

            emv_qrcode.AddMerchantAccountInformation("27", merchantAccountInformation);

            var qrcode_expected = QRCodesResults._03();
            Assert.That(emv_qrcode.Validate());
            Assert.That(qrcode_expected.StringVal == emv_qrcode.GeneratePayload());
            Assert.That(qrcode_expected.RawData == emv_qrcode.RawData());
            Assert.That(qrcode_expected.BinaryData == emv_qrcode.ToBinary());

        }


        [Test]
        public void _07_Parser_EMV_string_to_EMVQR_Object()
        {
            var emv_qrcode_expected = new MerchantEMVQR();

            emv_qrcode_expected.SetPayloadFormatIndicator("01");
            emv_qrcode_expected.SetPointOfInitiationMethod("11");
            emv_qrcode_expected.SetMerchantCategoryCode("6016");
            emv_qrcode_expected.SetTransactionCurrency("608");
            emv_qrcode_expected.SetTransactionAmount("390.8");
            emv_qrcode_expected.SetCountryCode("PH");
            emv_qrcode_expected.SetMerchantName("PayMaya User");
            emv_qrcode_expected.SetMerchantCity("Mandaluyong");
            emv_qrcode_expected.SetCRC("75C3");

            var merchantAccountInformation = new MerchantAccountInformation();
            merchantAccountInformation.SetGloballyUniqueIdentifier("com.p2pqrpay");
            merchantAccountInformation.AddContextSpecificData("01", "PAPHPHM1XXX");
            merchantAccountInformation.AddContextSpecificData("02", "99964403");
            merchantAccountInformation.AddContextSpecificData("04", "09985903943");
            merchantAccountInformation.AddContextSpecificData("05", "+639985903943");

            emv_qrcode_expected.AddMerchantAccountInformation("27", merchantAccountInformation);

            var qrcode = QRCodesResults._03();
            var emv_qrcode = MerchantParser.ToEMVQR(qrcode.StringVal);
            Assert.That(emv_qrcode.Validate());
            Assert.That(emv_qrcode_expected.GeneratePayload() == emv_qrcode.GeneratePayload());
        }


        [Test]
        public void _08_Parser_Test()
        {
            var emv_qrcode = MerchantParser.ToEMVQR(QRCodesResults._04().StringVal);
            var qr_code_expect = QRCodesResults._04();

            Assert.That(emv_qrcode.Validate());
            var binary = emv_qrcode.ToBinary();
            var payLoad = emv_qrcode.GeneratePayload();
            Assert.That(emv_qrcode.GeneratePayload() == qr_code_expect.StringVal);
            Assert.That(qr_code_expect.BinaryData == emv_qrcode.ToBinary());
        }
    }
}