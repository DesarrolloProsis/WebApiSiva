using System;
using System.Collections.Generic;

namespace WebApiSiva.Entities
{
    public partial class ListaNegra
    {
        public long Id { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public string Observacion { get; set; }
        public double? SaldoAnterior { get; set; }
        public DateTime Date { get; set; }
        public string IdCajero { get; set; }
        public string Clase { get; set; }
        public string NumCliente { get; set; }
        public string NumCuenta { get; set; }
    }
}
