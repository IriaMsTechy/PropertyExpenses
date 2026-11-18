namespace DBConnection.Models
{
    public class PropertyExpense : Expense
    {
        public Guid? PropertyId { get; set; }
        public Models.Enums.PropertyExpenseType ExpenseType { get; set; }
        public Guid? MortgageId { get; set; }
        public Mortgage? Mortgage { get; set; }
        public PropertyModel Property { get; set; }
        public PropertyExpense() : base()
        {
            ExpenseType = Models.Enums.PropertyExpenseType.Maintenance;
            Property = new PropertyModel();
            Mortgage = null;
        }
    }
}
