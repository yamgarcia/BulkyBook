using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models
{
    public class Category
    {
        //Data Annotation to inform Id column is the primary key
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string DisplayOrder{ get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;



    }
}
