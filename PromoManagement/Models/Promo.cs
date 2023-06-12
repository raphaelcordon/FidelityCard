using System.ComponentModel.DataAnnotations;

namespace PromoManagement.Models
{
    public class Promo
    {
        [Required]
        [Key]
        int Id { get; set; }
        [Required]
        string Name { get; set; }
        [Required]
        string Description { get; set; }
        [Required]
        DateTime DateTimeStart { get; set; }
        [Required]
        DateTime DateTimeEnd { get; set; }
        [Required]
        int Fidelity { get; set; } = 0;
        
    }
}
