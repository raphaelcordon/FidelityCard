using System.ComponentModel.DataAnnotations;

namespace PromoManagement.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Product
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }

    public class Promo
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageFileName { get; set; }
        public int TimesToPrize { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
    }

    public class UserPromoCard
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PromoId { get; set; }
        public int TimesToPrizeCount { get; set; }
    }

    public class UserCupon
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public bool Used { get; set; }
    }
}
