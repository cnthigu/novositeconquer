using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConquerSite.Models
{
    [Table("accounts")]
    public class PlayerModels
    {
        [Key]
        [Column("EntityID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public long? EntityID { get; set; }

        [Column("Username")]
        [StringLength(25)]
        [Required(ErrorMessage = "O nome de usuário é obrigatório.")]
        public string Username { get; set; }

        [Column("Password")]
        [StringLength(16)]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Password { get; set; }

        [Column("Email")]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string? Email { get; set; }

        [Column("IP")]
        [StringLength(15)]
        public string? IP { get; set; }

        [Column("LastCheck")]
        public long? LastCheck { get; set; }

        [Column("State")]
        public byte? State { get; set; }

        [Column("Question")]
        [StringLength(100)]
        public string? Question { get; set; }

        [Column("answer")]
        [StringLength(30)]
        public string? Answer { get; set; }

        [Column("Country")]
        [StringLength(110)]
        public string? Country { get; set; }

        [Column("City")]
        [StringLength(100)]
        public string? City { get; set; }

        [Column("secretquestion")]
        [StringLength(45)]
        public string? SecretQuestion { get; set; }

        [Column("realname")]
        [StringLength(25)]
        public string? RealName { get; set; }

        [Column("machine")]
        [StringLength(50)]
        public string? Machine { get; set; }

        [Column("lastvote")]
        [StringLength(50)]
        public string? LastVote { get; set; }

        [Column("mobilenumber")]
        public long? MobileNumber { get; set; }

        [Column("securitycode")]
        [StringLength(100)]
        public string? SecurityCode { get; set; }

        [Column("date")]
        [StringLength(255)]
        public string? Date { get; set; }

        [Column("joined")]
        [StringLength(220)]
        public string? Joined { get; set; }

        [Column("Online")]
        public long? Online { get; set; }

        public string? RecoveryToken { get; set; }

    }
}
