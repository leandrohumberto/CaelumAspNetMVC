using BlogWeb.DAO;
using BlogWeb.Models;
using BlogWeb.ViewModels;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace BlogWeb.Controllers
{
    public class LoginController : Controller
    {
        private IUsuarioDAO<Usuario> _usuarioDAO;

        public LoginController(IUsuarioDAO<Usuario> usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;

            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("blog", "Usuario", "Id", "Login", true);
            }
        }

        // GET: Login
        public ActionResult Index(string returnUrl)
        {
            return View(new LoginModel { Url = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autentica(LoginModel viewModel)
        {
            if (WebSecurity.Login(viewModel.Login, viewModel.Senha))
            {
                return Redirect(viewModel.Url);
            }
            else
            {
                ModelState.AddModelError("login.Invalido", "Login ou senha incorretos");
                return View("Index");
            }
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}