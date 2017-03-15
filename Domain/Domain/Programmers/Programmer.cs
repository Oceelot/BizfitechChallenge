using System;
using System.Collections.Generic;
using Domain.Languages;

namespace Domain.Programmers
{
    public class Programmer : Entity
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string BlogUrl { get; set; }

        public virtual ICollection<Language>  Languages { get; private set; }

        public Programmer()
        {
            Languages = new List<Language>();
        }
    }
}
