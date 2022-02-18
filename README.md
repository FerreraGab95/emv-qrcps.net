### This library is a port of the steplix/emv-qrcps [library](https://github.com/steplix/emv-qrcps#readme) library which is a fork of Emmanuel Kiametis [library](https://www.npmjs.com/package/emv-qrcps) to the .NET platform. Basically the implementation is the same, so the tutorial below has been copied and adapted for use in C#.

This library was made to help people that to generate and parse EMV QRcode according with the specifications:

- Merchant [Specification](https://www.emvco.com/wp-content/plugins/pmpro-customizations/oy-getfile.php?u=/wp-content/uploads/documents/EMVCo-Merchant-Presented-QR-Specification-v1-1.pdf)
- Consumer [Specification](https://www.emvco.com/wp-content/plugins/pmpro-customizations/oy-getfile.php?u=/wp-content/uploads/documents/EMVCo-Consumer-Presented-QR-Specification-v1-1.pdf) 

# Modules

There are 2 modules in this library.

- Merchant - To work with QRCode according with the `Merchant Specification`.
- Consumer - To work with QRCode according with the `Consumer Specification`.

## Merchant Module

You can use this Module by importing:

```
using emv_qrcps.QrCode.Merchant;
```

### Instances

#### TLV

```
TLV tlv = new TLV(tag, length, value);
```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `tag` | Payload Format Indicator | **string** |
| `length` | Point of Initiation Method | **int** |
| `value` | Merchant Account Information | **string** |

| `TLV` | It means an object that stores a **Tag** + **Lenght** + **Value**. |

#### EMVQR

```
EMVQR emvqr = new EMVQR();

// ... OR

EMVQR emvq = new EMVQR()
(
    payloadFormatIndicator,
    pointOfInitiationMethod,
    merchantAccountInformation,
    merchantCategoryCode,
    transactionCurrency,
    transactionAmount,
    tipOrConvenienceIndicator,
    valueOfConvenienceFeeFixed,
    valueOfConvenienceFeePercentage,
    countryCode,
    merchantName,
    merchantCity,
    postalCode,
    additionalDataFieldTemplate,
    crc,
    merchantInformationLanguageTemplate,
    rfuForEMVCo,
    unreservedTemplates,
);
```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `payloadFormatIndicator` | Payload Format Indicator | **TLV** |
| `pointOfInitiationMethod` | Point of Initiation Method | **TLV** |
| `merchantAccountInformation` | Merchant Account Information | **Dictionary<string, MerchantAccountInformation>** |
| `merchantCategoryCode` | Merchant Category Code | **TLV** |
| `transactionCurrency` | Transaction Currency | **TLV** |
| `transactionAmount` | Transaction Amount | **TLV** |
| `tipOrConvenienceIndicator` | Tip or Convenience Indicator | **TLV** |
| `valueOfConvenienceFeeFixed` | Value of Convenience Fee Fixed | **TLV** |
| `valueOfConvenienceFeePercentage` | Value of Convenience Fee Percentage | **TLV** |
| `countryCode` | Country Code | **TLV** |
| `merchantName` | Merchant Name | **TLV** |
| `merchantCity` | Merchant City | **TLV** |
| `postalCode` | Postal Code | **TLV** |
| `additionalDataFieldTemplate` | Additional Data Field Template | **AdditionalDataFieldTemplate** |
| `crc` | CRC | **TLV** |
| `merchantInformationLanguageTemplate` | Merchant Information - Language Template | **MerchantInformationLanguageTemplate** |
| `rfuForEMVCo` | RFU for EMVCo | **TLV[]** |
| `unreservedTemplates` | Unreserved Templates | **Dictionary<string, UnreservedTemplate>** |

| Return Type | Description |
| ------ | ------ |
| `EMVQR` | It means an object that represents an EMV QRCode. |

#### AdditionalDataFieldTemplate

```
AdditionalDataFieldTemplate additionalDataFieldTemplate = new AdditionalDataFieldTemplate();

// ... OR

AdditionalDataFieldTemplate additionalDataFieldTemplate = new AdditionalDataFieldTemplate
(
    billNumber,
    mobileNumber,
    storeLabel,
    loyaltyNumber,
    referenceLabel,
    customerLabel,
    terminalLabel,
    purposeTransaction,
    additionalConsumerDataRequest,
    rfuForEMVCo,
    paymentSystemSpecific
);
```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `billNumber` | Bill Number | **TLV** |
| `mobileNumber` | Country Code | **TLV** |
| `storeLabel` | Store Label | **TLV** |
| `loyaltyNumber` | Loyalty Number | **TLV** |
| `referenceLabel` | Reference Label | **TLV** |
| `customerLabel` | Customer Label | **TLV** |
| `terminalLabel` | Terminal Label | **TLV** |
| `purposeTransaction` | Purpose of Transaction | **TLV** |
| `additionalConsumerDataRequest` | Additional Consumer Data Request | **TLV** |
| `rfuForEMVCo` | RFU for EMVCo | **TLV[]** |
| `paymentSystemSpecific` | Payment System specific templates | **Dictionary<string, PaymentSystemSpecific>** |

| Return Type | Description |
| ------ | ------ |
| `AdditionalDataFieldTemplate` | It means an object that represents an additional data field template. |

#### MerchantInformationLanguageTemplate

```
MerchantInformationLanguageTemplate merchantInformationLanguageTemplate = new MerchantInformationLanguageTemplate();

// ... OR

MerchantInformationLanguageTemplate merchantInformationLanguageTemplate = new MerchantInformationLanguageTemplate
(
    languagePreference,
    merchantName,
    merchantCity,
    rfuForEMVCo,
);
```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `languagePreference` | Language Preference | **TLV** |
| `merchantName` | Name of the merchant | **TLV** |
| `merchantCity` | Name of the marchant city | **TLV** |
| `rfuForEMVCo` | RFU for EMVCo | **TLV[]** |

| Return Type | Description |
| ------ | ------ |
| `MerchantInformationLanguageTemplate` | It means an object that represents a merchant information language template. |

#### MerchantAccountInformation

```
MerchantAccountInformation merchantAccountInformation = new MerchantAccountInformation();

// ... OR

MerchantAccountInformation merchantAccountInformation = new MerchantAccountInformation(
    globallyUniqueIdentifier,
    paymentNetworkSpecific,
);
```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `globallyUniqueIdentifier` | Globally unique identifier | **TLV** |
| `paymentNetworkSpecific` | Array of payment network specific | **TLV[]** |

| Return Type | Description |
| ------ | ------ |
| `MerchantAccountInformation` | It means an object that represents a merchant account information. |

#### UnreservedTemplate

```
UnreservedTemplate unreservedTemplate =  new UnreservedTemplate();

// ... OR

UnreservedTemplate unreservedTemplate =  new UnreservedTemplate
(
    globallyUniqueIdentifier,
    paymentNetworkSpecific,
);
```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `globallyUniqueIdentifier` | Globally unique identifier | **TLV** |
| `contextSpecificData` | Array of context of specific data | **TLV[]** |

| Return Type | Description |
| ------ | ------ |
| `UnreservedTemplate` | It means an object that represents an unreserved template. |


### Object Types

#### TLV

Represents a **TAG** + **Length** + **Value**.

```
using emv_qrcps.QrCode.Merchant;

string tag = "01";
string value = "Example";
int length = value.Length;

TLV tlv = new TLV(tag, length, value);
```

##### Methods

###### ToString

```
string tlvStringFormat = TLV.ToString();
```


| Return Type | Description |
| ------ | ------ |
| `string` | TLV in string format |

###### DataWithType

```
string tlvBinaryFormat = TLV.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

string tlvRawFormat = TLV.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataType` | Data type value | **MerchantConsts.DATA_TYPE.`BINARY` \| MerchantConsts.DATA_TYPE.`RAW`** |
| `indent` | Indent character (Ex.: ' ') | **string** |

| Return Type | Description |
| ------ | ------ |
| `string` | TLV in binary OR raw data format |

#### MerchantAccountInformation

Represents a merchant account information.

```
using emv_qrcps.QrCode.Merchant;

MerchantAccountInformation merchantAccountInformation = new MerchantAccountInformation();
```

##### Methods

###### ToString

```
string merchantAccountInformationStringFormat = merchantAccountInformation.ToString();
```


| Return Type | Description |
| ------ | ------ |
| `string` | MerchantAccountInformation in TLV string format |

###### DataWithType

```
string merchantAccountInformationBinaryFormat = merchantAccountInformation.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

string merchantAccountInformationRawFormat = merchantAccountInformation.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataType` | Data type value | **MerchantConsts.DATA_TYPE.`BINARY` \| MerchantConsts.DATA_TYPE.`RAW`** |
| `indent` | Indent character (Ex.: ' ') | **string** |

| Return Type | Description |
| ------ | ------ |
| `string` | MerchantAccountInformation in TLV binary OR TLV raw data format |

###### SetGloballyUniqueIdentifier

```
string value = "15600000000";

merchantAccountInformation.SetGloballyUniqueIdentifier(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### AddPaymentNetworkSpecific ( Replaced by AddContextSpecificData)

```
string id = "03";
string value = "12345678";

//merchantAccountInformation.AddPaymentNetworkSpecific(id, value);
merchantAccountInformation.AddContextSpecificData(id, value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `id` | Tag ID | **string** |
| `value` | Some value | **string** |

#### MerchantInformationLanguageTemplate

Represents a merchant information language template.

```
using emv_qrcps.QrCode.Merchant;

MerchantInformationLanguageTemplate merchantInformationLanguageTemplate = new MerchantInformationLanguageTemplate();
```

##### Methods

###### ToString

```
string merchantInformationLanguageTemplateStringFormat = merchantInformationLanguageTemplate.ToString();
```


| Return Type | Description |
| ------ | ------ |
| `string` | MerchantInformationLanguageTemplate in TLV string format |

###### DataWithType

```
string merchantInformationLanguageTemplateBinaryFormat = merchantInformationLanguageTemplate.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

string merchantInformationLanguageTemplateRawFormat = merchantInformationLanguageTemplate.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataType` | Data type value | **MerchantConsts.DATA_TYPE.`BINARY` \| MerchantConsts.DATA_TYPE.`RAW`** |
| `indent` | Indent character (Ex.: ' ') | **string** |

| Return Type | Description |
| ------ | ------ |
| `string` | MerchantInformationLanguageTemplate in TLV binary OR TLV raw data format |

###### Validate

```
bool isValid = merchantInformationLanguageTemplate.Validate();
```

| Return Type | Description |
| ------ | ------ |
| `boolean` | True if required properties is valid otherwise throw an Error |

###### SetLanguagePreference

```
string value = "PT";

merchantInformationLanguageTemplate.SetLanguagePreference(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### SetMerchantName

```
string value = "Merchant Organization";

merchantInformationLanguageTemplate.SetMerchantName(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### SetMerchantCity

```
string value = "Brasilia";

merchantInformationLanguageTemplate.SetMerchantCity(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### AddRFUforEMVCo

```
string id = "03";
string value = "12345678";

merchantInformationLanguageTemplate.AddRFUforEMVCo(id, value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `id` | Tag ID | **string** |
| `value` | Some value | **string** |

#### UnreservedTemplate

Represents a merchant account information.

```
using emv_qrcps.QrCode.Merchant;

UnreservedTemplate unreservedTemplate = new UnreservedTemplate();
```

##### Methods

###### ToString

```
string unreservedTemplateStringFormat = unreservedTemplate.ToString();
```


| Return Type | Description |
| ------ | ------ |
| `string` | UnreservedTemplate in TLV string format |

###### DataWithType

```
string unreservedTemplateBinaryFormat = unreservedTemplate.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

string unreservedTemplateRawFormat = unreservedTemplate.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataType` | Data type value | **MerchantConsts.DATA_TYPE.`BINARY` \| MerchantConsts.DATA_TYPE.`RAW`** |
| `indent` | Indent character (Ex.: ' ') | **string** |

| Return Type | Description |
| ------ | ------ |
| `string` | UnreservedTemplate in TLV binary OR TLV raw data format |

###### SetGloballyUniqueIdentifier

```
string value = "15600000000";

unreservedTemplate.SetGloballyUniqueIdentifier(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### AddContextSpecificData

```
const id = "03";
const value = "12345678";

unreservedTemplate.AddContextSpecificData(id, value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `id` | Tag ID | **string** |
| `value` | Some value | **string** |

#### PaymentSystemSpecific

Represents a payment system specific.

```
using emv_qrcps.QrCode.Merchant;

PaymentSystemSpecific paymentSystemSpecific = new PaymentSystemSpecific();
```

##### Methods

###### ToString

```
string paymentSystemSpecificStringFormat = paymentSystemSpecific.ToString();
```


| Return Type | Description |
| ------ | ------ |
| `string` | PaymentSystemSpecific in TLV string format |

###### DataWithType

```
string paymentSystemSpecificBinaryFormat = paymentSystemSpecific.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

string paymentSystemSpecificRawFormat = paymentSystemSpecific.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataType` | Data type value | **MerchantConsts.DATA_TYPE.`BINARY` \| MerchantConsts.DATA_TYPE.`RAW`** |
| `indent` | Indent character (Ex.: ' ') | **string** |

| Return Type | Description |
| ------ | ------ |
| `string` | PaymentSystemSpecific in TLV binary OR TLV raw data format |

###### SetGloballyUniqueIdentifier

```
string value = "15600000000";

paymentSystemSpecific.SetGloballyUniqueIdentifier(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### AddPaymentSystemSpecific ( Replaced by AddContextSpecificData)

```
string id = "03";
string value = "12345678";

paymentSystemSpecific.AddContextSpecificData(id, value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `id` | Tag ID | **string** |
| `value` | Some value | **string** |

#### AdditionalDataFieldTemplate

Represents an additional data field template.

```
using emv_qrcps.QrCode.Merchant;

AdditionalDataFieldTemplate additionalDataFieldTemplate = new AdditionalDataFieldTemplate();
```

##### Methods

###### ToString

```
string additionalDataFieldTemplateStringFormat = additionalDataFieldTemplate.ToString();
```


| Return Type | Description |
| ------ | ------ |
| `string` | AdditionalDataFieldTemplate in TLV string format |

###### DataWithType

```
string additionalDataFieldTemplateBinaryFormat = additionalDataFieldTemplate.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

string additionalDataFieldTemplateRawFormat = additionalDataFieldTemplate.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataType` | Data type value | **MerchantConsts.DATA_TYPE.`BINARY` \| MerchantConsts.DATA_TYPE.`RAW`** |
| `indent` | Indent character (Ex.: ' ') | **string** |

| Return Type | Description |
| ------ | ------ |
| `string` | AdditionalDataFieldTemplate in TLV binary OR TLV raw data format |

###### SetBillNumber

```
string value = "34250";

additionalDataFieldTemplate.SetBillNumber(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetMobileNumber

```
string value = "+5561991112222";

additionalDataFieldTemplate.SetMobileNumber(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetStoreLabel

```
string value = "1234";

additionalDataFieldTemplate.SetStoreLabel(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetLoyaltyNumber

```
string value = "12345";

additionalDataFieldTemplate.SetLoyaltyNumber(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetReferenceLabel

```
string value = "example";

additionalDataFieldTemplate.SetReferenceLabel(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetCustomerLabel

```
string value = "***";

additionalDataFieldTemplate.SetCustomerLabel(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetTerminalLabel

```
string value = "A6008667";

additionalDataFieldTemplate.SetTerminalLabel(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetPurposeTransaction

```
string value = "Some purpose";

additionalDataFieldTemplate.SetPurposeTransaction(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetAdditionalConsumerDataRequest

```
string value = "ME";

additionalDataFieldTemplate.SetAdditionalConsumerDataRequest(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### AddRFUforEMVCo

```
string id = "03";
string value = "12345678";

additionalDataFieldTemplate.AddRFUforEMVCo(id, value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `id` | Tag ID | **string** |
| `value` | Some value | **string** |

###### AddPaymentSystemSpecific ( Replaced by AddContextSpecificData)

```
string id = "03";
string value = new PaymentSystemSpecific();
value.SetGloballyUniqueIdentifier("15600000000");
value.AddPaymentSystemSpecific("03", "12345678");

additionalDataFieldTemplate.AddContextSpecificData(id, value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `id` | Tag ID | **string** |
| `value` | Some value | **string** |

#### EMVQR

Represents an EMV QRCode.

```
using emv_qrcps.QrCode.Merchant;

string emvqr = new EMVQR();
```

##### Methods

###### GeneratePayload

```
string emvqrStringFormat = emvqr.GeneratePayload();
```


| Return Type | Description |
| ------ | ------ |
| `string` | EMV QRCode payload in string format. |

###### DataWithType

```
string emvqrBinaryFormat = emvqr.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

string emvqrRawFormat = emvqr.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataType` | Data type value | **MerchantConsts.DATA_TYPE.`BINARY` \| MerchantConsts.DATA_TYPE.`RAW`** |
| `indent` | Indent character (Ex.: ' ') | **string** |

| Return Type | Description |
| ------ | ------ |
| `string` | EMV QRCode in binary OR raw data format |

###### ToBinary

```
string emvqrBinaryFormat = emvqr.ToBinary(); // Binary Data (shown as hex bytes)
```

| Return Type | Description |
| ------ | ------ |
| `string` | EMV QRCode in binary format |

###### RawData

```
string emvqrBinaryFormat = emvqr.RawData(); // Raw Data
```

| Return Type | Description |
| ------ | ------ |
| `string` | EMV QRCode in raw data format |

###### Validate

```
bool isValid = emvqr.Validate();
```

| Return Type | Description |
| ------ | ------ |
| `boolean` | True if required properties is valid otherwise throw an Error |

###### SetPayloadFormatIndicator

```
string value = "01";

emvqr.SetPayloadFormatIndicator(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetPointOfInitiationMethod

```
string value = "00";

emvqr.setPointOfInitiationMethod(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetMerchantCategoryCode

```
string value = "Technology";

emvqr.setMerchantCategoryCode(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetTransactionCurrency

```
string value = "BRL";

emvqr.SetTransactionCurrency(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetTransactionAmount

```
string value = "20.5";

emvqr.SetTransactionAmount(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetTipOrConvenienceIndicator

```
string value = "2";

emvqr.SetTipOrConvenienceIndicator(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetValueOfConvenienceFeeFixed

```
string value = "2.00";

emvqr.SetValueOfConvenienceFeeFixed(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetValueOfConvenienceFeePercentage

```
string value = "0.90";

emvqr.SetValueOfConvenienceFeePercentage(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetCountryCode

```
string value = "55";

emvqr.SetCountryCode(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### SetMerchantName

```
string value = "Merchant Organization";

emvqr.SetMerchantName(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### SetMerchantCity

```
string value = "Brasilia";

emvqr.SetMerchantCity(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### SetPostalCode

```
string value = "71715-000";

emvqr.SetPostalCode(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### SetCRC

```
string value = "AF35";

emvqr.SetCRC(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### SetAdditionalDataFieldTemplate

```
AdditionalDataFieldTemplate additionalDataFieldTemplate = new AdditionalDataFieldTemplate();
additionalDataFieldTemplate.SetStoreLabel("1234");
additionalDataFieldTemplate.SetCustomerLabel("***");
additionalDataFieldTemplate.SetTerminalLabel("A6008667");
additionalDataFieldTemplate.SetAdditionalConsumerDataRequest("ME");

emvqr.SetAdditionalDataFieldTemplate(additionalDataFieldTemplate);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `additionalDataFieldTemplate` | Some additional data field template | **AdditionalDataFieldTemplate** |

###### SetMerchantInformationLanguageTemplate

```
MerchantInformationLanguageTemplate merchantInformationLanguageTemplate = new MerchantInformationLanguageTemplate();
merchantInformationLanguageTemplate.SetLanguagePreference("PT");
merchantInformationLanguageTemplate.SetMerchantName("Merchant Organization");
merchantInformationLanguageTemplate.SetMerchantCity("Brasilia");
emvqr.SetMerchantInformationLanguageTemplate(merchantInformationLanguageTemplate);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `merchantInformationLanguageTemplate` | Some merchant information language template | **MerchantInformationLanguageTemplate** |

###### AddMerchantAccountInformation

```
string id = "27";

MerchantAccountInformation merchantAccountInformation = new MerchantAccountInformation();
merchantAccountInformation.SetGloballyUniqueIdentifier("com.p2pqrpay");
merchantAccountInformation.AddContextSpecificData("01", "PAPHPHM1XXX");
merchantAccountInformation.AddContextSpecificData("02", "99964403");
merchantAccountInformation.AddContextSpecificData("04", "09985903943");
merchantAccountInformation.AddContextSpecificData("05", "+639985903943");

emvqr.AddMerchantAccountInformation(id, merchantAccountInformation);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `id` | Tag ID | **string** |
| `value` | Some merchant account information | **string** |

###### AddUnreservedTemplates

```
string id = "80";

string unreservedTemplate = new UnreservedTemplate();
unreservedTemplate.SetGloballyUniqueIdentifier("A011223344998877");
unreservedTemplate.AddContextSpecificData("07", "12345678");

emvqr.AddUnreservedTemplates(id, unreservedTemplate);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `id` | Tag ID | **string** |
| `value` | Some unreserved template | **string** |

###### AddRFUforEMVCo

```
const id = "03";
const value = "12345678";

emvqr.addRFUforEMVCo(id, value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `id` | Tag ID | **string** |
| `value` | Some value | **string** |


## Consumer Module

You can use this Module by importing:

```
const { Consumer } = require('steplix-emv-qrcps')
```

### Methods

#### buildBERTLV

```
const berTLV = Consumer.buildBERTLV();

// ... OR

const berTLV = Consumer.buildBERTLV(
    dataApplicationDefinitionFileName,
    dataApplicationLabel,
    dataTrack2EquivalentData,
    dataApplicationPAN,
    dataCardholderName,
    dataLanguagePreference,
    dataIssuerURL,
    dataApplicationVersionNumber,
    dataIssuerApplicationData,
    dataTokenRequestorID,
    dataPaymentAccountReference,
    dataLast4DigitsOfPAN,
    dataApplicationCryptogram,
    dataApplicationTransactionCounter,
    dataUnpredictableNumber
);

```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `dataApplicationDefinitionFileName` | Application Definition Name | **string(in-hex-decimal-format)** |
| `dataApplicationLabel` | Application Label | **string** |
| `dataTrack2EquivalentData` | Track to equivalent data | **string(in-hex-decimal-format)** |
| `dataApplicationPAN` | Application PAN | **string(in-hex-decimal-format)** |
| `dataCardholderName` | Cardholder Name | **string** |
| `dataLanguagePreference` | Language Preference | **string** |
| `dataIssuerURL` | Issuer URL | **string** |
| `dataApplicationVersionNumber` | Application Version Number | **string(in-hex-decimal-format)** |
| `dataIssuerApplicationData` | Issuer Application Data | **string(in-hex-decimal-format)** |
| `dataTokenRequestorID` | Token Requestor ID | **string(in-hex-decimal-format)** |
| `dataPaymentAccountReference` | Payment Account Reference | **string(in-hex-decimal-format)** |
| `dataLast4DigitsOfPAN` | Last 4 digits of PAN | **string(in-hex-decimal-format)** |
| `dataApplicationCryptogram` | Application Cryptogram | **string(in-hex-decimal-format)** |
| `dataApplicationTransactionCounter` | Application Transaction Counter | **string(in-hex-decimal-format)** |
| `dataUnpredictableNumber` | Unpredictable Number | **string(in-hex-decimal-format)** |

| Return Type | Description |
| ------ | ------ |
| `BERTLV` | It means the TLV Object of the consumer module. |

#### buildApplicationSpecificTransparentTemplate

```
const applicationSpecificTransparentTemplate = Consumer.buildApplicationSpecificTransparentTemplate();

// ... OR

const applicationSpecificTransparentTemplate = Consumer.buildApplicationSpecificTransparentTemplate(
	berTLV = BERTLV()
);


```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |

| Return Type | Description |
| ------ | ------ |
| `ApplicationSpecificTransparentTemplate` | It means an object that stores an application specific transparent template. |

#### buildApplicationTemplate

```
const applicationTemplate = Consumer.buildApplicationTemplate();

// ... OR

const applicationTemplate = Consumer.buildApplicationTemplate(
	berTLV = BERTLV(),
	applicationSpecificTransparentTemplates = []
);


```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |
| `applicationSpecificTransparentTemplates` | Application specific transparent templates | **array (ApplicationSpecificTransparentTemplate)** |

| Return Type | Description |
| ------ | ------ |
| `ApplicationTemplate` | It means an object that stores an application template. |

#### buildCommonDataTransparentTemplate

```
const commonDataTransparentTemplate = Consumer.buildCommonDataTransparentTemplate();

// ... OR

const commonDataTransparentTemplate = Consumer.buildCommonDataTransparentTemplate(
    berTLV = BERTLV()
);

```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |

| Return Type | Description |
| ------ | ------ |
| `CommonDataTransparentTemplate` | It means an object that stores a common data transparent template. |

#### buildCommonDataTemplate

```
const commonDataTemplate = Consumer.buildCommonDataTemplate();

// ... OR

const commonDataTemplate = Consumer.buildCommonDataTemplate(
    berTLV = BERTLV(),
	commonDataTransparentTemplates = [] 
);

```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |
| `commonDataTransparentTemplates` | Common data transparent templates | **array (CommonDataTransparentTemplate)** |

| Return Type | Description |
| ------ | ------ |
| `CommonDataTemplate` | It means an object that stores a common data template. |

#### buildEMVQR

```
const EMVQR = Consumer.buildEMVQR();

// ... OR

const EMVQR = Consumer.buildEMVQR(
    dataPayloadFormatIndicator,
    applicationTemplates,
    commonDataTemplates
);
```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `dataPayloadFormatIndicator` | Payload Format Indicator | **string** |
| `applicationTemplates` | Application Templates | **array [ ApplicationTemplate ]** |
| `commonDataTemplates` | Common Data templates | **array [ CommonDataTemplate ]** |

| Return Type | Description |
| ------ | ------ |
| `EMVQR` | It means an object that represents an EMV QRCode. |


### Object Types

#### BERTLV

Represents a **Basic Encoding Rules** **TAG** + **Length** + **Value**.

```
const { Consumer } = require('steplix-emv-qrcps');
const { MerchantConsts } = Merchant;

const berTLV = Merchant.buildBERTLV();
```

##### Methods

###### setDataApplicationDefinitionFileName

```
berTLV.setDataApplicationDefinitionFileName("A0000000555555");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataApplicationDefinitionFileName` | Application Definition File (ADF) Name | **string(in-hex-decimal-format)** |

###### setDataApplicationLabel

```
berTLV.setDataApplicationLabel("Product1");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `setDataApplicationLabel` | Application Label | **string** |

###### setDataTrack2EquivalentData

```
berTLV.setDataTrack2EquivalentData("AABBCCDD");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataTrack2EquivalentData` | Track 2 Equivalent Data | **string(in-hex-decimal-format)** |

###### setDataApplicationPAN

```
berTLV.setDataApplicationPAN("1234567890123458");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataApplicationPAN` | Application PAN | **string(in-hex-decimal-format)** |

###### setDataCardholderName

```
berTLV.setDataCardholderName("CARDHOLDER/EMV");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataCardholderName` | Cardholder Name | **string** |

###### setDataLanguagePreference

```
berTLV.setDataLanguagePreference("ruesdeen");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataLanguagePreference` | Language Preference | **string** |

###### setDataIssuerURL

```
berTLV.setDataIssuerURL("http://someuri.com");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataIssuerURL` | Issuer URL | **string** |

###### setDataApplicationVersionNumber

```
berTLV.setDataApplicationVersionNumber("04");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataApplicationVersionNumber` | Application Version Number | **string(in-hex-decimal-format)** |

###### setDataIssuerApplicationData

```
berTLV.setDataIssuerApplicationData("06010A03000000");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataIssuerApplicationData` | Issuer application data | **string(in-hex-decimal-format)** |

###### setDataTokenRequestorID

```
berTLV.setDataTokenRequestorID("0601AABBCC");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataTokenRequestorID` | Token Requestor ID | **string(in-hex-decimal-format)** |

###### setDataPaymentAccountReference

```
berTLV.setDataPaymentAccountReference("0708AABBCCDD");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataPaymentAccountReference` | Payment Account Reference | **string(in-hex-decimal-format)** |

###### setDataLast4DigitsOfPAN

```
berTLV.setDataLast4DigitsOfPAN("07080201");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataLast4DigitsOfPAN` | Last 4 Digits of PAN | **string(in-hex-decimal-format)** |

###### setDataApplicationCryptogram

```
berTLV.setDataApplicationCryptogram("584FD385FA234BCC");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataApplicationCryptogram` | Application Cryptogram | **string(in-hex-decimal-format)** |

###### setDataApplicationTransactionCounter

```
berTLV.setDataApplicationTransactionCounter("0001");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataApplicationTransactionCounter` | Application Transaction Counter | **string(in-hex-decimal-format)** |

###### setDataUnpredictableNumber

```
berTLV.setDataUnpredictableNumber("6D58EF13");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataUnpredictableNumber` | Unpredictable Number | **string(in-hex-decimal-format)** |

###### format

```
berTLV.format();
```


| Return Type | Description |
| ------ | ------ |
| `string` | BERTLV in string format |

###### DataWithType

```
const berTlvBinaryFormat = berTLV.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

const berTlvRawFormat = berTLV.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataType` | Data type value | **MerchantConsts.DATA_TYPE.`BINARY` \| MerchantConsts.DATA_TYPE.`RAW`** |
| `indent` | Indent character (Ex.: ' ') | **string** |

| Return Type | Description |
| ------ | ------ |
| `string` | BERTLV in binary OR raw data format |

#### ApplicationSpecificTransparentTemplate

Represents an application specific transparent template.

```
const { Consumer } = require('steplix-emv-qrcps');
const { MerchantConsts } = Consumer;

const applicationSpecificTransparentTemplate = Consumer.buildApplicationSpecificTransparentTemplate();
```

##### Methods

###### setBERTLV

```
const berTLV = Consumer.buildBERTLV();

// Setters assignments in berTLV

applicationSpecificTransparentTemplate.setBERTLV(berTLV);
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |

###### format

```
applicationSpecificTransparentTemplate.format();
```


| Return Type | Description |
| ------ | ------ |
| `string` | ApplicationSpecificTransparentTemplate in string format |

###### DataWithType

```
const binaryFormat = applicationSpecificTransparentTemplate.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

const rawFormat = applicationSpecificTransparentTemplate.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataType` | Data type value | **MerchantConsts.DATA_TYPE.`BINARY` \| MerchantConsts.DATA_TYPE.`RAW`** |
| `indent` | Indent character (Ex.: ' ') | **string** |

| Return Type | Description |
| ------ | ------ |
| `string` | Application specific transparent template in binary OR raw data format |

#### CommonDataTransparentTemplate

Represents a common data transparent template.

```
const { Consumer } = require('steplix-emv-qrcps');
const { MerchantConsts } = Consumer;

const commonDataTransparentTemplate = Consumer.buildCommonDataTransparentTemplate();
```

##### Methods

###### setBERTLV

```
const berTLV = Consumer.buildBERTLV();

// Setters assignments in berTLV

commonDataTransparentTemplate.setBERTLV(berTLV);
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |

###### format

```
commonDataTransparentTemplate.format();
```


| Return Type | Description |
| ------ | ------ |
| `string` | CommonDataTransparentTemplate in string format |

###### DataWithType

```
const binaryFormat = commonDataTransparentTemplate.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

const rawFormat = commonDataTransparentTemplate.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataType` | Data type value | **MerchantConsts.DATA_TYPE.`BINARY` \| MerchantConsts.DATA_TYPE.`RAW`** |
| `indent` | Indent character (Ex.: ' ') | **string** |

| Return Type | Description |
| ------ | ------ |
| `string` | Common data transparent template in binary OR raw data format |

#### ApplicationTemplate

Represents an application template.

```
const { Consumer } = require('steplix-emv-qrcps');
const { MerchantConsts } = Consumer;

const applicationTemplate = Consumer.buildApplicationTemplate();
```

##### Methods

###### setBERTLV

```
const berTLV = Consumer.buildBERTLV();

// Setters assignments in berTLV

applicationTemplate.setBERTLV(berTLV);
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |

###### addApplicationSpecificTransparentTemplate

```
const applicationSpecificTransparentTemplate = Consumer.buildApplicationSpecificTransparentTemplate();

const berTLV1 = Consumer.buildBERTLV();
berTLV1.setDataApplicationDefinitionFileName("A0000000555555");
berTLV1.setDataApplicationLabel("Product1");
applicationSpecificTransparentTemplate.setBERTLV(berTLV1);

applicationTemplate.addApplicationSpecificTransparentTemplate(applicationSpecificTransparentTemplate);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `applicationSpecificTransparentTemplate` | An application specific transparent template | **ApplicationSpecificTransparentTemplate** |

###### format

```
applicationTemplate.format();
```


| Return Type | Description |
| ------ | ------ |
| `string` | ApplicationTemplate in string format |

###### DataWithType

```
const binaryFormat = applicationTemplate.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

const rawFormat = applicationTemplate.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataType` | Data type value | **MerchantConsts.DATA_TYPE.`BINARY` \| MerchantConsts.DATA_TYPE.`RAW`** |
| `indent` | Indent character (Ex.: ' ') | **string** |

| Return Type | Description |
| ------ | ------ |
| `string` | Common data transparent template in binary OR raw data format |

#### CommonDataTemplate

Represents a common data template.

```
const { Consumer } = require('steplix-emv-qrcps');
const { MerchantConsts } = Consumer;

const commonDataTemplate = Consumer.buildCommonDataTemplate();
```

##### Methods

###### setBERTLV

```
const berTLV = Consumer.buildBERTLV();

// Setters assignments in berTLV

commonDataTemplate.setBERTLV(berTLV);
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |

###### addCommonDataTransparentTemplate

```
const commonDataTransparentTemplate = Consumer.buildCommonDataTransparentTemplate();

const berTLV = Consumer.buildBERTLV();
berTLV.setDataIssuerApplicationData("06010A03000000");
berTLV.setDataApplicationCryptogram("584FD385FA234BCC");
berTLV.setDataApplicationTransactionCounter("0001");
berTLV.setDataUnpredictableNumber("6D58EF13");
commonDataTransparentTemplate.setBERTLV(berTLV);

commonDataTemplate.addCommonDataTransparentTemplate(commonDataTransparentTemplate);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `commonDataTransparentTemplate` | A common data transparent template | **CommonDataTransparentTemplate** |

###### format

```
commonDataTemplate.format();
```


| Return Type | Description |
| ------ | ------ |
| `string` | CommonDataTemplate in string format |

###### DataWithType

```
const binaryFormat = commonDataTemplate.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

const rawFormat = commonDataTemplate.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataType` | Data type value | **MerchantConsts.DATA_TYPE.`BINARY` \| MerchantConsts.DATA_TYPE.`RAW`** |
| `indent` | Indent character (Ex.: ' ') | **string** |

| Return Type | Description |
| ------ | ------ |
| `string` | Common data transparent template in binary OR raw data format |

#### EMVQR

Represents an EMV QRCode.

```
const { Consumer } = require('steplix-emv-qrcps');
const { MerchantConsts } = Consumer;

const emvqr = Consumer.buildEMVQR();
```

##### Methods

###### setDataPayloadFormatIndicator

```
emvqr.setDataPayloadFormatIndicator("CPV01");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataPayloadFormatIndicator` | Payload Format Indicator | **string** |

###### addApplicationTemplate

```
const applicationTemplate1 = Consumer.buildApplicationTemplate();
const berTLV1 = Consumer.buildBERTLV();
berTLV1.setDataApplicationDefinitionFileName("A0000000555555");
berTLV1.setDataApplicationLabel("Product1");
applicationTemplate1.setBERTLV(berTLV1);

emvqr.addApplicationTemplate(applicationTemplate1);

const applicationTemplate2 = Consumer.buildApplicationTemplate();
const berTLV2 = Consumer.buildBERTLV();
berTLV2.setDataApplicationDefinitionFileName("A0000000666666");
berTLV2.setDataApplicationLabel("Product2");
applicationTemplate2.setBERTLV(berTLV2);

emvqr.addApplicationTemplate(applicationTemplate2);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `applicationTemplate` | An application template | **ApplicationTemplate** |

###### addCommonDataTemplate

```
const commonDataTemplate = Consumer.buildCommonDataTemplate();

const berTLV1 = Consumer.buildBERTLV();
berTLV1.setDataApplicationPAN("1234567890123458");
berTLV1.setDataCardholderName("CARDHOLDER/EMV");
berTLV1.setDataLanguagePreference("ruesdeen");
commonDataTemplate.setBERTLV(berTLV1);

const commonDataTransparentTemplate = Consumer.buildCommonDataTransparentTemplate();

const berTLV2 = Consumer.buildBERTLV();
berTLV2.setDataIssuerApplicationData("06010A03000000");
berTLV2.setDataApplicationCryptogram("584FD385FA234BCC");
berTLV2.setDataApplicationTransactionCounter("0001");
berTLV2.setDataUnpredictableNumber("6D58EF13");
commonDataTransparentTemplate.setBERTLV(berTLV2);

commonDataTemplate.addCommonDataTransparentTemplate(commonDataTransparentTemplate);

emvqr.addCommonDataTemplate(commonDataTemplate);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `commonDataTemplate` | A common data template | **CommonDataTemplate** |

###### generatePayload

```
commonDataTemplate.generatePayload();
```


| Return Type | Description |
| ------ | ------ |
| `string` | EMVQR in base64 string format |

###### ToBinary

```
const emvqrBinaryFormat = emvqr.ToBinary(); // Binary Data (shown as hex bytes)
```

| Return Type | Description |
| ------ | ------ |
| `string` | EMV QRCode in binary format |

###### rawData

```
const emvqrBinaryFormat = emvqr.rawData(); // Raw Data
```

| Return Type | Description |
| ------ | ------ |
| `string` | EMV QRCode in raw data format |
