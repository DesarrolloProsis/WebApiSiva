using System;
using System.Collections.Generic;

namespace WebApiSiva.Entities
{
    public partial class TipoVehiculo
    {
        public TipoVehiculo()
        {
            Historico = new HashSet<Historico>();
        }

        public byte IdTipoVehiculo { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Historico> Historico { get; set; }
    }
}
