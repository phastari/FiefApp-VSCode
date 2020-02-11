using System;

namespace Domain.Entities
{
    public class Development
    {
        public Guid DevelopmentId { get; set; }
        #nullable enable
        public virtual Assignment? Assignment { get; set; }
        public Guid? AssignmentId { get; set; }
        #nullable disable
    }
}