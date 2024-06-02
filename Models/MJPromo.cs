namespace TallerMVC2_MJ.Models
{
    public class MJPromo
    {
        public int PromoId { get; set; }
        public string? PromoDescripcion { get; set; }
        public DateTime FechaPromocion { get; set; }

        public int BurgerId { get; set; }
        public MJBurger? Burger { get; set; }
    }
}
