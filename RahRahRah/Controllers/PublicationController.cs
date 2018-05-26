using RahRahRah.Repos;
using RahRahRah.Repos.Interfaces;
using System.Web.Mvc;

namespace RahRahRah.Controllers
{
    public class PublicationController : Controller
    {
        /// <summary>
        /// Repository des publications.
        /// </summary>
        private IRepoPublications _repoPublications;

        /// <summary>
        /// HACK: Constructeur par défaut. À supprimer quand on utilisera l'injection de dépendences.
        /// </summary>
        public PublicationController()
            : this(new RepoPublications())
        {
        }

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        /// <param name="repoPublications">Repository des publications.</param>
        public PublicationController(IRepoPublications repoPublications)
        {
            _repoPublications = repoPublications;
        }

        /// <summary>
        /// Préparation de l'écran de base.
        /// </summary>
        /// <returns>Action.</returns>
        public ActionResult Index(int id)
        {
            return View(_repoPublications.Obtenir(id));
        }
    }
}