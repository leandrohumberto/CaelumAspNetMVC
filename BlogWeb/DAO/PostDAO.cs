using BlogWeb.Models;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;

namespace BlogWeb.DAO
{
    public class PostDAO : IPostDAO<Post>
    {
        private ISession _session;

        public PostDAO(ISession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public void Adiciona(Post post)
        {
            using (ITransaction tx = _session.BeginTransaction())
            {
                _session.Save(post);
                tx.Commit();
            }
        }

        public void Atualiza(Post post)
        {
            using (ITransaction tx = _session.BeginTransaction())
            {
                _session.Merge(post);
                tx.Commit();
            }
        }

        public Post BuscaPorId(int id)
        {
            Post post = _session.Get<Post>(id);

            if (post == null)
            {
                throw new ArgumentException("ID não encontrado", nameof(id));
            }

            return post;
        }

        public IList<Post> Lista()
        {
            string hql = "select p from Post p";
            IQuery query = _session.CreateQuery(hql);
            return query.List<Post>();
        }

        public void Remove(Post post)
        {
            using (ITransaction tx = _session.BeginTransaction())
            {
                _session.Delete(post);
                tx.Commit();
            }
        }

        public IList<Post> ListaPublicados()
        {
            string hql = "select p from Post p where p.Publicado = true order by p.DataPublicacao desc";
            IQuery query = _session.CreateQuery(hql);
            return query.List<Post>();
        }

        public IList<Post> ListaPublicadosDoAutor(string nome)
        {
            string hql = "select p from Post p join p.Autor a where p.Publicado = true and a.Nome = :nome";
            IQuery query = _session.CreateQuery(hql);
            query.SetParameter("nome", nome);
            return query.List<Post>();
        }


        public IList<Post> ListaPublicadosDoMes(int mes, int ano)
        {
            string hql = 
                "select p from Post p " +
                "where p.Publicado = true and month(p.DataPublicacao) = :mes and year(p.DataPublicacao) = :ano";
            IQuery query = _session.CreateQuery(hql);
            query.SetParameter("mes", mes);
            query.SetParameter("ano", ano);
            return query.List<Post>();
        }

        public IList<PostsPorMes> PublicacoesPorMes<PostsPorMes>()
        {
            string hql = 
                "select month(p.DataPublicacao) as Mes, year(p.DataPublicacao) as Ano, count(p) as Quantidade " +
                "from Post p " +
                "where p.Publicado = true " +
                "group by month(p.DataPublicacao), year(p.DataPublicacao)";

            IQuery query = _session.CreateQuery(hql);
            query.SetResultTransformer(Transformers.AliasToBean<PostsPorMes>());
            return query.List<PostsPorMes>();
        }
    }
}