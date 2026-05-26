using DBConnection.Models.Enums;

namespace DBConnection.Models
{
    public class CompanyExpense : Expense
    {
        public CompanyExpenseType CompanyExpenseType { get; set; }

        CompanyExpense(): base()
        {
            CompanyExpenseType = 0;
        }

    }
}
