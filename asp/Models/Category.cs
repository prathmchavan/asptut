using System.ComponentModel.DataAnnotations;

namespace asp.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime createdDateTime { get; set; }= DateTime.Now;
    }
}
