using BlogWeb.DAO;
using BlogWeb.Infra;
using NHibernate;
using System.Web.Mvc;

namespace BlogWeb.Controllers
{
    public class ArquivoController : Controller
    {
        // TODO: Construtor da classe com parâmetros IDao<T> para injeção de dependência com o Ninject.MVC

        // GET: Arquivo
        public ActionResult Index()
        {
            return View();
        }

        [Route("arquivo/{ano}/{mes}", Name = "PostsMes")]
        public ActionResult PostsMes(int ano, int mes)
        {
            using (ISession session = NHibernateHelper.AbreSession())
            {
                var postDAO = new PostDAO(session);
                return View(postDAO.ListaPublicadosDoMes(mes, ano));
            }
        }
    }
}