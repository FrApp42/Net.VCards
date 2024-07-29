using FrApp42.Net.VCards.Models;
using FrApp42.Net.VCards.Serializers;
using System.Text;

namespace FrApp42.Net.VCards.Processors
{
    public static class ExtensionsProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (vcard.CustomExtensions == null || vcard.CustomExtensions.Count() == 0)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            foreach (var extension in vcard.CustomExtensions)
            {
                var key = extension.Key;
                foreach (var value in extension.Values)
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        continue;
                    }

                    var vcardString = DefaultSerializer.GetVCardString(key, value, true, vcard.Version);
                    builder.Append(vcardString);
                }
            }

            return builder.ToString();
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            var key = token.Key;
            var extensions = (List<CustomExtension>)vcard.CustomExtensions ?? new List<CustomExtension>();

            var entry = extensions.FirstOrDefault(x => x.Key.Equals(key, System.StringComparison.OrdinalIgnoreCase));

            if (entry != null)
            {
                entry.Values = entry.Values.Union(token.Values);
            }
            else
            {
                extensions.Add(new CustomExtension
                {
                    Key = token.Key,
                    Values = token.Values
                });
            }

            vcard.CustomExtensions = extensions;
        }
    }
}
