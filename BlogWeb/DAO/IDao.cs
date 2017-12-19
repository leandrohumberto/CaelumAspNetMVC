using System.Collections.Generic;

namespace BlogWeb.DAO
{
    public interface IDao<T>
    {
        void Adiciona(T model);
        IList<T> Lista();
        T BuscaPorId(int id);
        void Atualiza(T model);
        void Remove(T model);
    }
}
