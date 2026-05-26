using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DBConnection.Models
{
    public class Expense
    {
        public Guid Id { get; set;  } 
        public double Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public DateTime PaidDate { get; set; }
        public string Description { get; set; }

        public Expense()
        {
            Id = Guid.NewGuid();
            Amount = 0.0;
            ExpenseDate = DateTime.Now;
            PaidDate = DateTime.Now;
            Description = string.Empty;
        }
    }
}
