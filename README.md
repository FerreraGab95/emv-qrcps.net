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

```csharp
using emv_qrcps.QrCode.Merchant;
```

### Instances

#### TLV

```csharp
TLV tlv = new TLV(tag, length, value);
```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `tag` | Payload Format Indicator | **string** |
| `length` | Point of Initiation Method | **int** |
| `value` | Merchant Account Information | **string** |

| `TLV` | It means an object that stores a **Tag** + **Lenght** + **Value**. |

#### MerchantEMVQR

```csharp
MerchantEMVQR emvqr = new MerchantEMVQR();

// ... OR

MerchantEMVQR emvq = new MerchantEMVQR()
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
| `MerchantEMVQR` | It means an object that represents an EMV QRCode. |

#### AdditionalDataFieldTemplate

```csharp
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

```csharp
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

```csharp
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

```csharp
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

```csharp
using emv_qrcps.QrCode.Merchant;

string tag = "01";
string value = "Example";
int length = value.Length;

TLV tlv = new TLV(tag, length, value);
```

##### Methods

###### ToString

```csharp
string tlvStringFormat = TLV.ToString();
```


| Return Type | Description |
| ------ | ------ |
| `string` | TLV in string format |

###### DataWithType

```csharp
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

```csharp
using emv_qrcps.QrCode.Merchant;

MerchantAccountInformation merchantAccountInformation = new MerchantAccountInformation();
```

##### Methods

###### ToString

```csharp
string merchantAccountInformationStringFormat = merchantAccountInformation.ToString();
```


| Return Type | Description |
| ------ | ------ |
| `string` | MerchantAccountInformation in TLV string format |

###### DataWithType

```csharp
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

```csharp
string value = "15600000000";

merchantAccountInformation.SetGloballyUniqueIdentifier(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### AddPaymentNetworkSpecific ( Replaced by AddContextSpecificData)

```csharp
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

```csharp
using emv_qrcps.QrCode.Merchant;

MerchantInformationLanguageTemplate merchantInformationLanguageTemplate = new MerchantInformationLanguageTemplate();
```

##### Methods

###### ToString

```csharp
string merchantInformationLanguageTemplateStringFormat = merchantInformationLanguageTemplate.ToString();
```


| Return Type | Description |
| ------ | ------ |
| `string` | MerchantInformationLanguageTemplate in TLV string format |

###### DataWithType

```csharp
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

```csharp
bool isValid = merchantInformationLanguageTemplate.Validate();
```

| Return Type | Description |
| ------ | ------ |
| `boolean` | True if required properties is valid otherwise throw an Error |

###### SetLanguagePreference

```csharp
string value = "PT";

merchantInformationLanguageTemplate.SetLanguagePreference(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### SetMerchantName

```csharp
string value = "Merchant Organization";

merchantInformationLanguageTemplate.SetMerchantName(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### SetMerchantCity

```csharp
string value = "Brasilia";

merchantInformationLanguageTemplate.SetMerchantCity(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### AddRFUforEMVCo

```csharp
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

```csharp
using emv_qrcps.QrCode.Merchant;

UnreservedTemplate unreservedTemplate = new UnreservedTemplate();
```

##### Methods

###### ToString

```csharp
string unreservedTemplateStringFormat = unreservedTemplate.ToString();
```


| Return Type | Description |
| ------ | ------ |
| `string` | UnreservedTemplate in TLV string format |

###### DataWithType

```csharp
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

```csharp
string value = "15600000000";

unreservedTemplate.SetGloballyUniqueIdentifier(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### AddContextSpecificData

```csharp
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

```csharp
using emv_qrcps.QrCode.Merchant;

PaymentSystemSpecific paymentSystemSpecific = new PaymentSystemSpecific();
```

##### Methods

###### ToString

```csharp
string paymentSystemSpecificStringFormat = paymentSystemSpecific.ToString();
```


| Return Type | Description |
| ------ | ------ |
| `string` | PaymentSystemSpecific in TLV string format |

###### DataWithType

```csharp
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

```csharp
string value = "15600000000";

paymentSystemSpecific.SetGloballyUniqueIdentifier(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### AddPaymentSystemSpecific ( Replaced by AddContextSpecificData)

```csharp
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

```csharp
using emv_qrcps.QrCode.Merchant;

AdditionalDataFieldTemplate additionalDataFieldTemplate = new AdditionalDataFieldTemplate();
```

##### Methods

###### ToString

```csharp
string additionalDataFieldTemplateStringFormat = additionalDataFieldTemplate.ToString();
```


| Return Type | Description |
| ------ | ------ |
| `string` | AdditionalDataFieldTemplate in TLV string format |

###### DataWithType

```csharp
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

```csharp
string value = "34250";

additionalDataFieldTemplate.SetBillNumber(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetMobileNumber

```csharp
string value = "+5561991112222";

additionalDataFieldTemplate.SetMobileNumber(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetStoreLabel

```csharp
string value = "1234";

additionalDataFieldTemplate.SetStoreLabel(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetLoyaltyNumber

```csharp
string value = "12345";

additionalDataFieldTemplate.SetLoyaltyNumber(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetReferenceLabel

```csharp
string value = "example";

additionalDataFieldTemplate.SetReferenceLabel(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetCustomerLabel

```csharp
string value = "***";

additionalDataFieldTemplate.SetCustomerLabel(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetTerminalLabel

```csharp
string value = "A6008667";

additionalDataFieldTemplate.SetTerminalLabel(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetPurposeTransaction

```csharp
string value = "Some purpose";

additionalDataFieldTemplate.SetPurposeTransaction(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetAdditionalConsumerDataRequest

```csharp
string value = "ME";

additionalDataFieldTemplate.SetAdditionalConsumerDataRequest(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### AddRFUforEMVCo

```csharp
string id = "03";
string value = "12345678";

additionalDataFieldTemplate.AddRFUforEMVCo(id, value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `id` | Tag ID | **string** |
| `value` | Some value | **string** |

###### AddPaymentSystemSpecific ( Replaced by AddContextSpecificData)

```csharp
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

#### MerchantEMVQR

Represents an EMV QRCode.

```csharp
using emv_qrcps.QrCode.Merchant;

string emvqr = new MerchantEMVQR();
```

##### Methods

###### GeneratePayload

```csharp
string emvqrStringFormat = emvqr.GeneratePayload();
```


| Return Type | Description |
| ------ | ------ |
| `string` | EMV QRCode payload in string format. |

###### DataWithType

```csharp
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

```csharp
string emvqrBinaryFormat = emvqr.ToBinary(); // Binary Data (shown as hex bytes)
```

| Return Type | Description |
| ------ | ------ |
| `string` | EMV QRCode in binary format |

###### RawData

```csharp
string emvqrBinaryFormat = emvqr.RawData(); // Raw Data
```

| Return Type | Description |
| ------ | ------ |
| `string` | EMV QRCode in raw data format |

###### Validate

```csharp
bool isValid = emvqr.Validate();
```

| Return Type | Description |
| ------ | ------ |
| `boolean` | True if required properties is valid otherwise throw an Error |

###### SetPayloadFormatIndicator

```csharp
string value = "01";

emvqr.SetPayloadFormatIndicator(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetPointOfInitiationMethod

```csharp
string value = "00";

emvqr.setPointOfInitiationMethod(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetMerchantCategoryCode

```csharp
string value = "Technology";

emvqr.setMerchantCategoryCode(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetTransactionCurrency

```csharp
string value = "BRL";

emvqr.SetTransactionCurrency(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetTransactionAmount

```csharp
string value = "20.5";

emvqr.SetTransactionAmount(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetTipOrConvenienceIndicator

```csharp
string value = "2";

emvqr.SetTipOrConvenienceIndicator(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetValueOfConvenienceFeeFixed

```csharp
string value = "2.00";

emvqr.SetValueOfConvenienceFeeFixed(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetValueOfConvenienceFeePercentage

```csharp
string value = "0.90";

emvqr.SetValueOfConvenienceFeePercentage(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |


###### SetCountryCode

```csharp
string value = "55";

emvqr.SetCountryCode(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### SetMerchantName

```csharp
string value = "Merchant Organization";

emvqr.SetMerchantName(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### SetMerchantCity

```csharp
string value = "Brasilia";

emvqr.SetMerchantCity(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### SetPostalCode

```csharp
string value = "71715-000";

emvqr.SetPostalCode(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### SetCRC

```csharp
string value = "AF35";

emvqr.SetCRC(value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `value` | Some value | **string** |

###### SetAdditionalDataFieldTemplate

```csharp
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

```csharp
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

```csharp
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

```csharp
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

```csharp
string id = "03";
string value = "12345678";

emvqr.AddRFUforEMVCo(id, value);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `id` | Tag ID | **string** |
| `value` | Some value | **string** |


## Consumer Module

You can use this Module by importing:

```csharp
using emv_qrcps.QrCode.Consumer;
```

### Instances

#### BERTLV

```csharp
BERTLV berTLV = new BERTLV();

// ... OR

BERTLV berTLV = new BERTLV(
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

#### ApplicationSpecificTransparentTemplate

```csharp
ApplicationSpecificTransparentTemplate applicationSpecificTransparentTemplate = new ApplicationSpecificTransparentTemplate();

// ... OR

ApplicationSpecificTransparentTemplate applicationSpecificTransparentTemplate = new ApplicationSpecificTransparentTemplate(
	berTLV = BERTLV()
);


```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |

| Return Type | Description |
| ------ | ------ |
| `ApplicationSpecificTransparentTemplate` | It means an object that stores an application specific transparent template. |

#### ApplicationTemplate

```csharp
ApplicationTemplate applicationTemplate = new ApplicationTemplate();

// ... OR

ApplicationTemplate applicationTemplate = new ApplicationTemplate(
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

#### CommonDataTransparentTemplate

```csharp
CommonDataTransparentTemplate commonDataTransparentTemplate = new CommonDataTransparentTemplate();

// ... OR

CommonDataTransparentTemplate commonDataTransparentTemplate = new CommonDataTransparentTemplate(
    berTLV = BERTLV()
);

```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |

| Return Type | Description |
| ------ | ------ |
| `CommonDataTransparentTemplate` | It means an object that stores a common data transparent template. |

#### CommonDataTemplate

```csharp
CommonDataTemplate commonDataTemplate = new CommonDataTemplate();

// ... OR

CommonDataTemplate commonDataTemplate = new CommonDataTemplate(
    berTLV = BERTLV(),
	commonDataTransparentTemplates = [] 
);

```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |
| `commonDataTransparentTemplates` | Common data transparent templates | **AppTemplate[]** |

| Return Type | Description |
| ------ | ------ |
| `CommonDataTemplate` | It means an object that stores a common data template. |

#### ConsumerEMVQR

```csharp
ConsumerEMVQR emvqr = new ConsumerEMVQR();

// ... OR

ConsumerEMVQR emvqr = new ConsumerEMVQR(
    dataPayloadFormatIndicator,
    applicationTemplates,
    commonDataTemplates
);
```

| Parameter | Description | Type |
| ------ | ------ | ------ |
| `dataPayloadFormatIndicator` | Payload Format Indicator | **string** |
| `applicationTemplates` | Application Templates | **AppTemplate[]** |
| `commonDataTemplates` | Common Data templates | **CommonTemplate[]** |

| Return Type | Description |
| ------ | ------ |
| `ConsumerEMVQR` | It means an object that represents an EMV QRCode. |


### Object Types

#### BERTLV

Represents a **Basic Encoding Rules** **TAG** + **Length** + **Value**.

```csharp
using emv_qrcps.QrCode.Consumer;
using emv-qrcps.QrCode.Merchant;

BERTLV berTLV = new BERTLV();
```

##### Methods

###### SetDataApplicationDefinitionFileName

```csharp
berTLV.SetDataApplicationDefinitionFileName("A0000000555555");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataApplicationDefinitionFileName` | Application Definition File (ADF) Name | **string(in-hex-decimal-format)** |

###### SetDataApplicationLabel

```csharp
berTLV.SetDataApplicationLabel("Product1");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `SetDataApplicationLabel` | Application Label | **string** |

###### SetDataTrack2EquivalentData

```csharp
berTLV.SetDataTrack2EquivalentData("AABBCCDD");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataTrack2EquivalentData` | Track 2 Equivalent Data | **string(in-hex-decimal-format)** |

###### SetDataApplicationPAN

```csharp
berTLV.SetDataApplicationPAN("1234567890123458");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataApplicationPAN` | Application PAN | **string(in-hex-decimal-format)** |

###### SetDataCardholderName

```csharp
berTLV.SetDataCardholderName("CARDHOLDER/EMV");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataCardholderName` | Cardholder Name | **string** |

###### SetDataLanguagePreference

```csharp
berTLV.SetDataLanguagePreference("ruesdeen");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataLanguagePreference` | Language Preference | **string** |

###### SetDataIssuerURL

```csharp
berTLV.SetDataIssuerURL("http://someuri.com");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataIssuerURL` | Issuer URL | **string** |

###### SetDataApplicationVersionNumber

```csharp
berTLV.setDataApplicationVersionNumber("04");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataApplicationVersionNumber` | Application Version Number | **string(in-hex-decimal-format)** |

###### SetDataIssuerApplicationData

```csharp
berTLV.SetDataIssuerApplicationData("06010A03000000");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataIssuerApplicationData` | Issuer application data | **string(in-hex-decimal-format)** |

###### SetDataTokenRequestorID

```csharp
berTLV.SetDataTokenRequestorID("0601AABBCC");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataTokenRequestorID` | Token Requestor ID | **string(in-hex-decimal-format)** |

###### SetDataPaymentAccountReference

```csharp
berTLV.SetDataPaymentAccountReference("0708AABBCCDD");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataPaymentAccountReference` | Payment Account Reference | **string(in-hex-decimal-format)** |

###### SetDataLast4DigitsOfPAN

```csharp
berTLV.SetDataLast4DigitsOfPAN("07080201");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataLast4DigitsOfPAN` | Last 4 Digits of PAN | **string(in-hex-decimal-format)** |

###### SetDataApplicationCryptogram

```csharp
berTLV.SetDataApplicationCryptogram("584FD385FA234BCC");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataApplicationCryptogram` | Application Cryptogram | **string(in-hex-decimal-format)** |

###### SetDataApplicationTransactionCounter

```csharp
berTLV.SetDataApplicationTransactionCounter("0001");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataApplicationTransactionCounter` | Application Transaction Counter | **string(in-hex-decimal-format)** |

###### SetDataUnpredictableNumber

```csharp
berTLV.SetDataUnpredictableNumber("6D58EF13");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataUnpredictableNumber` | Unpredictable Number | **string(in-hex-decimal-format)** |

###### Format

```csharp
berTLV.Format();
```


| Return Type | Description |
| ------ | ------ |
| `string` | BERTLV in string format |

###### DataWithType

```csharp
string berTlvBinaryFormat = berTLV.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

string berTlvRawFormat = berTLV.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
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

```csharp
using emv_qrcps.QrCode.Consumer;
using emv_qrcps.QrCode.Merchant;

ApplicationSpecificTransparentTemplate applicationSpecificTransparentTemplate = new ApplicationSpecificTransparentTemplate();
```

##### Methods

###### SetBERTLV

```csharp
BERTLV berTLV = new BERTLV();

// Setters assignments in berTLV

applicationSpecificTransparentTemplate.SetBERTLV(berTLV);
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |

###### format

```csharp
applicationSpecificTransparentTemplate.Format();
```


| Return Type | Description |
| ------ | ------ |
| `string` | ApplicationSpecificTransparentTemplate in string format |

###### DataWithType

```csharp
string binaryFormat = applicationSpecificTransparentTemplate.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

string rawFormat = applicationSpecificTransparentTemplate.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
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

```csharp
using emv_qrcps.QrCode.Consumer;
using emv_qrcps.QrCode.Merchant;

CommonDataTransparentTemplate commonDataTransparentTemplate = new CommonDataTransparentTemplate();
```

##### Methods

###### SetBERTLV

```csharp
BERTLV berTLV = new BERTLV();

// Setters assignments in berTLV

commonDataTransparentTemplate.SetBERTLV(berTLV);
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |

###### Format

```csharp
commonDataTransparentTemplate.Format();
```


| Return Type | Description |
| ------ | ------ |
| `string` | CommonDataTransparentTemplate in string format |

###### DataWithType

```csharp
string binaryFormat = commonDataTransparentTemplate.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

string rawFormat = commonDataTransparentTemplate.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
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

```csharp
using emv_qrcps.QrCode.Consumer;
using emv_qrcps.QrCode.Merchant;

ApplicationTemplate applicationTemplate = new ApplicationTemplate();
```

##### Methods

###### SetBERTLV

```csharp
BERTLV berTLV = new BERTLV();

// Setters assignments in berTLV

applicationTemplate.SetBERTLV(berTLV);
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |

###### AddApplicationSpecificTransparentTemplate

```csharp
ApplicationSpecificTransparentTemplate applicationSpecificTransparentTemplate = Consumer.buildApplicationSpecificTransparentTemplate();

BERTLV berTLV1 = new BERTLV();
berTLV1.SetDataApplicationDefinitionFileName("A0000000555555");
berTLV1.SetDataApplicationLabel("Product1");
applicationSpecificTransparentTemplate.SetBERTLV(berTLV1);

applicationTemplate.AddApplicationSpecificTransparentTemplate(applicationSpecificTransparentTemplate);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `applicationSpecificTransparentTemplate` | An application specific transparent template | **ApplicationSpecificTransparentTemplate** |

###### format

```csharp
applicationTemplate.Format();
```


| Return Type | Description |
| ------ | ------ |
| `string` | ApplicationTemplate in string format |

###### DataWithType

```csharp
string binaryFormat = applicationTemplate.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

string rawFormat = applicationTemplate.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
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

```csharp
using emv_qrcps.QrCode.Consumer;
using emv_qrcps.QrCode.Merchant;

CommonDataTemplate commonDataTemplate = new CommonDataTemplate();
```

##### Methods

###### SetBERTLV

```csharp
BERTLV berTLV = new BERTLV();

// Setters assignments in berTLV

commonDataTemplate.SetBERTLV(berTLV);
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `berTLV` | BERTLV Object | **BERTLV** |

###### AddCommonDataTransparentTemplate (Replaced by AddCommonAppTemplate)

```csharp
CommonDataTransparentTemplate commonDataTransparentTemplate = new ommonDataTransparentTemplate();

BERTLV berTLV = new BERTLV();
berTLV.SetDataIssuerApplicationData("06010A03000000");
berTLV.SetDataApplicationCryptogram("584FD385FA234BCC");
berTLV.SetDataApplicationTransactionCounter("0001");
berTLV.SetDataUnpredictableNumber("6D58EF13");
commonDataTransparentTemplate.SetBERTLV(berTLV);

commonDataTemplate.AddCommonAppTemplate(commonDataTransparentTemplate);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `commonDataTransparentTemplate` | A common data transparent template | **CommonDataTransparentTemplate** |

###### Format

```csharp
commonDataTemplate.Format();
```


| Return Type | Description |
| ------ | ------ |
| `string` | CommonDataTemplate in string format |

###### DataWithType

```csharp
string binaryFormat = commonDataTemplate.DataWithType(MerchantConsts.DATA_TYPE.BINARY, ' '); // Binary Data (shown as hex bytes)

// OR

string rawFormat = commonDataTemplate.DataWithType(MerchantConsts.DATA_TYPE.RAW, ' '); // Raw Data
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataType` | Data type value | **MerchantConsts.DATA_TYPE.`BINARY` \| MerchantConsts.DATA_TYPE.`RAW`** |
| `indent` | Indent character (Ex.: ' ') | **string** |

| Return Type | Description |
| ------ | ------ |
| `string` | Common data transparent template in binary OR raw data format |

#### ConsumerEMVQR

Represents an EMV QRCode.

```csharp
using emv_qrcps.QrCode.Consumer;
using emv_qrcps.QrCode.Merchant;

ConsumerEMVQR emvqr = new ConsumerEMVQR();
```

##### Methods

###### SetDataPayloadFormatIndicator

```csharp
emvqr.SetDataPayloadFormatIndicator("CPV01");
```


| Parameters | Description | Type |
| ------ | ------ | ------ |
| `dataPayloadFormatIndicator` | Payload Format Indicator | **string** |

###### AddApplicationTemplate (Replaced by AddCommonAppTemplate)

```csharp
ApplicationTemplate applicationTemplate1 = new ApplicationTemplate();
BERTLV berTLV1 = new BERTLV();
berTLV1.SetDataApplicationDefinitionFileName("A0000000555555");
berTLV1.SetDataApplicationLabel("Product1");
applicationTemplate1.SetBERTLV(berTLV1);

emvqr.AddCommonAppTemplate(applicationTemplate1);

ApplicationTemplate applicationTemplate2 = new ApplicationTemplate();
BERTLV berTLV2 = new BERTLV();
berTLV2.SetDataApplicationDefinitionFileName("A0000000666666");
berTLV2.SetDataApplicationLabel("Product2");
applicationTemplate2.SetBERTLV(berTLV2);

emvqr.AddCommonAppTemplate(applicationTemplate2);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `applicationTemplate` | An application template | **ApplicationTemplate** |

###### AddCommonDataTemplate (Replaced by AddCommonAppTemplate)

```csharp
CommonDataTemplate commonDataTemplate = new CommonDataTemplate();

BERTLV berTLV1 = new BERTLV();
berTLV1.SetDataApplicationPAN("1234567890123458");
berTLV1.SetDataCardholderName("CARDHOLDER/EMV");
berTLV1.SetDataLanguagePreference("ruesdeen");
commonDataTemplate.SetBERTLV(berTLV1);

CommonDataTemplate commonDataTransparentTemplate = Consumer.buildCommonDataTransparentTemplate();

BERTLV berTLV2 = new BERTLV();
berTLV2.SetDataIssuerApplicationData("06010A03000000");
berTLV2.SetDataApplicationCryptogram("584FD385FA234BCC");
berTLV2.SetDataApplicationTransactionCounter("0001");
berTLV2.SetDataUnpredictableNumber("6D58EF13");
commonDataTransparentTemplate.SetBERTLV(berTLV2);

commonDataTemplate.AddCommonAppTemplate(commonDataTransparentTemplate);

emvqr.AddCommonAppTemplate(commonDataTemplate);
```

| Parameters | Description | Type |
| ------ | ------ | ------ |
| `commonDataTemplate` | A common data template | **CommonDataTemplate** |

###### GeneratePayload

```csharp
commonDataTemplate.GeneratePayload();
```


| Return Type | Description |
| ------ | ------ |
| `string` | ConsumerEMVQR in base64 string format |

###### ToBinary

```csharp
string emvqrBinaryFormat = emvqr.ToBinary(); // Binary Data (shown as hex bytes)
```

| Return Type | Description |
| ------ | ------ |
| `string` | EMV QRCode in binary format |

###### RawData

```csharp
string emvqrBinaryFormat = emvqr.rawData(); // Raw Data
```

| Return Type | Description |
| ------ | ------ |
| `string` | EMV QRCode in raw data format |
