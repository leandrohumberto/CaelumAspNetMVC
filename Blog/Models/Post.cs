namespace Blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public System.DateTime? DataPublicacao { get; set; }
        public bool Publicado { get; set; }
    }
}
