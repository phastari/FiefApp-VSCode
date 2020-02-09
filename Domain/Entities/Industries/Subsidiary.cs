using System;
using Domain.Entities.Types;

namespace Domain.Entities.Industries
{
    public class Subsidiary : Industry
    {
        public Subsidiary()
        {
            IndustryType = "Subsidiary";
        }
        public SubsidiaryType SubsidiaryType { get; set; }
        public int SubsidiaryTypeId { get; set; }
        public int Quality { get; set; }
        public int DevelopmentLevel { get; set; }
        public int Silver { get; set; }
        public int Base { get; set; }
        public int Luxury { get; set; }
        public int DaysworkThisYear { get; set; }
        public bool IsBeingDeveloped { get; set; }
        public Guid? DevelopmentId { get; set; }
        public double SpringModifier { get; set; }
        public double SummerModifier { get; set; }
        public double FallModifier { get; set; }
        public double WinterModifier { get; set; }
    }
}