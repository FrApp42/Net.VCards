using FrApp42.Net.VCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrApp42.Net.VCards.Processors
{
    public static class BirthDayProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (vcard.BirthDay == null)
            {
                return string.Empty;
            }

            return DateTimeProcessor.Serialize(vcard.BirthDay, "BDAY", vcard.Version);
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            string value = token.Values[0];
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            var date = DateTimeProcessor.Parse(value);
            vcard.BirthDay = date;
        }
    }
}
