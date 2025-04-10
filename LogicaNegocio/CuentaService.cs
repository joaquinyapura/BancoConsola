using Entidades;

namespace LogicaNegocio
{
    public class CuentaService
    {
        public void Depositar(Cuenta cuenta, Double importe)
        {


            if (importe > 0)
            {

                cuenta.Saldo += importe;
                cuenta.Movimientos.Add(new Movimiento
                {
                    Fecha = DateTime.Today,
                    Monto = importe,
                    Tipo = "Deposito"
                });
                Console.WriteLine($"el Deposito de {importe:C} fue procesado correctamente");
                Console.WriteLine($"su nuevo saldo es de  {cuenta.Saldo:C} ");
            }
            else
            {
                Console.WriteLine("el Deposito debe ser mayor a $0");
            }
            ;
        }


        public void Retirar(Cuenta cuenta, Double importe)
        {
            if (importe <= cuenta.Saldo)
            {

                cuenta.Saldo -= importe;

                cuenta.Movimientos.Add(new Movimiento
                {
                    Fecha = DateTime.Now,
                    Monto = importe,
                    Tipo = "Retiro"
                });

                Console.WriteLine($"Su retiro de {importe:C} se efecuó correctamente");
                Console.WriteLine($"Su nuevo saldo es de  {cuenta.Saldo:C}");

            }
        }

        public void MostrarSaldo(Cuenta cuenta)
        {
            Console.WriteLine($"Su saldo actual es de {cuenta.Saldo} ");
        }
        public void MostrarHistorial(Cuenta cuenta)
        {
            Console.WriteLine("Historial de transacciones");
            Console.WriteLine("--------------------------");
            foreach (var mov in cuenta.Movimientos)
            {

                Console.WriteLine($" {mov.Fecha.ToShortDateString()} | {mov.Tipo} | {mov.Monto:C} ");
                Console.WriteLine("--------------------------");
            }
        }
    }
}