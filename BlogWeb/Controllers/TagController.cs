using BlogWeb.DAO;
using BlogWeb.Models;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class TagController : Controller
    {
        private IDao<Tag> _tagDAO;

        public TagController(IDao<Tag> tagDAO)
        {
            _tagDAO = tagDAO;
        }

        // GET: Tag
        public ActionResult Index()
        {
            return View(_tagDAO.Lista());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adiciona(Tag tag)
        {
            _tagDAO.Adiciona(tag);
            return RedirectToAction(nameof(Index));
        }
    }
}