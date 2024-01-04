using System.ComponentModel.DataAnnotations;

namespace KTStoreSite.Models.Abstract
{
    public class LongCommonProperty
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string? Name { get; set; }
      
        public string? Description { get; set; }
        public string? Image { get; set; }
        public bool IsStatus { get; set; }
        public bool IsDelete { get; set; }
    }
}
