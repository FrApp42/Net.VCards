using FrApp42.Net.VCards.Lookups;
using FrApp42.Net.VCards.Models;
using FrApp42.Net.VCards.Serializers;
using FrApp42.Net.VCards.Types;

namespace FrApp42.Net.VCards.Processors
{
    public static class KindProcessor
    {
        public static string Serialize(VCard vcard)
        {
            //Only vCard 4.0 supports KIND property
            if (vcard.Version != VCardVersion.V4)
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("KIND", vcard.Kind.ToVCardString(), true, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.Kind = KindLookup.Parse(token.Values[0]);
        }
    }
}
