namespace Domain.Entities.Industries
{
    public class Income : Industry
    {
        public bool NeedSteward { get; set; }
        public bool ShowInIncomes { get; set; }
        public bool IsBeingDeveloped { get; set; }
        public int Silver { get; set; }
        public int Base { get; set; }
        public int Luxury { get; set; }
        public int Wood { get; set; }
        public double SpringModifier { get; set; }
        public double SummerModifier { get; set; }
        public double FallModifier { get; set; }
        public double WinterModifier { get; set; }
    }
}