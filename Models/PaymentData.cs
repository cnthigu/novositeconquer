using System.ComponentModel.DataAnnotations;

namespace ConquerSite.Models
{
    public class Payment
    {
        [Required(ErrorMessage = "The 'id' field is required.")]
        public string Id { get; set; }

        [Range(2, int.MaxValue, ErrorMessage = "The 'value' field must be equal or greater than 2.")]
        public int Value { get; set; }

        [Required(ErrorMessage = "The 'externalReference' field is required.")]
        public string ExternalReference { get; set; }
    }

    public class PaymentRequest
    {
        public Payment Payment { get; set; }
    }
}
