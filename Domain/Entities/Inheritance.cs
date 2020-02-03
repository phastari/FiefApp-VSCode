using System;
using Domain.Entities.Types;

namespace Domain.Entities
{
    public class Inheritance
    {
        public Guid InheritanceId { get; set; }
        public InheritanceType InheritanceType { get; set; }
        public int InheritanceTypeId { get; set; }
        public virtual Fief Fief { get; set; }
    }
}