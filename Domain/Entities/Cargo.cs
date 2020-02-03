using System;
using System.Collections.Generic;
using Domain.Entities.Persons;

namespace Domain.Entities
{
    public class Cargo
    {
        public Guid CargoId { get; set; }
        public virtual ICollection<Merchant> Merchants { get; set; }
        public virtual ICollection<Boat> Boats { get; set; }
        public int Silver { get; set; }
        public int Base { get; set; }
        public int Luxury { get; set; }
        public int Wood { get; set; }
        public int Iron { get; set; }
        public int Stone { get; set; }
        public int Other { get; set; }
        public string OtherInformation { get; set; }
    }
}