using FrApp42.Net.VCards.Types;

namespace FrApp42.Net.VCards.Models
{
    public sealed class Language
    {
        public LanguageType Type { get; set; }
        public int Preference { get; set; }
        public string Name { get; set; }
    }
}
