using System;
using System.Collections.Generic;

namespace WebApiSiva.Entities
{
    public partial class OperacionesSerBipagos
    {
        public long Id { get; set; }
        public string NumAutoriProveedor { get; set; }
        public string NumAutoriBanco { get; set; }
        public double? SaldoAnterior { get; set; }
        public double? SaldoModificar { get; set; }
        public double? SaldoActual { get; set; }
        public bool StatusOperacion { get; set; }
        public DateTime DateTopSerBi { get; set; }
        public string Numero { get; set; }
        public string NoReferencia { get; set; }
        public string Tipo { get; set; }
        public string Concepto { get; set; }
    }
}
