namespace BlogWeb.Models
{
    public class Post
    {
        public virtual int Id { get; set; }
        public virtual string Titulo { get; set; }
        public virtual string Conteudo { get; set; }
        public virtual System.DateTime? DataPublicacao { get; set; }
        public virtual bool Publicado { get; set; }
    }
}
