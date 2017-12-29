using System.ComponentModel.DataAnnotations;

namespace BlogWeb.Models
{
    public class Usuario
    {
        public virtual int Id { get; set; }

        [Required(ErrorMessage = "Por favor preencher o campo")]
        public virtual string Nome { get; set; }

        [Required(ErrorMessage = "Por favor preencher o campo")]
        [MinLength(5, ErrorMessage = "O login deve conter no mínimo 5 caracteres")]
        public virtual string Login { get; set; }

        [Required(ErrorMessage = "Por favor preencher o campo")]
        [MinLength(8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres")]
        public virtual string Password { get; set; }

        [Required(ErrorMessage = "Por favor preencher o campo")]
        [EmailAddress(ErrorMessage = "Endereço de e-mail inválido")]
        public virtual string Email { get; set; }
    }
}