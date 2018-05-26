using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RahRahRah.Models
{
    public class Publications : Collection<Interfaces.IPublication>, Interfaces.IPublications
    {
        public Publications() : base()
        {

        }

        public Publications(IList<Interfaces.IPublication> pubs) : base(pubs)
        {

        }
    }
}