namespace BlogWeb.DAO
{
    public interface IUsuarioDAO<T> : IDao<T>
    {
        T Busca(string login, string senha);
    }
}
