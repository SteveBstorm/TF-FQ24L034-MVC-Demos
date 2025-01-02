using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPMVC_Demo01.Models
{
    public class ProductForm
    {
        [Required]
        [DisplayName("Nom de l'article : ")]
        public string Name { get; set; }
        [Range(0.0, 10000.0)]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
