using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Story_Blog.Models
{
    public enum Role
    {
        Admin = 1,
        Author = 2
    }
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(50), EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        [Required]
        public Role Role { get; set; }

        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}