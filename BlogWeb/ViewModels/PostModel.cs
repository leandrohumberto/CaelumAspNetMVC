using BlogWeb.Models;
using System;
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

        public PostModel() { }

        public PostModel(Post post) : this()
        {
            Id = post.Id;
            Titulo = post.Titulo;
            Conteudo = post.Conteudo;
            Publicado = post.Publicado;
            DataPublicacao = post.DataPublicacao;

            if (post.Autor != null && post.Autor.Id != 0)
            {
                AutorId = post.Autor.Id;
            }
        }

        public Post CriaPost()
        {
            Post post = new Post()
            {
                Id = this.Id,
                Titulo = this.Titulo,
                Conteudo = this.Conteudo,
                Publicado = this.Publicado,
                DataPublicacao = this.DataPublicacao,
            };

            if (AutorId != null && AutorId != 0)
            {
                Usuario autor = new Usuario() { Id = AutorId.Value, };
                post.Autor = autor;
            }

            return post;
        }
    }
}