using BlogWeb.Models;

namespace BlogWeb.DAO
{
    public static class PostDAOFactory
    {
        public static IDao<Post> CreateDAO()
        {
            return new PostDAO();
        }
    }
}