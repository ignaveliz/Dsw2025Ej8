using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain;
public class CuentaCorriente : CuentaBancaria
{
    public decimal LimiteDeDescubierto { get; init; }
    public decimal Comision { get; set; }
    public CuentaCorriente(int numero, decimal saldo) : base(numero, saldo) { }

    public override void Depositar(decimal monto)
    {

        if (EstadoCuenta != Estado.Activa)
        {
            throw new CuentaNoActiva(EstadoCuenta);
        }

        if (monto <= 0) throw new MontoNoValido();
        else
        {
            monto -= monto * Comision;
            Saldo += monto;
        }


    }

    public override void Retirar(decimal monto)
    {

        if (EstadoCuenta != Estado.Activa)
        {
            throw new CuentaNoActiva(EstadoCuenta);
        }

        if (Saldo - monto >= LimiteDeDescubierto)
        {
            Saldo -= monto;
        }
        else
        {
            EstadoCuenta = Estado.Suspendida;
            throw new SaldoInsuficiente();
        }


    }
}
