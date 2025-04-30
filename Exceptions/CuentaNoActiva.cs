using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    public class CuentaNoActiva : Exception
    {
        public CuentaNoActiva(Estado estado) : base($"No se puede operar con la cuenta {estado}") { }
    }
}
