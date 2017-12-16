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
            var dao = new PostDAO();

            Post post = new Post()
            {
                Titulo = "Meu primeiro post", 
                Conteudo = "Conteúdo do post", 
                DataPublicacao = DateTime.Now.AddDays(-99), 
                Publicado = true, 
            };

            dao.AdicionaPost(post);

            post = new Post()
            {
                Titulo = "Meu segundo post",
                Conteudo = "Conteúdo do post",
                DataPublicacao = DateTime.Now.AddDays(-98),
                Publicado = true,
            };

            dao.AdicionaPost(post);

            var posts = new List<Post>(dao.Lista());

            foreach (var item in posts)
            {
                Console.WriteLine(item.Titulo);

                if (dao.BuscaPorId(item.Id) != null)
                {
                    Console.WriteLine("Post encontrado, id = {0}", item.Id);
                    item.Conteudo += " alterado";
                    dao.Atualiza(item, item.Id);
                    Console.WriteLine("Conteúdo atualizado");
                }
                else
                {
                    Console.WriteLine("Post NÂO encontrado, id = {0}", item.Id);
                }
            }
        }
    }
}
