using System;

namespace Domain.Entities
{
    public class Village
    {
        public Guid VillageId { get; set; }
        public virtual Fief Fief { get; set; }
        public string Name { get; set; }
        public int Serfdoms { get; set; }
        public int Farmers { get; set; }
        public int Burgess { get; set; }
        public int Boatbuilders { get; set; }
        public int Tanners { get; set; }
        public int Millers { get; set; }
        public int Furriers { get; set; }
        public int Tailors { get; set; }
        public int Blacksmiths { get; set; }
        public int Carpenters { get; set; }
        public int Innkeepers { get; set; }
    }
}