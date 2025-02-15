namespace ConquerSite.Models
{
    public class PaymentData
    {
        public PaymentDetails Payment { get; set; }
    }

    public class PaymentDetails
    {
        public long Id { get; set; }
        public int Value { get; set; }
        public string ExternalReference { get; set; }
    }
}
