using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConquerSite.Models
{
    [Table("store")]
    public class StoreModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; } 

        [Column("item")]
        [StringLength(255)]
        public string Item { get; set; } 

        [Column("price")]
        public float? Price { get; set; } 

        [Column("mount")]
        public long? Mount { get; set; }

        public string QrCodeBase64 { get; set; }
    }
}
