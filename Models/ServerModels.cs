using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConquerSite.Models
{
    [Table("servers")]
    public class ServerModel
    {
        [Key]
        [Column("Name")]
        [StringLength(16)]
        public string Name { get; set; }

        [Column("IP")]
        [StringLength(16)]
        public string IP { get; set; } 

        [Column("Port")]
        public uint? Port { get; set; } 

        [Column("TransferKey")]
        [StringLength(64)]
        public string TransferKey { get; set; } 

        [Column("TransferSalt")]
        [StringLength(64)]
        public string TransferSalt { get; set; } 
    }
}
