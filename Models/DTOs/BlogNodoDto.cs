using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BLOGSOCIALUDLA.Models
{
    public class BlogNodoDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Contenido { get; set; }
        public ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}