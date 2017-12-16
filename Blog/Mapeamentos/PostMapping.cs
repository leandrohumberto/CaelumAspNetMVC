using Blog.Models;
using FluentNHibernate.Mapping;

namespace Blog.Mapeamentos
{
    class PostMapping : ClassMap<Post>
    {
        public PostMapping()
        {
            Id(post => post.Id).GeneratedBy.Identity();
            Map(post => post.Titulo);
            Map(post => post.Conteudo);
            Map(post => post.DataPublicacao);
            Map(post => post.Publicado);
        }
    }
}
