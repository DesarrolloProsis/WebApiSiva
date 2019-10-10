using System;
using System.Collections.Generic;

namespace WebApiSiva.Entities
{
    public partial class Historico
    {
        public string Carril { get; set; }
        public DateTime Fecha { get; set; }
        public string Tag { get; set; }
        public decimal Cargo { get; set; }
        public int Evento { get; set; }
        public decimal SaldoAnterior { get; set; }
        public decimal SaldoActualizado { get; set; }
        public string NumeroCuenta { get; set; }
        public byte IdLocation { get; set; }
        public byte IdClase { get; set; }
        public byte IdOperador { get; set; }

        public virtual Carriles CarrilNavigation { get; set; }
        public virtual TipoVehiculo IdClaseNavigation { get; set; }
        public virtual Location IdLocationNavigation { get; set; }
        public virtual Operadores IdOperadorNavigation { get; set; }
    }
}
