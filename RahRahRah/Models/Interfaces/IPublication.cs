using System;
using System.Collections.Generic;

namespace RahRahRah.Models.Interfaces
{
    public interface IPublication
    {
        int Id { get; }

        string Titre { get; }

        string Message { get; }

        string Publicateur { get; }

        DateTime Creation { get; }

        IEnumerable<IPublication> Reponses { get; }
    }
}
