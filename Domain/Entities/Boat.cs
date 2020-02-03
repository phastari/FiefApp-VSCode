using System;
using System.Collections.Generic;
using Domain.Entities.Persons;
using Domain.Entities.Types;

namespace Domain.Entities
{
    public class Boat
    {
        public Boat()
        {
            Soldiers = new HashSet<Soldier>();
        }

        public Guid BoatId { get; set; }
        public BoatType BoatType { get; set; }
        public int BoatTypeId { get; set; }
#nullable enable
        public Boatbuilder? Boatbuilder { get; set; }
        public Cargo? Cargo { get; set; }
        public Shipyard? Shipyard { get; set; }
#nullable disable
        public virtual Fief Fief { get; set; }
        public ICollection<Soldier> Soldiers { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }
        public int CrewNeeded { get; set; }
        public int Seamens { get; set; }
        public int Mariners { get; set; }
        public int Rowers { get; set; }
        public int RowersNeeded { get; set; }
        public int MaxCargo { get; set; }
        public int Sailors { get; set; }
        public int Officers { get; set; }
        public int Navigators { get; set; }
        public int Amount { get; set; }
        public int CostWhenFinishedSilver { get; set; }
        public int NextFinishedDays { get; set; }
        public int BuildTimeInDays { get; set; }
        public int BuildTimeInDaysAll { get; set; }
        public string Status { get; set; }
        public int BackIn { get; set; }
    }
}