using FrApp42.Net.VCards.Extensions;
using FrApp42.Net.VCards.Lookups;
using FrApp42.Net.VCards.Models;
using FrApp42.Net.VCards.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrApp42.Net.VCards.Processors
{
    public static class DeliveryAddressProcessor
    {
        public static string Serialize(VCard vcard)
        {
            if (vcard.DeliveryAddress == null)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            string type = vcard.DeliveryAddress.Type.ToVCardString();

            const string key = "LABEL";

            builder.Append(GroupProcessor.Serialize(key, vcard.Version, type, true, vcard.DeliveryAddress.Address.Escape()));

            return builder.ToString();
        }

        public static void Parse(Token token, ref VCard vcard)
        {
            var deliveryAddress = new DeliveryAddress();

            if (vcard.Version == VCardVersion.V4)
            {
                string address = token.Values[0];
                string type = token.AdditionalKeyMembers.FirstOrDefault(x => x.Key == "TYPE").Value;

                deliveryAddress.Address = address;
                deliveryAddress.Type = AddressTypeLookup.Parse(type);
            }

            vcard.DeliveryAddress = deliveryAddress;
        }
    }
}
