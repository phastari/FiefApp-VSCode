using System;
using System.Collections.Generic;
using Domain.Entities.Types;

namespace Domain.Entities
{
    public class Livingcondition
    {
        public Guid LivingconditionId { get; set; }
        #nullable enable
        public LivingconditionType? LivingconditionType { get; set; }
        public int? LivingconditionTypeId { get; set; }
        #nullable disable
        public virtual Fief Fief { get; set; }
        public Guid FiefId { get; set; }
    }
}