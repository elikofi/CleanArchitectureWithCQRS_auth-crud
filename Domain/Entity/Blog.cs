using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    public class Blog
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [Length(4, 15)]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Author { get; set; }
    }
}
