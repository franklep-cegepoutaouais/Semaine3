using RahRahRah.Repos;
using RahRahRah.Repos.Interfaces;
using System.Web.Mvc;

namespace RahRahRah.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Repository des publications.
        /// </summary>
        private IRepoPublications _repoPublications;

        /// <summary>
        /// HACK: Constructeur par défaut. À supprimer quand on utilisera l'injection de dépendences.
        /// </summary>
        public HomeController()
            : this(new RepoPublications())
        {
        }

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="repoPublications">Repository des publications.</param>
        public HomeController(IRepoPublications repoPublications)
        {
            _repoPublications = repoPublications;
        }

        /// <summary>
        /// Préparation de l'écran de base.
        /// </summary>
        /// <returns>Action.</returns>
        public ActionResult Index()
        {
            return View(_repoPublications.Obtenir());
        }
    }
}