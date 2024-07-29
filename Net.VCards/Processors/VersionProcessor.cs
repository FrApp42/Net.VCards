using FrApp42.Net.VCards.Lookups;
using FrApp42.Net.VCards.Models;
using FrApp42.Net.VCards.Serializers;

namespace FrApp42.Net.VCards.Processors
{
    public static class VersionProcessor
    {
        public static string Serialize(VCard vcard)
        {
            return DefaultSerializer.GetVCardString("VERSION", vcard.Version.ToVCardString(), false, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            string version = token.Values[0];
            vcard.Version = VersionLookup.Parse(version);
        }
    }
}
