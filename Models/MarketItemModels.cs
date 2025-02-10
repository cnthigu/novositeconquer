using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConquerSite.Models
{
    public class MarketItem
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int Id { get; set; }

        [Required]
        [StringLength(50)] 
        public string PlayerName { get; set; }

        [Required]
        [StringLength(100)] 
        public string ItemName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public int Price { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow; 
    }
}
