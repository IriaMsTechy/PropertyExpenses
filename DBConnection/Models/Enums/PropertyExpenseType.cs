namespace DBConnection.Models.Enums
{
    [Flags]
    public enum PropertyExpenseType
    {
        Presales = 0b_1000_0000,
        Report = 0b_0100_0000,
        Maintenance = 0b_0010_0000,
        Certificate = 0b_0001_0000,
        Mortgage = 0b_0000_1000,
        Legal = 0b_0000_0100,
        Tax = 0b_0000_0010
    }
}
