using System;
using System.Collections.Generic;

namespace WebApiSiva.Entities
{
    public partial class Operadores
    {
        public Operadores()
        {
            Historico = new HashSet<Historico>();
        }

        public byte IdOperador { get; set; }
        public string Operador { get; set; }

        public virtual ICollection<Historico> Historico { get; set; }
    }
}
