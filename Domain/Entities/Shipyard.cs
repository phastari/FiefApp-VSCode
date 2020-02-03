using System;
using System.Collections.Generic;
using Domain.Entities.Persons;

namespace Domain.Entities
{
    public class Shipyard
    {
        public Shipyard()
        {
            Boatbuilders = new HashSet<Boatbuilder>();
            Boats = new HashSet<Boat>();
        }

        public Guid ShipyardId { get; set; }
        #nullable enable
        public Assignment? Assignment { get; set; }
        public Guid? AssignmentId { get; set; }
        #nullable disable
        public Port Port { get; set; }
        public ICollection<Boatbuilder> Boatbuilders { get; set; }
        public ICollection<Boat> Boats { get; set; }
        public string Name { get; set; }
        public int DevelopmentLevel { get; set; }
        public bool IsBeingDeveloped { get; set; }
        public int IncomeSilver { get; set; }
        public int SmallDocks { get; set; }
        public int MediumDocks { get; set; }
        public int LargeDocks { get; set; }
        public int PopulationModifier { get; set; }
    }
}