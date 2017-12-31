﻿using BlogWeb.DAO;
using BlogWeb.Infra;
using BlogWeb.Models;
using NHibernate;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class HomeController : Controller
    {
        // TODO: Construtor da classe com parâmetros IDao<T> para injeção de dependência com o Ninject.MVC

        // GET: Home
        public ActionResult Index()
        {
            // TODO: Tratar ou evitar a exceção do tipo NHibernate.LazyInitializationException, que é jogada na View ao acessar o campo Autor, caso este contenha inicialização lazy.
            using (ISession session = NHibernateHelper.AbreSession())
            {
                PostDAO dao = new PostDAO(session);
                IList<Post> lista = dao.ListaPublicados();
                return View(lista);
            }
        }
    }
}