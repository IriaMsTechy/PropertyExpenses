namespace DBConnection.Models
{
    public class PropertySaleData
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public double HRV { get; set; }
        public DateTime OnTheMarketDate { get; set; }
        public DateTime SoldDate { get; set; }
        public double SalePrice { get; set; }
    }
}
