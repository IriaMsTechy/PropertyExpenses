namespace DBConnection.Models.Enums
{
    public enum CompanyExpenseType
    {
        IsPortfolio = 0b_1000_0000,
        Report = 0b_0100_0000,
        IsAccounting = 0b_0010_0000,
        Certificate = 0b_0001_0000,
        Legal = 0b_0000_0100,
        Tax = 0b_0000_0010
    }
}
