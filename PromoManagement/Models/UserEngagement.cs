using System.ComponentModel.DataAnnotations;

namespace PromoManagement.Models
{
    public class UserEngagement
    {
        [Key]
        [Required]
        int Id { get; set; }

        int UserID { get; set; }
        public int? PromoId { get; set; }
        public List<Promo>? Promo { get; set; }

        bool isValid { get; set; }
    }
}
