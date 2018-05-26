using System;

namespace RahRahRah.Models.Interfaces
{
    public interface IPublication
    {
        int Id { get; }

        string Titre { get; }

        string Message { get; }

        string Publicateur { get; }

        DateTime Creation { get; }

        IPublications Reponses { get; }

        bool EstReponse { get; }
    }
}
