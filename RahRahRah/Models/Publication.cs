using RahRahRah.Models.Interfaces;
using System;

namespace RahRahRah.Models
{
    public class Publication : IPublication
    {
        public int Id { get; set; }

        public string Titre { get; set; }

        public string Message { get; set; }

        public string Publicateur { get; set; }

        public DateTime Creation { get; set; }

        public IPublications Reponses { get; } = new Publications();

        public bool EstReponse { get; set; }
    }
}