namespace DBConnection.Models
{
    public class PropertyExpense : Expense
    {
        public Guid? PropertyId { get; set; }
        public Models.Enums.PropertyExpenseType ExpenseType { get; set; }
        public PropertyExpense() : base()
        {
            PropertyId = Guid.Empty;
            ExpenseType = Models.Enums.PropertyExpenseType.Maintenance;
        }
    }
}
