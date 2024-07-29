using FrApp42.Net.VCards.Processors;
using System.Text;

namespace FrApp42.Net.VCards.Serializers
{
    public static class V4Serializer
    {
        public static string Serialize(VCard vcard)
        {
            var builder = new StringBuilder();


            builder.Append(SourceUriProcessor.Serialize(vcard));
            builder.Append(KindProcessor.Serialize(vcard));
            builder.Append(AnniversaryProcessor.Serialize(vcard));
            builder.Append(GenderProcessor.Serialize(vcard));
            builder.Append(ImppsProcessor.Serialize(vcard));
            builder.Append(LanguagesProcessor.Serialize(vcard));
            builder.Append(RelationsProcessor.Serialize(vcard));
            builder.Append(CalendarUserAddressesProcessor.Serialize(vcard));
            builder.Append(CalendarAddressesProcessor.Serialize(vcard));

            return builder.ToString();
        }
    }
}
