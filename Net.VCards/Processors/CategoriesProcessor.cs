﻿using FrApp42.Net.VCards.Extensions;
using FrApp42.Net.VCards.Models;
using FrApp42.Net.VCards.Serializers;
using FrApp42.Net.VCards.Types;

namespace FrApp42.Net.VCards.Processors
{
    public static class CategoriesProcessor
    {
        public static string Serialize(VCard vcard)
        {
            //The property "CATEGORIES" is valid only for VCardVersion 3.0 and above.
            if (vcard.Version == VCardVersion.V2_1)
            {
                return string.Empty;
            }

            if (vcard.Categories == null || !vcard.Categories.Any())
            {
                return string.Empty;
            }

            string categories = string.Empty;

            if (vcard.Categories != null && vcard.Categories.Any())
            {
                categories = string.Join(",", vcard.Categories.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.Escape()));
            }

            if (string.IsNullOrWhiteSpace(categories))
            {
                return string.Empty;
            }

            return DefaultSerializer.GetVCardString("CATEGORIES", categories, false, vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            string categories = token.Values[0];
            if (string.IsNullOrWhiteSpace(categories))
            {
                return;
            }

            vcard.Categories = categories.Split(',');
        }
    }
}
