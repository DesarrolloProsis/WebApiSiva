using System;
using System.Collections.Generic;

namespace WebApiSiva.Entities
{
    public partial class Carriles
    {
        public Carriles()
        {
            Historico = new HashSet<Historico>();
        }

        public string Carril { get; set; }
        public byte IdGare { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual ICollection<Historico> Historico { get; set; }
    }
}
