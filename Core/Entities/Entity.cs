namespace Core.Entities
{
    public class Entity : EntityBase
    {
        public string Name { get; set; }
        public int RelatedEntityId { get; set; }
        public RelatedEntity RelatedEntity { get; set; }
    }
}