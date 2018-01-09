using BlogWeb.Models;
using NHibernate;
using System;
using System.Collections.Generic;

namespace BlogWeb.DAO
{
    public class TagDAO : IDao<Tag>
    {
        private ISession _session;

        public TagDAO(ISession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public void Adiciona(Tag tag)
        {
            using (ITransaction tx = _session.BeginTransaction())
            {
                _session.Save(tag);
                tx.Commit();
            }
        }

        public void Atualiza(Tag tag)
        {
            using (ITransaction tx = _session.BeginTransaction())
            {
                _session.Merge(tag);
                tx.Commit();
            }
        }

        public Tag BuscaPorId(int id)
        {
            Tag tag = _session.Get<Tag>(id);

            if (tag == null)
            {
                throw new ArgumentException("ID não encontrado", nameof(id));
            }

            return tag;
        }

        public IList<Tag> Lista()
        {
            string hql = "select t from Tag t";
            IQuery query = _session.CreateQuery(hql);
            return query.List<Tag>();
        }

        public void Remove(Tag tag)
        {
            using (ITransaction tx = _session.BeginTransaction())
            {
                _session.Delete(tag);
                tx.Commit();
            }
        }
    }
}