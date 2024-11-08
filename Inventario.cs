using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeInventariosDeProductos
{
    public class Inventario
    {
        private List<Producto> productos = new List<Producto>();

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
            Console.WriteLine($"Producto '{producto.Nombre}' agregado al inventario.");
        }

        public IEnumerable<Producto> FiltrarPorPrecio(decimal precioMinimo)
        {
            return productos.Where(p => p.Precio > precioMinimo).OrderBy(p => p.Precio);
        }

        public void ActualizarPrecio(string nombre, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine($"Precio del producto '{nombre}' actualizado a {nuevoPrecio:C}");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void EliminarProducto(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"Producto '{nombre}' eliminado.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }

        public void ContarYAgruparProductos()
        {
            var grupo = new
            {
                MenoresA100 = productos.Count(p => p.Precio < 100),
                Entre100Y500 = productos.Count(p => p.Precio >= 100 && p.Precio <= 500),
                MayoresA500 = productos.Count(p => p.Precio > 500)
            };
            Console.WriteLine($"Productos menores a $100: {grupo.MenoresA100}");
            Console.WriteLine($"Productos entre $100 y $500: {grupo.Entre100Y500}");
            Console.WriteLine($"Productos mayores a $500: {grupo.MayoresA500}");
        }

        public void ReporteInventario()
        {
            Console.WriteLine($"Total de productos: {productos.Count}");
            Console.WriteLine($"Precio promedio: {productos.Average(p => p.Precio):C}");
            if (productos.Any())
            {
                var precioMin = productos.MinBy(p => p.Precio);
                var precioMax = productos.MaxBy(p => p.Precio);
                Console.WriteLine($"Producto más barato: {precioMin.Nombre} - {precioMin.Precio:C}");
                Console.WriteLine($"Producto más caro: {precioMax.Nombre} - {precioMax.Precio:C}");
            }
            else
            {
                Console.WriteLine("No hay productos en el inventario.");
            }
        }
    }

}
