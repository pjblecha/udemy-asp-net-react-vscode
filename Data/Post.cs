using System.ComponentModel.DataAnnotations;

namespace aspnetserver.Data
{
    internal sealed class Post
    {
        [Key]
        public int PostID { get; set; }
        [Required]
        [MaxLength(128)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(131080)]
        public string Content { get; set; } = string.Empty;
    }
}