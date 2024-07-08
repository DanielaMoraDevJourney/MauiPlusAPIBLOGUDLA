using System;
using System.ComponentModel.DataAnnotations;

namespace BLOGSOCIALUDLA.Models
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public Guid? BlogFicaId { get; set; }
        public Guid? BlogNodoId { get; set; }
    }
}