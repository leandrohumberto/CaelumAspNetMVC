using BlogWeb.Models;
using FluentNHibernate.Mapping;

namespace BlogWeb.Mapeamentos
{
    public class UsuarioMapping : ClassMap<Usuario>
    {
        public UsuarioMapping()
        {
            Id(p => p.Id).GeneratedBy.Identity();
            Map(p => p.Nome);
            Map(p => p.Login);
            Map(p => p.Password);
            Map(p => p.Email);
        }
    }
}