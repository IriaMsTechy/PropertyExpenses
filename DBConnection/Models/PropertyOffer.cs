namespace DBConnection.Models
{
    public class PropertyOffer
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public double OfferPrice { get; set; }  
        public double SalePrice { get; set; }
        public bool AcceptedOffer { get; set; }
        public bool CompletedSale { get; set; }
        public string RejectionReason { get; set; }
        public string FailureReason { get; set; }
        virtual public PropertyValuation PropertyValuation { get; set; }
        public PropertyModel Property { get; set; }
        public PropertyOffer()
        {
            Id = Guid.NewGuid();
            OfferPrice = 0;
            SalePrice = 0;
            AcceptedOffer = false;
            CompletedSale = false;
            RejectionReason = string.Empty;
            FailureReason = string.Empty;
            PropertyValuation = new PropertyValuation();
            Property = new PropertyModel();
        }
    }
}
