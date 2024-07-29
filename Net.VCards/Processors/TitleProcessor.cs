using FrApp42.Net.VCards.Models;
using FrApp42.Net.VCards.Serializers;

namespace FrApp42.Net.VCards.Processors
{
    public static class TitleProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (string.IsNullOrWhiteSpace(vcard.Title))
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("TITLE", vcard.Title, false, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Title = token.Values[0];
        }
    }
}
