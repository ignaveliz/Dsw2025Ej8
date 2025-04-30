using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
   public class CajaDeAhorro: CuentaBancaria
    {
       public decimal TasaDeInteres {  get; init; }
       public CajaDeAhorro (int numero, decimal saldo) : base (numero, saldo) { }

    }
}
