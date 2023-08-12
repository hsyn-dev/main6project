using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace main6project.Models.ViewModels
{
    public class Creatvm
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        [Required(ErrorMessage = "This field should not be empty")]
        public string Name { get; set; } = null!;

        [StringLength(50)]
        [Unicode(false)]
        [Required(ErrorMessage = "This field should not be empty")]

        public string Family { get; set; } = null!;

        [StringLength(50)]
        [Unicode(false)]
        [Required(ErrorMessage = "This field should not be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [StringLength(50)]
        [Unicode(false)]
        public string ImageName { get; set; } = null!;
        [Required(ErrorMessage = "This field should not be empty")]

        public IFormFile imageupload { get; set; }
        [Required]
        public int Province { get; set; }
        [Required]

        public int City { get; set; }

    }
}
