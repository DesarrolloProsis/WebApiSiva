using System;
using System.Collections.Generic;

namespace WebApiSiva.Entities
{
    public partial class Tags
    {
        public long Id { get; set; }
        public string NumTag { get; set; }
        public decimal SaldoTag { get; set; }
        public bool StatusTag { get; set; }
        public bool StatusResidente { get; set; }
        public DateTime DateTtag { get; set; }
        public long CuentaId { get; set; }
        public string IdCajero { get; set; }

        public virtual CuentasTelepeajes Cuenta { get; set; }
    }
}
