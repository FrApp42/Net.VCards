# Basic Usage

**Create a vCard**

```csharp
var vcard = new VCard
{
    Version = VCardVersion.V4,
    FormattedName = "John Doe",
    FirstName = "John",
    LastName = "Doe",
    Classification = ClassificationType.Confidential,
    Categories = new[] {"Friend", "Fella", "Amsterdam"},
    //...
};
```
**Serialize a vCard and Save as a VCF File**

```
string serialized = vcard.Serialize();
string path = Path.Combine("C:\", "JohnDoe.vcf");
File.WriteAllText(path, serialized);
```