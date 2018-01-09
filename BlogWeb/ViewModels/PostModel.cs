using BlogWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogWeb.ViewModels
{
    public class PostModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Por favor preencher o campo")]
        [StringLength(45, ErrorMessage = "O título deve conter no máximo 45 caracteres")]
        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public bool Publicado { get; set; }

        public DateTime? DataPublicacao { get; set; }

        public int? AutorId { get; set; }

        public IList<int> Tags { get; set; }
    }
}