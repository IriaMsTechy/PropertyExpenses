namespace DBConnection.Models
{
    public class PropertyValuation
    {
        public Guid Id { get; set; }
        public DateTime ValuationDate { get; set; }
        public double ValuationAmount { get; set; }
        public string ValuationAgent { get; set; }

        public PropertyValuation()
        {
            Id = Guid.NewGuid();
            ValuationDate = DateTime.Now;
            ValuationAmount = 0.0;
            ValuationAgent = string.Empty;
        }
    }
}
