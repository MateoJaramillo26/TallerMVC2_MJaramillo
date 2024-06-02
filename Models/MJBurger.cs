using System.ComponentModel.DataAnnotations;

namespace TallerMVC2_MJ.Models
{
    public class MJBurger
    {
        public int BurgerId { get; set; }
        [Required]
        public string? Name { get; set; }
        public bool WithCheese { get; set; }
        [Range(0.01, 9999.99)]
        public decimal Precio { get; set; }

        public List<MJPromo>? Promo { get; set; }
    }
}
