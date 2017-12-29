using BlogWeb.DAO;
using BlogWeb.Infra;
using BlogWeb.Models;
using NHibernate;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                var dao = new UsuarioDAO(session);
                IList<Usuario> usuarios = dao.Lista();
                return View(usuarios);
            }
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Usuario usuario)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                if (ModelState.IsValid)
                {
                    var dao = new UsuarioDAO(session);
                    dao.Adiciona(usuario);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Form", usuario);
                }
            }
        }

        public ActionResult Remove(int id)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                var dao = new UsuarioDAO(session);
                Usuario usuario = dao.BuscaPorId(id);
                dao.Remove(usuario);
                return RedirectToAction(nameof(Index));
            }
        }

        [Route("usuarios/{id}", Name = "VisualizaUsuario")]
        public ActionResult Visualiza(int id)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                var dao = new UsuarioDAO(session);
                Usuario usuario = dao.BuscaPorId(id);
                return View(usuario);
            }
        }

        [HttpPost]
        public ActionResult Altera(Usuario usuario)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                if (ModelState.IsValid)
                {
                    var dao = new UsuarioDAO(session);
                    dao.Atualiza(usuario);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Visualiza", usuario);
                }
            }
        }
    }
}