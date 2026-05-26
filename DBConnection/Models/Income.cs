using DBConnection.Models.Enums;

namespace DBConnection.Models
{
    public class Income
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public IncomeType IncomeType { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime EffectiveDate { get; set; }
        public Income() {
            Id= Guid.NewGuid();
            PropertyId = Guid.Empty;
            Amount = 0;
            IncomeType = 0;
            Description = string.Empty;
            EffectiveDate = DateTime.Now;
        }
    }
}
