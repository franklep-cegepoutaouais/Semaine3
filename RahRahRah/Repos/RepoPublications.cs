using RahRahRah.Models;
using RahRahRah.Models.Interfaces;
using System;
using System.Linq;

namespace RahRahRah.Repos
{
    /// <summary>
    /// Repository des publications.
    /// </summary>
    public class RepoPublications : Interfaces.IRepoPublications
    {
        /// <summary>
        /// Publications en mémoire.
        /// </summary>
        private readonly IPublications _publications = new Publications();

        /// <summary>
        /// Constructeur par défaut.
        /// </summary>
        public RepoPublications()
        {
            // Initialiser le repo.
            Ajouter(@"Essai n° un.", "Ceci est un essai super le fun.", "François Lépine");
            Ajouter(@"Essai n° deux.", "Héhé?", "François Lépine");
            var parent = Ajouter(@"Essai n° trois.", "Après avoir lu l'article, j'me suis pris un bon rhum", "François Lépine");
            Repondre(parent.Id, "Hic!", "Z't'ai zune bonne idéeeeeeeee", "François Lépine");
        }

        /// <summary>
        /// Ajouter une nouvelle publication.
        /// </summary>
        /// <param name="titre">Titre de la publication.</param>
        /// <param name="message">Message.</param>
        /// <param name="publicateur">Publicateur.</param>
        /// <returns>Publication.</returns>
        public IPublication Ajouter(string titre, string message, string publicateur)
        {
            var pub = Creer(titre, message, publicateur);

            _publications.Add(pub);

            return pub;
        }

        /// <summary>
        /// Obtenir toutes les publications.
        /// </summary>
        /// <returns>Publications.</returns>
        public IPublications Obtenir() => new Publications(_publications.Where(p => !p.EstReponse).ToList());

        /// <summary>
        /// Obtenir la publication.
        /// </summary>
        /// <param name="id">Identifiant.</param>
        /// <returns>Publication.</returns>
        public IPublication Obtenir(int id) => _publications.SingleOrDefault(p => p.Id == id);

        /// <summary>
        /// Répondre à une publication déjà faite.
        /// </summary>
        /// <param name="id">Identifiant.</param>
        /// <param name="titre">Titre de la publication.</param>
        /// <param name="message">Message.</param>
        /// <param name="publicateur">Publicateur.</param>
        /// <returns>Publication.</returns>
        public IPublication Repondre(int id, string titre, string message, string publicateur)
        {
            var publicationParent = Obtenir(id);

            var pub = Creer(titre, message, publicateur, true);

            publicationParent.Reponses.Add(pub);

            return pub;
        }

        /// <summary>
        /// Supprimer la publication.
        /// </summary>
        /// <param name="id">Identifiant.</param>
        /// <returns>Vrai si l'opération est réussie.</returns>
        public bool Supprimer(int id) =>
            _publications.Remove(Obtenir(id));

        /// <summary>
        /// Créer une instance à partir des paramètres.
        /// </summary>
        /// <param name="titre">Titre de la publication.</param>
        /// <param name="message">Message.</param>
        /// <param name="publicateur">Publicateur.</param>
        /// <returns>Nouvelle instance de publication.</returns>
        private IPublication Creer(string titre, string message, string publicateur, bool estReponse = false)
        {
            var id = 1;

            if (_publications.Any())
            {
                id = _publications.Max(k => k.Id) + 1;
            }

            return new Publication
            {
                Id = id,
                Titre = titre,
                Message = message,
                Publicateur = publicateur,
                Creation = DateTime.Now,
                EstReponse = estReponse
            };
        }
    }
}