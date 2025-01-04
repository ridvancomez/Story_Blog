using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Story_Blog.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CommentContent { get; set; }
        public DateTime DateCreated { get; set; }
        public int AuthorId { get; set; }
        public int BlogId { get; set; }
        


        
        public Author Author { get; set; }
        public Blog Blog { get; set; }

    }
}