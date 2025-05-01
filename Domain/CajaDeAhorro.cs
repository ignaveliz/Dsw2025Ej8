using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;

public class CajaDeAhorro : CuentaBancaria
{
    public decimal TasaDeInteres { get; set; }
    public CajaDeAhorro(int numero, decimal saldo) : base(numero, saldo) { }

    public override void Depositar(decimal monto)
    {

        if (EstadoCuenta != Estado.Activa)
        {
            throw new CuentaNoActiva(EstadoCuenta);
        }
        if (monto <= 0) throw new MontoNoValido();
        else Saldo += monto;



    }

    public override void Retirar(decimal monto)
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

    public void AplicarInteres()
    {


        if (EstadoCuenta != Estado.Activa)
        {
            throw new CuentaNoActiva(EstadoCuenta);
        }
        else Saldo += Saldo * TasaDeInteres;


    }

}
