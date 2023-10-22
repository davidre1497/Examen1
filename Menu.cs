using ExamenRH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenRH
{
    class Menu
    {
        private List<Empleado> empleados = new List<Empleado>();

        public void MostrarMenuPrincipal()
        {
            Console.WriteLine("----- Menú Principal -----");
            Console.WriteLine("1. Agregar Empleados");
            Console.WriteLine("2. Consultar Empleados");
            Console.WriteLine("3. Modificar Empleados");
            Console.WriteLine("4. Borrar Empleados");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Generar Reportes");
            Console.WriteLine("7. Salir");
            Console.Write("Selecciona una opción: ");
        }

        public void AgregarEmpleado()
        {
            Console.WriteLine("----- Agregar Empleado -----");
            Console.Write("Cédula: ");
            string cedula = Console.ReadLine();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();
            Console.Write("Salario: ");
            if (double.TryParse(Console.ReadLine(), out double salario))
            {
                Empleado nuevoEmpleado = new Empleado(cedula, nombre, direccion, telefono, salario);
                empleados.Add(nuevoEmpleado);
                Console.WriteLine("Empleado agregado con éxito.");
            }
            else
            {
                Console.WriteLine("Salario no válido.");
            }
        }

        public void ConsultarEmpleadoPorCedula()
        {
            Console.WriteLine("----- Consultar Empleado por Cédula -----");
            Console.Write("Cédula del empleado a consultar: ");
            string cedula = Console.ReadLine();
            Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (empleado != null)
            {
                Console.WriteLine("Cédula: " + empleado.Cedula);
                Console.WriteLine("Nombre: " + empleado.Nombre);
                Console.WriteLine("Dirección: " + empleado.Direccion);
                Console.WriteLine("Teléfono: " + empleado.Telefono);
                Console.WriteLine("Salario: " + empleado.Salario);
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void ModificarEmpleadoPorCedula()
        {
            Console.WriteLine("----- Modificar Empleado por Cédula -----");
            Console.Write("Cédula del empleado a modificar: ");
            string cedula = Console.ReadLine();
            Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (empleado != null)
            {
                Console.Write("Nuevo nombre: ");
                empleado.Nombre = Console.ReadLine();
                Console.Write("Nueva dirección: ");
                empleado.Direccion = Console.ReadLine();
                Console.Write("Nuevo teléfono: ");
                empleado.Telefono = Console.ReadLine();
                Console.Write("Nuevo salario: ");
                if (double.TryParse(Console.ReadLine(), out double nuevoSalario))
                {
                    empleado.Salario = nuevoSalario;
                    Console.WriteLine("Empleado modificado con éxito.");
                }
                else
                {
                    Console.WriteLine("Salario no válido.");
                }
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void BorrarEmpleadoPorCedula()
        {
            Console.WriteLine("----- Borrar Empleado por Cédula -----");
            Console.Write("Cédula del empleado a borrar: ");
            string cedula = Console.ReadLine();
            Empleado empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);
            if (empleado != null)
            {
                empleados.Remove(empleado);
                Console.WriteLine("Empleado borrado con éxito.");
            }
            else
            {
                Console.WriteLine("Empleado no encontrado.");
            }
        }

        public void InicializarArreglos()
        {
            var empleadosIniciales = new Empleado[]
            {
                new Empleado("001", "Juan", "Dirección 1", "123456789", 2500.0),
                new Empleado("002", "María", "Dirección 2", "987654321", 3000.0)
            };
            empleados.AddRange(empleadosIniciales);
            Console.WriteLine("Arreglos inicializados.");
        }
        public void ListarEmpleadosOrdenadosPorNombre()
        {
            Console.WriteLine("----- Listar Empleados Ordenados por Nombre -----");
            if (empleados.Count > 0)
            {
                var empleadosOrdenados = empleados.OrderBy(e => e.Nombre).ToList();
                foreach (var empleado in empleadosOrdenados)
                {
                    Console.WriteLine("Cédula: " + empleado.Cedula);
                    Console.WriteLine("Nombre: " + empleado.Nombre);
                    Console.WriteLine("Dirección: " + empleado.Direccion);
                    Console.WriteLine("Teléfono: " + empleado.Telefono);
                    Console.WriteLine("Salario: " + empleado.Salario);
                    Console.WriteLine("------------");
                }
            }
            else
            {
                Console.WriteLine("No hay empleados para listar.");
            }
        }
        public void GenerarReportes()
                {
                    Console.WriteLine("----- Menú de Reportes -----");
                    Console.WriteLine("1. Consultar empleados con número de cédula.");
                    Console.WriteLine("2. Listar todos los empleados ordenados por nombre.");
                    Console.WriteLine("3. Calcular y mostrar el promedio de los salarios.");
                    Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo.");
                    Console.WriteLine("5. Volver al menú principal");
                    Console.Write("Selecciona una opción de reporte: ");

                    int opcion;
                    if (int.TryParse(Console.ReadLine(), out opcion))
                    {
                        switch (opcion)
                        {
                            case 1:
                                ConsultarEmpleadoPorCedula();
                                break;
                            case 2:
                                ListarEmpleadosOrdenadosPorNombre();
                                break;
                            case 3:
                                CalcularPromedioDeSalarios();
                                break;
                            case 4:
                                CalcularSalarioMaximoMinimo();
                                break;
                            case 5:
                                VolverMenúPrincipal();
                                break;
                            default:
                                Console.WriteLine("Opción no válida. Introduce una opción válida del menú.");
                                break;
                        }
                    }

                    else
                    {
                        Console.WriteLine("Entrada no válida. Introduce un número correspondiente a una opción.");
                    }
                }

                private void CalcularSalarioMaximoMinimo()
                {
                    Console.WriteLine("----- Calcular Salario Máximo y Mínimo -----");
                    if (empleados.Count > 0)
                    {
                        double salarioMaximo = empleados.Max(e => e.Salario);
                        double salarioMinimo = empleados.Min(e => e.Salario);
                        Console.WriteLine("Salario más alto: " + salarioMaximo);
                        Console.WriteLine("Salario más bajo: " + salarioMinimo);
                    }
                    else
                    {
                        Console.WriteLine("No hay empleados para calcular los salarios máximo y mínimo.");
                    }
                }

                private void CalcularPromedioDeSalarios()
                {
                    Console.WriteLine("----- Calcular Promedio de Salarios -----");
                    if (empleados.Count > 0)
                    {
                        double promedio = empleados.Average(e => e.Salario);
                        Console.WriteLine("El promedio de los salarios es: " + promedio);
                    }
                    else
                    {
                        Console.WriteLine("No hay empleados para calcular el promedio.");
            }
        }
        private void VolverMenúPrincipal()
                {
            {
                Console.WriteLine("Volviendo al Menú Principal...");
                MostrarMenuPrincipal();
            }
                    }
                }
            }
        
    
