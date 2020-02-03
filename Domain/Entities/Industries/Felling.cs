using System;

namespace Domain.Entities.Industries
{
    public class Felling : Industry
    {
        public int AmountLandclearing { get; set; }
        public int AmountLandclearingOfFelling { get; set; }
        public int AmountFelling { get; set; }
        public int AmountClearUseless { get; set; }
        public bool IsBeingDeveloped { get; set; }
        public Guid? DevelopmentId { get; set; }
    }
}