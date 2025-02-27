using System.ComponentModel.DataAnnotations;

namespace ConquerSite.Models
{
    public class PaymentRecord
    {
        [Key]
        public string id { get; set; } // Usando 'long' para compatibilidade com o 'bigint' do banco
        public string username { get; set; }
        public int founds { get; set; }
        public string payment_status { get; set; } = "Aproved";
        public DateTime? Date { get; set; }
    }
}