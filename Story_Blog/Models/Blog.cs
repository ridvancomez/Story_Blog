using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Story_Blog.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public string CoverLetter { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string BlogContent { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuthorId { get; set; }
        
        public Author Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}