using BlogWeb.DAO;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            PostDAO dao = new PostDAO();
            ViewBag.Posts = dao.Lista();
            return View();
        }
    }
}