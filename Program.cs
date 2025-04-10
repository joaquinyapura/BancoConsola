using Entidades;
using LogicaNegocio;

class Program

{
    static void Main()
    {
        var cuentaService = new CuentaService();
        List<Cliente> clientes = new List<Cliente>
        {
            new Cliente
            {
                Id = 1,
                Nombre = "Lucía Fernández",
                Cuenta = new Cuenta
                {
                    NumCuenta = 1001,
                    Saldo = 5000,
                    Movimientos = new List<Movimiento>
                    {
                        new Movimiento { Fecha = DateTime.Now.AddDays(-3), Monto = 3000, Tipo = "Depósito" },
                        new Movimiento { Fecha = DateTime.Now.AddDays(-1), Monto = 1000, Tipo = "Depósito" },
                        new Movimiento { Fecha = DateTime.Now, Monto = 1000, Tipo = "Retiro" },
                    }
                }
            },
            new Cliente
            {
                Id = 2,
                Nombre = "Martina Gómez",
                Cuenta = new Cuenta
                {
                    NumCuenta = 1002,
                    Saldo = 3200,
                    Movimientos = new List<Movimiento>
                    {
                        new Movimiento { Fecha = DateTime.Now.AddDays(-7), Monto = 2000, Tipo = "Depósito" },
                        new Movimiento { Fecha = DateTime.Now.AddDays(-4), Monto = 1500, Tipo = "Depósito" },
                        new Movimiento { Fecha = DateTime.Now.AddDays(-2), Monto = 300, Tipo = "Retiro" },
                    }
                }
            }
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== BANCO DE EJEMPLO ===");
            Console.WriteLine("Seleccione un cliente por ID:");
            foreach (var c in clientes)
            {
                Console.WriteLine($"{c.Id}. {c.Nombre}");
            }
            Console.Write("ID: ");
            string inputId = Console.ReadLine();

            if (!int.TryParse(inputId, out int idSeleccionado))
            {
                Console.WriteLine(" Ingrese un ID válido.");
                Console.ReadKey();
                continue;
            }

            var cliente = clientes.FirstOrDefault(c => c.Id == idSeleccionado);
            if (cliente == null)
            {
                Console.WriteLine(" Cliente no encontrado.");
                Console.ReadKey();
                continue;
            }

            bool enSesion = true;
            while (enSesion)
            {
                Console.Clear();
                Console.WriteLine($"Cliente: {cliente.Nombre} | Cuenta: {cliente.Cuenta.NumCuenta}");
                Console.WriteLine("1. Mostrar saldo");
                Console.WriteLine("2. Depositar dinero");
                Console.WriteLine("3. Retirar dinero");
                Console.WriteLine("4. Ver historial de movimientos");
                Console.WriteLine("5. Cambiar de cliente");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                Console.Clear();

                switch (opcion)
                {
                    case "1":
                        cuentaService.MostrarSaldo(cliente.Cuenta);
                        break;
                    case "2":
                        Console.Write("Ingrese el monto a depositar: ");
                        if (double.TryParse(Console.ReadLine(), out double montoDepo))
                            cuentaService.Depositar(cliente.Cuenta, montoDepo);
                        else
                            Console.WriteLine("❌ Monto inválido.");
                        break;
                    case "3":
                        Console.Write("Ingrese el monto a retirar: ");
                        if (double.TryParse(Console.ReadLine(), out double montoRetiro))
                            cuentaService.Retirar(cliente.Cuenta, montoRetiro);
                        else
                            Console.WriteLine("❌ Monto inválido.");
                        break;
                    case "4":
                        cuentaService.MostrarHistorial(cliente.Cuenta);
                        break;
                    case "5":
                        enSesion = false;
                        break;
                    case "6":
                        Console.WriteLine("Gracias por utilizar el sistema.");
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }



}














