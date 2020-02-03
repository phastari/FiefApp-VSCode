using System;
using System.Collections.Generic;
using Domain.Entities.Industries;

namespace Domain.Entities.Types
{
    public class SubsidiaryType
    {
        public SubsidiaryType()
        {
            Subsidiaries = new HashSet<Subsidiary>();
        }

        public int SubsidiaryTypeId { get; set; }
        public virtual ICollection<Subsidiary> Subsidiaries { get; set; }
        public string Type { get; set; }
        public string DisplayName { get; set; }
        public double IncomeFactor { get; set; }
        public double IncomeInSilver { get; set; }
        public double IncomeInBase { get; set; }
        public double IncomeInLuxury { get; set; }
        public double SpringModification { get; set; }
        public double SummerModification { get; set; }
        public double FallModification { get; set; }
        public double WinterModification { get; set; }
        public int DaysworkBuild { get; set; }
        public int DaysworkUpkeep { get; set; }
    }
}