namespace DBConnection.Models
{
    public class PropertyModel
    {
        public Guid Id { get; set; }
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int NumberOfBedrooms { get; set; }
        public int NumberOfBathrooms { get; set; }  
        public int NumberOfCommonRooms { get; set; }
        public bool HasParking { get; set; }
        public bool Owned { get; set; }
        public double FactorMonthlyCost { get; set; }
        public List<PropertyOffer>? PropertyOffers { get; set; }
        public List<PropertyExpense>? PropertyExpenses { get; set; }
        public List<PropertyValuation>? PropertyValuations { get; set; }
        public List<PropertySaleData>? PropertySaleData { get; set; }
        public List<Mortgage>? Mortgages { get; set; }
        public List<Income> Incomes { get; set; }

        public PropertyModel()
        {
            Id = Guid.NewGuid();
            PostCode = string.Empty;
            Address = string.Empty;
            City = string.Empty;
            NumberOfBedrooms = 0;
            NumberOfBathrooms = 0;
            NumberOfCommonRooms = 0;
            HasParking = false;
            FactorMonthlyCost = 0;
            Owned = false;
            PropertyOffers = new List<PropertyOffer>();
            PropertyExpenses = new List<PropertyExpense>();
            PropertyValuations = new List<PropertyValuation>();
            Incomes = new List<Income>();
        }
    }
}
