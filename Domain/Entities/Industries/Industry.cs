using System;

namespace Domain.Entities.Industries
{
    public abstract class Industry
    {
        public Guid IndustryId { get; set; }
        public Fief Fief { get; set; }
        #nullable enable
        public Assignment? Assignment { get; set; }
        public Guid? AssignmentId { get; set; }
        #nullable disable
        public string Name { get; set; }
        public string IndustryType { get; set; }
    }
}