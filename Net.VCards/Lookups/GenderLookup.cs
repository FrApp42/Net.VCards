using FrApp42.Net.VCards.Types;

namespace FrApp42.Net.VCards.Lookups
{
    public static class GenderLookup
    {
        private static readonly Dictionary<Gender, string> Lookup = new Dictionary<Gender, string>
        {
            {Gender.Female, "F"},
            {Gender.Male, "M"},
            {Gender.NotApplicable, "N"},
            {Gender.Other, "O"},
            {Gender.Unknown, "U"}
        };

        public static string ToVCardString(this Gender type)
        {
            return Lookup[type];
        }

        public static Gender Parse(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                return Gender.Unknown;
            }

            return Lookup.FirstOrDefault(x => string.Equals(x.Value, type, StringComparison.OrdinalIgnoreCase)).Key;
        }
    }
}
