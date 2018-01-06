using System.Collections.Generic;

namespace BlogWeb.DAO
{
    public interface IPostDAO<T> : IDao<T>
    {
        IList<T> ListaPublicados();
        IList<T> ListaPublicadosDoAutor(string nome);
        IList<T> ListaPublicadosDoMes(int mes, int ano);
        IList<P> PublicacoesPorMes<P>();
    }
}
