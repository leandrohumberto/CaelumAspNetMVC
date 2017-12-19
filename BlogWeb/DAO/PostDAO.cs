﻿using BlogWeb.Infra;
using BlogWeb.Models;
using NHibernate;
using System;
using System.Collections.Generic;

namespace BlogWeb.DAO
{
    public class PostDAO : IDao<Post>
    {
        public void Adiciona(Post post)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Save(post);
                tx.Commit();
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

        public IList<Post> Lista()
        {
            string hql = "select p from Post p";

            using (ISession session = NHibernateHelper.AbreSession())
            {
                IQuery query = session.CreateQuery(hql);
                return query.List<Post>();
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