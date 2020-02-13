using System;
using System.Collections.Generic;
using Domain.Entities.Industries;
using Domain.Entities.Persons;

namespace Domain.Entities
{
    public class Fief
    {
        public Fief()
        {
            Villages = new HashSet<Village>();
            Industries = new HashSet<Industry>();
            Residents = new HashSet<Resident>();
            Soldiers = new HashSet<Soldier>();
            Employees = new HashSet<Employee>();
            Builders = new HashSet<Builder>();
            Buildings = new HashSet<Building>();
            Boats = new HashSet<Boat>();
            Market = new Market();
            Port = null;
            Livingcondition = new Livingcondition { LivingconditionTypeId = 3 };
            Road = new Road { RoadTypeId = 2 };
            Inheritance = new Inheritance { InheritanceTypeId = 1 };
        }

        public Guid FiefId { get; set; }
        public virtual GameSession GameSession { get; set; }
        public Guid GameSessionId { get; set; }
        public virtual Market Market { get; set; }
    #nullable enable
        public virtual Assignment? Assignment { get; set; }
        public Guid? AssignmentId { get; set; }
        public virtual Port? Port { get; set; }
    #nullable disable
        public virtual Livingcondition Livingcondition { get; set; }
        public virtual Road Road { get; set; }
        public virtual Inheritance Inheritance { get; set; }
        public virtual ICollection<Village> Villages { get; set; }
        public virtual ICollection<Industry> Industries { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<Boat> Boats { get; set; }
        public virtual ICollection<Resident> Residents { get; set; }
        public virtual ICollection<Soldier> Soldiers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Builder> Builders { get; set; }
        public string Name { get; set; } = "";
        public int Acres { get; set; }
        public int FarmlandAcres { get; set; }
        public int PastureAcres { get; set; }
        public int WoodlandAcres { get; set; }
        public int FellingAcres { get; set; }
        public int UnusableAcres { get; set; }
        public int AnimalHusbandryQuality { get; set; }
        public int AgriculturalQuality { get; set; }
        public int FishingQuality { get; set; }
        public int OreQuality { get; set; }
        public int AnimalHusbandryDevelopmentLevel { get; set; }
        public int AgriculturalDevelopmentLevel { get; set; }
        public int FishingDevelopmentLevel { get; set; }
        public int WoodlandDevelopmentLevel { get; set; }
        public int OreDevelopmentLevel { get; set; }
        public int EducationDevelopmentLevel { get; set; }
        public int HealthcareDevelopmentLevel { get; set; }
        public int MilitaryDevelopmentLevel { get; set; }
        public int SeafaringDevelopmentLevel { get; set; }
    }
}