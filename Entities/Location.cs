using System;
using System.Collections.Generic;

namespace WebApiSiva.Entities
{
    public partial class Location
    {
        public Location()
        {
            Historico = new HashSet<Historico>();
        }

        public byte IdLocation { get; set; }
        public string Delegacion { get; set; }
        public string Plaza { get; set; }

        public virtual ICollection<Historico> Historico { get; set; }
    }
}
