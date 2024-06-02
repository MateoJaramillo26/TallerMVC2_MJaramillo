using System.ComponentModel.DataAnnotations;

namespace TallerMVC2_MJ.Models
{
    public class MJBurger
    {
        public int MJBurgerId { get; set; }
        [Required]
        public string? MJName { get; set; }
        public bool MJWithCheese { get; set; }
        [Range(0.01, 9999.99)]
        public decimal MJPrecio { get; set; }

        public List<MJPromo>? MJPromo { get; set; }
    }
}
