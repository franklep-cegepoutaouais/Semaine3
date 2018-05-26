using RahRahRah.Models.Interfaces;

namespace RahRahRah.Repos.Interfaces
{
    public interface IRepoPublications
    {
        IPublications Obtenir();

        IPublication Obtenir(int id);

        IPublication Ajouter(string titre, string message, string publicateur);

        bool Supprimer(int id);

        IPublication Repondre(int id, string titre, string message, string publicateur);
    }
}
