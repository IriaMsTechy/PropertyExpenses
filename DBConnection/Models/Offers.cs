namespace DBConnection.Models
{
    public class Offers
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public double OfferPrice { get; set; }
        public DateTime OfferDate { get; set; }
        public bool IsAccepted { get; set; }

        public string ReasonDescription { get; set; }
        public Offers()
        {
            Id = Guid.NewGuid();
            PropertyId = Guid.Empty;
            OfferPrice = 0.0;
            OfferDate = DateTime.Now;
            IsAccepted = false;
            ReasonDescription = string.Empty;
        }
    }
}
