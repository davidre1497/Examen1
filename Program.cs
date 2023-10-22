using ExamenRH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        bool salir = false;

        while (!salir)
        {
            menu.MostrarMenuPrincipal();

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                switch (opcion)
                {
                    case 1:
                        menu.AgregarEmpleado();
                        break;
                    case 2:
                        menu.ConsultarEmpleadoPorCedula();
                        break;
                    case 3:
                        menu.ModificarEmpleadoPorCedula();
                        break;
                    case 4:
                        menu.BorrarEmpleadoPorCedula();
                        break;
                    case 5:
                        menu.InicializarArreglos();
                        break;
                    case 6:
                        menu.GenerarReportes();
                        break;
                    case 7:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Introduce una opción válida del menú.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Introduce un número correspondiente a una opción del menú.");
            }
        }
    }
}
