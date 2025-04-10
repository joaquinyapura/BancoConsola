namespace Entidades
{
    public class Cuenta
    {
        public int NumCuenta { get; set; }
        public double Saldo { get; set; }
        public List<Movimiento> Movimientos { get; set; } = new List<Movimiento>();

    }
}