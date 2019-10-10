using System;
using System.Collections.Generic;

namespace WebApiSiva.Entities
{
    public partial class CuentasTelepeajes
    {
        public CuentasTelepeajes()
        {
            Tags = new HashSet<Tags>();
        }

        public long Id { get; set; }
        public string NumCuenta { get; set; }
        public decimal? SaldoCuenta { get; set; }
        public string TypeCuenta { get; set; }
        public bool StatusCuenta { get; set; }
        public bool StatusResidenteCuenta { get; set; }
        public DateTime DateTcuenta { get; set; }
        public long ClienteId { get; set; }
        public string IdCajero { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual ICollection<Tags> Tags { get; set; }
    }
}
