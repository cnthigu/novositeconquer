using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConquerSite.Models
{
    public class MiningModels
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string player_name { get; set; }

        [Required]
        [StringLength(100)]
        public string item_name { get; set; }

        public DateTime mined_at { get; set; } = DateTime.UtcNow;

    }
}
