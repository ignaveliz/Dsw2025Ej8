using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class Presentacion
{
    public static void Presentar()
    {
        CajaDeAhorro c1 = new CajaDeAhorro(1, 12500M) { TasaDeInteres = 0.40M, Titulares = new[] { "Ignacio Veliz" } };
        CajaDeAhorro c2 = new CajaDeAhorro(3, 11245M) { TasaDeInteres = 0.50M, Titulares = new[] { "Nadia Rizo" } };
        CuentaCorriente c3 = new CuentaCorriente(2, 19000M) { Comision = 0.05M, LimiteDeDescubierto = 2000M, Titulares = new[] { "Leandro Soria" } };
        CuentaCorriente c4 = new CuentaCorriente(4, 2500000M) { Comision = 0.15M, LimiteDeDescubierto = 4000M, Titulares = new[] { "Gustavo Cerati" } };

        CuentaBancaria[] cuentas = { c1, c2, c3, c4 };

        #region pruebasCajaDeAhorro
        Console.WriteLine("CAJA DE AHORROS\n");

        EjecutarOperacion("Intento de depositar un monto inválido: ", () => c1.Depositar(-500));

        EjecutarOperacion("\nIntento de depositar 1200: ", () => {
            c1.Depositar(1200);
            Console.WriteLine($"El saldo de la cuenta {c1.Numero} luego del deposito es: ${c1.Saldo}");
        });

        EjecutarOperacion("\nIntento de aplicar intereses: ", () => {
            c1.AplicarInteres();
            Console.WriteLine($"El saldo de la cuenta {c1.Numero} luego de aplicar intereses es: ${c1.Saldo}");
        });

        EjecutarOperacion("\nIntento de retirar $2500: ", () => {
            c1.Retirar(2500);
            Console.WriteLine($"El saldo de la cuenta {c1.Numero} luego de retirar dinero es: ${c1.Saldo}");
        });

        EjecutarOperacion("\nIntento de retirar $20000: ", () => {
            c1.Retirar(20000);
            Console.WriteLine($"El saldo de la cuenta {c1.Numero} luego de retirar dinero es: ${c1.Saldo}");
        });

        EjecutarOperacion("\nIntento de realizar una operacion con la cuenta suspendida: ", () => c1.Depositar(20000));
        #endregion

        #region pruebasCuentaCorriente
        Console.WriteLine("\n\nCUENTA CORRIENTE\n");

        EjecutarOperacion("Intento de depositar un monto inválido: ", () => c3.Depositar(0));

        EjecutarOperacion("\nIntento de depositar $2000: ", () => {
            c3.Depositar(2000);
            Console.WriteLine($"El saldo de la cuenta {c3.Numero} luego del deposito es: ${c3.Saldo}");
        });

        EjecutarOperacion("\nIntento de retirar $12500: ", () => {
            c3.Retirar(12500);
            Console.WriteLine($"El saldo de la cuenta {c3.Numero} luego de retirar dinero es: ${c3.Saldo}");
        });

        EjecutarOperacion("\nIntento de retirar $10000: ", () => {
            c3.Retirar(10000);
            Console.WriteLine($"El saldo de la cuenta {c3.Numero} luego de retirar dinero es: ${c3.Saldo}");
        });

        EjecutarOperacion("\nIntento de realizar una operacion con la cuenta suspendida: ", () => c3.Depositar(20000));
        #endregion

        #region resumen de cuentas
        Console.WriteLine("\n\n");
        Console.WriteLine("Resumen de cuentas: \n");

        foreach (var resumen in cuentas.Select(c => new
        {
            Numero = c.Numero,
            Tipo = c.GetType().Name,
            Saldo = c.Saldo
        }))
        {
            Console.WriteLine($"Cuenta: {resumen.Numero}, Tipo: {resumen.Tipo}, Saldo: ${resumen.Saldo}");
        }
        #endregion
    }

    private static void EjecutarOperacion(string mensaje, Action operacion)
    {
        Console.Write(mensaje+" ");
        try 
        {
            operacion();
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }
}
