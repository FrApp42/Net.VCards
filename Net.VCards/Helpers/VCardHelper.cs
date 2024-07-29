using System.Text.RegularExpressions;

namespace FrApp42.Net.VCards.Helpers
{
    public static class VCardHelper
    {
        public static string[] SplitCards(string contents)
        {
            return Regex.Split(contents, "((BEGIN:VCARD)(.*)(END:VCARD))");
        }
    }
}
