namespace Dsw2025Ej8.Domain;

public class CuentaBancaria
{
    public int Numero { get; private set; }
    public decimal Saldo { get; protected set; }
    public Estado EstadoCuenta { get; set; }
    public string[] Titulares { get; init; }

    public CuentaBancaria (int numero, decimal saldo)
    {
        Numero = numero;
        Saldo = saldo;
        EstadoCuenta = Estado.Activa;
    }

    public virtual void Depositar(decimal monto){  }

    public virtual void  Retirar(decimal monto){ }

    
}
