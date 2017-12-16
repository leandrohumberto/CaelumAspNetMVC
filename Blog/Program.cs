using Blog.DAO;
using Blog.Models;
using System;
using System.Collections.Generic;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            PostDAO dao = new PostDAO();

            Post post = new Post
            {
                Titulo = "Título com PostDAO",
                Conteudo = "Conteúdo com PostDAO",
                DataPublicacao = DateTime.Now,
                Publicado = true,
            };

            Console.WriteLine("Adicionando Post [Título = {0}]", post.Titulo);
            dao.AdicionaPost(post);

            int id = 1;
            Console.WriteLine("Buscando Post [Id = {0}]", id);
            post = dao.BuscaPorId(id);
            Console.WriteLine("Título = {0}", post.Titulo);

            Console.WriteLine("Atualizando Post");
            post.Titulo += " atualizado";
            dao.Atualiza(post);

            Console.WriteLine("Listando Posts");
            IList<Post> lista = dao.Lista();

            foreach (var item in dao.Lista())
            {
                Console.WriteLine("Título = {0}", item.Titulo);
            }

            Console.WriteLine("Deletando Post [Id = {0}]", post.Id);
            dao.Remove(post);
        }
    }
}
