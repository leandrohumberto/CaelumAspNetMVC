using BlogWeb.DAO;
using BlogWeb.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace BlogWeb.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private IUsuarioDAO<Usuario> _usuarioDAO;

        public UsuarioController(IUsuarioDAO<Usuario> usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;

            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("blog", "Usuario", "Id", "Login", true);
            }
        }

        // GET: Usuario
        [Route("usuarios", Name = "ListaUsuarios")]
        public ActionResult Index()
        {
            IList<Usuario> usuarios = _usuarioDAO.Lista();
            return View(usuarios);
        }

        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Adiciona(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Grava o usuário no banco de dados
                    WebSecurity.CreateUserAndAccount(usuario.Login, usuario.Password, 
                        new { Email = usuario.Email, Nome = usuario.Nome }, false);
                    return RedirectToAction(nameof(Index));
                }
                catch (MembershipCreateUserException)
                {
                    // Se o usuário já existir, mostra um erro de validação
                    ModelState.AddModelError("usuario.Invalido", "Usuário inválido");
                    return View("Form");
                }
            }
            else
            {
                return View("Form", usuario);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            // Fonte: https://stackoverflow.com/questions/13391166/how-to-delete-a-simplemembership-user
            Usuario usuario = _usuarioDAO.BuscaPorId(id);

            if (usuario != null)
            {
                // deletes record from webpages_Membership table
                ((SimpleMembershipProvider)Membership.Provider).DeleteAccount(usuario.Login);
                // deletes record from UserProfile table
                ((SimpleMembershipProvider)Membership.Provider).DeleteUser(usuario.Login, true);
            }

            return new EmptyResult();
        }

        [Route("usuarios/{id}", Name = "VisualizaUsuario")]
        public ActionResult Visualiza(int id)
        {
            Usuario usuario = _usuarioDAO.BuscaPorId(id);
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Altera(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioDAO.Atualiza(usuario);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Visualiza", usuario);
            }
        }
    }
}