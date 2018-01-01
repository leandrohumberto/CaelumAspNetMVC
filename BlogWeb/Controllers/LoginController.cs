using BlogWeb.DAO;
using BlogWeb.Infra;
using BlogWeb.Models;
using BlogWeb.ViewModels;
using NHibernate;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class LoginController : Controller
    {
        // TODO: Construtor da classe com parâmetros IDao<T> para injeção de dependência com o Ninject.MVC

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Autentica(LoginModel viewModel)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                UsuarioDAO dao = new UsuarioDAO(session);
                Usuario usuario = dao.Busca(viewModel.Login, viewModel.Senha);

                if (usuario != null)
                {
                    Session["usuario"] = usuario;
                    return RedirectToAction("Index", "Post");
                }
                else
                {
                    ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
                    return View("Index");
                }
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}