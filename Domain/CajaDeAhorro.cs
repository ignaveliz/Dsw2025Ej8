using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class CajaDeAhorro: CuentaBancaria
{
   public decimal TasaDeInteres {  get; init; }
   public CajaDeAhorro (int numero, decimal saldo) : base (numero, saldo) { }

    public override void Depositar(decimal monto)
    {
        try
        {
            if (EstadoCuenta != Estado.Activa)
            {
                throw new CuentaNoActiva(EstadoCuenta);
            }
            if (monto <= 0) throw new MontoNoValido();
            else Saldo += monto;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    public override void Retirar(decimal monto)
    {
        try
        {
            if (EstadoCuenta != Estado.Activa)
            {
                throw new CuentaNoActiva(EstadoCuenta);
            }
            if (monto <= 0) throw new MontoNoValido();
            else if (Saldo - monto >= 0) Saldo -= monto;
            else
            {
                EstadoCuenta = Estado.Suspendida;
                throw new SaldoInsuficiente();
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }

    }

    public void AplicarInteres()
    {
        try
        {
            if (EstadoCuenta != Estado.Activa)
            {
                throw new CuentaNoActiva(EstadoCuenta);
            }
            else Saldo += Saldo * TasaDeInteres;
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }

    }

}
