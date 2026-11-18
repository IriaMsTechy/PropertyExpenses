namespace DBConnection.Models
{
    public class Mortgage
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public double PrincipalAmount { get; set; }
        public double AnnualPromotionalInterestRate { get; set; }
        public int TermInYears { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndOfPromotionalRateDate { get; set; }
        public DateTime? EndDate { get; set; }

        public IList<PropertyExpense> MortgagePayments { get; set; } = new List<PropertyExpense>();
        public Mortgage()
        {
            Id = Guid.NewGuid();
            PropertyId = Guid.Empty;
            PrincipalAmount = 0.0;
            AnnualPromotionalInterestRate = 0.0;
            TermInYears = 0;
            StartDate = DateTime.Now;
            EndDate = null;
        }       
    }
}
