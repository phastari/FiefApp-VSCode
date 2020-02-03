using System;
using System.Collections.Generic;
using Domain.Entities.Types;

namespace Domain.Entities
{
    public class Livingcondition
    {
        public Guid LivingconditionId { get; set; }
        public LivingconditionType LivingconditionType { get; set; }
        public virtual Fief Fief { get; set; }
        public int LivingconditionTypeId { get; set; }
    }
}