using Blog.Infra;
using Blog.Models;
using NHibernate;
using System;
using System.Collections.Generic;

namespace Blog.DAO
{
    public class PostDAO : IPostDAO
    {
        public void AdicionaPost(Post post)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Save(post);
                tx.Commit();
            }
        }

        public IList<Post> Lista()
        {
            string hql = "select p from Post p";

            using (ISession session = NHibernateHelper.AbreSession())
            {
                IQuery query = session.CreateQuery(hql);
                return query.List<Post>();
            }
        }

        public Post BuscaPorId(int id)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                Post post = session.Get<Post>(id);

                if (post == null)
                {
                    throw new ArgumentException("ID não encontrado", nameof(id));
                }

                return post;
            }
        }

        public void Atualiza(Post post)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Merge(post);
                tx.Commit();
            }
        }

        public void Remove(Post post)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Delete(post);
                tx.Commit();
            }
        }
    }
}
