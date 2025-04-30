using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{


    public class CuentaCorriente : CuentaBancaria
    {
        public decimal LimiteDeDescubierto {  get; init; }
        public decimal Comision {  get; set; }
        public CuentaCorriente(int numero, decimal saldo ) : base(numero,saldo) { }
    }


}
