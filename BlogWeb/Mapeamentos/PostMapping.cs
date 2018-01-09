using BlogWeb.Models;
using FluentNHibernate.Mapping;

namespace BlogWeb.Mapeamentos
{
    public class PostMapping : ClassMap<Post>
    {
        public PostMapping()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Titulo);
            Map(p => p.Conteudo);
            Map(p => p.DataPublicacao);
            Map(p => p.Publicado);
            References(p => p.Autor, "AutorId");
            HasManyToMany(p => p.Tags)
                .Table("Post_Tags")
                .ParentKeyColumn("PostId")
                .ChildKeyColumn("TagId");
        }
    }
}