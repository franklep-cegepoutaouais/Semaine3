using RahRahRah.Models.Interfaces;
using System.Collections.Generic;

namespace RahRahRah.Repos.Interfaces
{
    public interface IRepoPublications
    {
        IPublications Obtenir();

        IPublication Obtenir(int id);

        bool Ajouter(string titre, string message, string publicateur);

        bool Supprimer(int id);

        bool Repondre(int id, string titre, string message, string publicateur);
    }
}
