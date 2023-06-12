namespace PromoManagement.Models
{
    public class PromoUsers
    {
        int Id { get; set; }

        int UserID { get; set; }
        public List<Promo> Promo { get; set; }

        bool isValid { get; set; }
    }
}
