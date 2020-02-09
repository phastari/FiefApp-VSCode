namespace Domain.Entities.Industries
{
    public class Tax : Industry
    {
        public Tax()
        {
            IndustryType = "Tax";
        }
        public int NumberOfBailiffs { get; set; }
        public int Silver { get; set; }
        public int Base { get; set; }
    }
}