using System.ComponentModel.DataAnnotations;

namespace myshop.Web.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]// Name is Not NULL
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
    }
}
