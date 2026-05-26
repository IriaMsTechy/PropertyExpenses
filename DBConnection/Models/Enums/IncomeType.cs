namespace DBConnection.Models.Enums
{
    public enum IncomeType
    {
        IsProperty = 0b_1000_0000,
        IsCompany = 0b_0100_0000,
        IsTaxReturn = 0b_0010_0000,
        IsBankInterest = 0b_0001_0000,
        IsRent = 0b_0000_1000,
        IsSale = 0b_0000_0100,
        IsRecurrent = 0b_0000_0010
    }
}
