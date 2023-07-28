using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Kombox.Models.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Name")]
        [MaxLength(30)]
        public string? Name { get; set; }
        [Required]
        [DisplayName("Display Orders")]
        [Range(0, 100)]
        public int DisplayOrder { get; set; }
    }
}
