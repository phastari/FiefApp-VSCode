using System;
using System.Collections.Generic;

namespace Domain.Entities.Types
{
    public class BoatType
    {
        public BoatType()
        {
            Boats = new HashSet<Boat>();
        }

        public int BoatTypeId { get; set; }
        public virtual ICollection<Boat> Boats { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public int Masts { get; set; }
        public int LengthMin { get; set; }
        public int LengthMax { get; set; }
        public decimal BL { get; set; }
        public decimal DB { get; set; }
        public decimal Crew { get; set; }
        public decimal Cargo { get; set; }
        public int BenchMod { get; set; }
        public decimal BenchMulti { get; set; }
        public int OarsMulti { get; set; }
        public int RowerMulti { get; set; }
        public string Seaworthiness { get; set; }
        public string ImgSource { get; set; }
    }
}