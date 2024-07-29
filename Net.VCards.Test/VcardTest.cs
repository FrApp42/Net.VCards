using FrApp42.Net.VCards;
using FrApp42.Net.VCards.Types;
using FrApp42.Net.VCards.Serializers;

namespace Net.VCards.Test
{
    [TestClass]
    public class VcardTest
    {
        [TestMethod]
        public void Create()
        {
            VCard vcard = new VCard()
            {
                Version = VCardVersion.V4,
                FormattedName = "John Doe",
                FirstName = "John",
                LastName = "Doe",
                Classification = ClassificationType.Confidential,
                Categories = new[] { "Friend", "Fella", "Amsterdam" },
            };
        }

        [TestMethod]
        public void Export()
        {
            VCard vcard = new VCard()
            {
                Version = VCardVersion.V4,
                FormattedName = "John Doe",
                FirstName = "John",
                LastName = "Doe",
                Classification = ClassificationType.Confidential,
                Categories = new[] { "Friend", "Fella", "Amsterdam" },
            };

            string serialized = vcard.Serialize();
            string path = Path.Combine(Path.GetTempPath(), "JohnDoe.vcf");
            File.WriteAllText(path, serialized);


            Assert.IsTrue(File.Exists(path), "File not found.");
            string fileContent = File.ReadAllText(path);
            Assert.AreEqual(serialized, fileContent, "Content value is not the same");
        }

        [TestCleanup]
        public void Clean()
        {
            string path = Path.Combine(Path.GetTempPath(), "JohnDoe.vcf");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}