using BlogWeb.Models;
using NHibernate;
using System;
using System.Collections.Generic;

namespace BlogWeb.DAO
{
    public class UsuarioDAO : IDao<Usuario>
    {
        private ISession _session;

        public UsuarioDAO(ISession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public void Adiciona(Usuario usuario)
        {
            using (ITransaction tx = _session.BeginTransaction())
            {
                _session.Save(usuario);
                tx.Commit();
            }
        }

        public void Atualiza(Usuario usuario)
        {
            using (ITransaction tx = _session.BeginTransaction())
            {
                _session.Merge(usuario);
                tx.Commit();
            }
        }

        public Usuario BuscaPorId(int id)
        {
            Usuario usuario = _session.Get<Usuario>(id);

            if (usuario == null)
            {
                throw new ArgumentException("ID não encontrado", nameof(id));
            }

            return usuario;
        }

        public IList<Usuario> Lista()
        {
            string hql = "select u from Usuario u";
            IQuery query = _session.CreateQuery(hql);
            return query.List<Usuario>();
        }

        public void Remove(Usuario usuario)
        {
            using (ITransaction tx = _session.BeginTransaction())
            {
                _session.Delete(usuario);
                tx.Commit();
            }
        }
    }
}