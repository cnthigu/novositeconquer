using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConquerSite.Models
{
    [Table("servercontrol")]
    public class ServerControlModel
    {
        [Key]
        [Column("Owner")]
        [StringLength(15)]
        public string Owner { get; set; }

        [Column("NormalDb_Drop")]
        public long NormalDbDrop { get; set; } 

        [Column("VipDb_Drop")]
        public long VipDbDrop { get; set; } 

        [Column("Vip_Drop_Meteors")]
        public long VipDropMeteors { get; set; } 

        [Column("Normal_Drop_Meteors")]
        public long NormalDropMeteors { get; set; } 
        [Column("Vip_Drop_Stone")]
        public long VipDropStone { get; set; } 
        [Column("Normal_Drop_Stone")]
        public long NormalDropStone { get; set; } 

        [Column("Max_DragonBall_Normal")]
        public byte MaxDragonBallNormal { get; set; }

        [Column("Max_Meteors_Normal")]
        public byte MaxMeteorsNormal { get; set; }

        [Column("Max_Stone_Normal")]
        public byte MaxStoneNormal { get; set; } 

        [Column("Max_DragonBall_Vip")]
        public byte MaxDragonBallVip { get; set; } 

        [Column("Max_Meteors_Vip")]
        public byte MaxMeteorsVip { get; set; } 

        [Column("Max_Stone_Vip")]
        public byte MaxStoneVip { get; set; } 
    }
}
