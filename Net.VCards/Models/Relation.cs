using FrApp42.Net.VCards.Types;

namespace FrApp42.Net.VCards.Models
{
    public sealed class Relation
    {
        public RelationType Type { get; set; }
        public int Preference { get; set; }
        public Uri RelationUri { get; set; }
    }
}
