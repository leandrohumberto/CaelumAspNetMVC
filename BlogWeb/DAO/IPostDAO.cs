using BlogWeb.Models;
using System.Collections.Generic;

namespace BlogWeb.DAO
{
    public interface IPostDAO
    {
        void AdicionaPost(Post post);
        IList<Post> Lista();
        Post BuscaPorId(int id);
        void Atualiza(Post post);
        void Remove(Post post);
    }
}
