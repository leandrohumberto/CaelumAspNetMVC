﻿using BlogWeb.Models;
using NHibernate;
using System;
using System.Collections.Generic;

namespace BlogWeb.DAO
{
    public class PostDAO : IDao<Post>
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
    }
}