﻿using FrApp42.Net.VCards.Models;
using FrApp42.Net.VCards.Serializers;

namespace FrApp42.Net.VCards.Processors
{
    public static class FormattedNameProcessor
    {
        public static string Serialize(VCard vcard)
        {
            return DefaultSerializer.GetVCardString("FN", vcard.FormattedName, true, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            vcard.FormattedName = token.Values[0];
        }
    }
}
