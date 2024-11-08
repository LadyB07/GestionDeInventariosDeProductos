using GestionDeInventariosDeProductos;
using System;

public class Program
{
    public static void Main(string[] args)
    {
            Inventario inventario = new Inventario();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n--- Menú de Inventario ---");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Filtrar Productos por Precio");
                Console.WriteLine("3. Actualizar Precio de Producto");
                Console.WriteLine("4. Eliminar Producto");
                Console.WriteLine("5. Contar y Agrupar Productos por Precio");
                Console.WriteLine("6. Reporte del Inventario");
                Console.WriteLine("7. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            AgregarProducto(inventario);
                            break;
                        case 2:
                            FiltrarProductos(inventario);
                            break;
                        case 3:
                            ActualizarPrecioProducto(inventario);
                            break;
                        case 4:
                            EliminarProducto(inventario);
                            break;
                        case 5:
                            inventario.ContarYAgruparProductos();
                            break;
                        case 6:
                            inventario.ReporteInventario();
                            break;
                        case 7:
                            continuar = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida. Intente nuevamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Seleccione una opción numérica.");
                }
            }
        }

        private static void AgregarProducto(Inventario inventario)
        {
            Console.Write("Nombre del producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Precio del producto: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal precio) && precio > 0)
            {
                inventario.AgregarProducto(new Producto(nombre, precio));
            }
            else
            {
                Console.WriteLine("Precio inválido. Debe ser un número positivo.");
            }
        }

        private static void FiltrarProductos(Inventario inventario)
        {
            Console.Write("Ingrese el precio mínimo para filtrar productos: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal precioFiltro))
            {
                var productosFiltrados = inventario.FiltrarPorPrecio(precioFiltro);
                Console.WriteLine("Productos filtrados:");
                foreach (var producto in productosFiltrados)
                {
                    producto.MostrarInformacion();
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida. Asegúrese de ingresar un número.");
            }
        }

        private static void ActualizarPrecioProducto(Inventario inventario)
        {
            Console.Write("Ingrese el nombre del producto a actualizar: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el nuevo precio: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal nuevoPrecio) && nuevoPrecio > 0)
            {
                inventario.ActualizarPrecio(nombre, nuevoPrecio);
            }
            else
            {
                Console.WriteLine("Precio inválido. Debe ser un número positivo.");
            }
        }

        private static void EliminarProducto(Inventario inventario)
        {
            Console.Write("Ingrese el nombre del producto a eliminar: ");
            string nombre = Console.ReadLine();
            inventario.EliminarProducto(nombre);
        }
    }
