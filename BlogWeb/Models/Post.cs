using System.ComponentModel.DataAnnotations;

namespace BlogWeb.Models
{
    public class Post
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Por favor preencher o campo")]
        [StringLength(20, ErrorMessage = "O título deve conter no máximo 20 caracteres")]
        public virtual string Titulo { get; set; }
        public virtual string Conteudo { get; set; }
        public virtual System.DateTime? DataPublicacao { get; set; }
        public virtual bool Publicado { get; set; }
    }
}
