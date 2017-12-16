using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Blog.DAO
{
    public class PostDAO
    {
        public void AdicionaPost(Post post)
        {
            string sql = "insert into posts (titulo, conteudo, dataPublicacao, publicado)" +
                "values (@titulo, @conteudo, @dataPublicacao, @publicado)";

            using (IDbConnection conexao = ConnectionFactory.CriaConexao())
            using (IDbCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = sql;

                IDbDataParameter paramTitulo = comando.CreateParameter();
                paramTitulo.ParameterName = "titulo";
                paramTitulo.Value = post.Titulo;
                comando.Parameters.Add(paramTitulo);

                IDbDataParameter paramConteudo = comando.CreateParameter();
                paramConteudo.ParameterName = "conteudo";
                paramConteudo.Value = post.Conteudo;
                comando.Parameters.Add(paramConteudo);

                IDbDataParameter paramData = comando.CreateParameter();
                paramData.ParameterName = "dataPublicacao";
                paramData.Value = post.DataPublicacao;
                comando.Parameters.Add(paramData);

                IDbDataParameter paramPublicado = comando.CreateParameter();
                paramPublicado.ParameterName = "publicado";
                paramPublicado.Value = post.Publicado;
                comando.Parameters.Add(paramPublicado);

                comando.ExecuteNonQuery();
            }
        }

        public IEnumerable<Post> Lista()
        {
            string sql = "select * from posts";

            using (IDbConnection conexao = ConnectionFactory.CriaConexao())
            using (IDbCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = sql;
                var posts = new List<Post>();

                using (IDataReader leitor = comando.ExecuteReader())
                {
                    while (leitor.Read())
                    {
                        Post post = GetPost(leitor);
                        posts.Add(post);
                    }
                }

                return posts;
            }
        }

        public Post BuscaPorId(int id)
        {
            var sql = "select * from posts where id = @id";
            using (IDbConnection conexao = ConnectionFactory.CriaConexao())
            using (IDbCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = sql;
                var parametro = comando.CreateParameter();
                parametro.ParameterName = "id";
                parametro.Value = id;
                comando.Parameters.Add(parametro);
                Post post;

                using (IDataReader leitor = comando.ExecuteReader())
                {
                    if (leitor.Read())
                    {
                        post = GetPost(leitor);
                    }
                    else
                    {
                        throw new ArgumentException();
                    }
                }

                return post;
            }
        }

        public void Atualiza(Post post, int id)
        {
            string sql = "update posts set titulo = @titulo, conteudo = @conteudo, " + 
                "dataPublicacao = @dataPublicacao, publicado = @publicado where id = @id";

            using (IDbConnection conexao = ConnectionFactory.CriaConexao())
            using (IDbCommand comando = conexao.CreateCommand())
            {
                comando.CommandText = sql;

                IDbDataParameter parametro = comando.CreateParameter();
                parametro.ParameterName = "id";
                parametro.Value = id;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "titulo";
                parametro.Value = post.Titulo;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "conteudo";
                parametro.Value = post.Conteudo;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "dataPublicacao";
                parametro.Value = post.DataPublicacao;
                comando.Parameters.Add(parametro);

                parametro = comando.CreateParameter();
                parametro.ParameterName = "publicado";
                parametro.Value = post.Publicado;
                comando.Parameters.Add(parametro);

                int linhasAfetadas = comando.ExecuteNonQuery();

                if (linhasAfetadas < 1)
                {
                    throw new ArgumentException("Id não encontrado", nameof(id));
                }
            }
        }

        private static Post GetPost(IDataReader leitor)
        {
            Post post = new Post
            {
                Id = Convert.ToInt32(leitor["id"]),
                Titulo = Convert.ToString(leitor["titulo"]),
                Conteudo = Convert.ToString(leitor["conteudo"]),
                Publicado = Convert.ToBoolean(leitor["publicado"]),
            };

            if (!Convert.IsDBNull(leitor["dataPublicacao"]))
            {
                post.DataPublicacao = Convert.ToDateTime(leitor["dataPublicacao"]);
            }

            return post;
        }
    }
}
