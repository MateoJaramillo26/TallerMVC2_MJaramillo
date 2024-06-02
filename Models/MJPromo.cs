namespace TallerMVC2_MJ.Models
{
    public class MJPromo
    {
        public int MJPromoId { get; set; }
        public string? MJPromoDescripcion { get; set; }
        public DateTime MJFechaPromocion { get; set; }

        public int MJBurgerId { get; set; }
        public MJBurger? MJBurger { get; set; }
    }
}
