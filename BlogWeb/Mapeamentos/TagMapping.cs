using BlogWeb.Models;
using FluentNHibernate.Mapping;

namespace BlogWeb.Mapeamentos
{
    public class TagMapping : ClassMap<Tag>
    {
        public TagMapping()
        {
            Id(t => t.Id).GeneratedBy.Identity();
            Map(t => t.Nome);
        }
    }
}