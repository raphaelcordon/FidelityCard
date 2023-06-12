using System.ComponentModel.DataAnnotations;

namespace PromoManagement.Models
{
    public class Promo
    {
        [Key]
        [Required]
        int Id { get; set; }
        [Required]
        [MaxLength(25)]
        string Name { get; set; }
        [Required]
        [StringLength(300)]
        string Description { get; set; }
        [Required]
        DateTime DateTimeStart { get; set; }
        [Required]
        DateTime DateTimeEnd { get; set; }
        [Required]
        int Fidelity { get; set; } = 0;
    }
}
