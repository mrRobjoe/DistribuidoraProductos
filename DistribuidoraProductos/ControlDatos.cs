using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraProductos
{
    internal class ControlDatos
    {
        static string[] clave = new string[10];
        static string[] descripcion = new string[10];
        static int[] existencia = new int[10];
        static int[] minimoExistencia = new int[10];
        static float[] precioUnitario = new float[10];
        static int indice=0;

        //método para agregar los datos.
        public void Agregar()
        {
            string continuar;
            try
            {
                do
                {
                    Console.WriteLine("Ingrese la clave: ");
                    clave[indice] = Console.ReadLine();
                    Console.WriteLine("Ingrese la descripción del producto: ");
                    descripcion[indice] = Console.ReadLine();
                    Console.WriteLine("Agregar la cantidad: ");
                    existencia[indice] = int.Parse(Console.ReadLine());
                    Console.WriteLine("Agregue el mínimo a mantener de existencia: ");
                    minimoExistencia[indice] = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite el precio unitario: ");
                    precioUnitario[indice] = float.Parse(Console.ReadLine());
                    indice++;
                    Console.WriteLine("Desea continuar agregando? (Si/No)");
                    continuar = Console.ReadLine().ToLower();

                } while (!continuar.Equals("no"));
            }
            catch (Exception)
            {
                Console.WriteLine("Ha llegado al límite, no puede agregar más productos.");
            }
        }


        //método para solicitar la clave que representa a cada producto.
        public static string SolicitarClave()
        {
            Console.WriteLine("Ingrese la clave: ");
            string clave = Console.ReadLine();

            return clave;
        }
        //método que realiza la venta de un producto.
        public void VentaProducto(string clav)
        {
            int i = 0;
            int cantidadVendida;
            int inventarioFinal;
            while ((i <= indice) && (!clav.Equals(clave[i])))
            {
                i++;
            }
            if (i>indice)
            {
                Console.WriteLine("La clave digitada es inexistente");
            }
            else
            {
                Console.WriteLine("Digite la cantidad a vender: ");
                cantidadVendida = int.Parse(Console.ReadLine());
                inventarioFinal = existencia[i] - cantidadVendida;
                if (inventarioFinal >= minimoExistencia[i])
                {
                    existencia[i] = inventarioFinal;
                }
                else
                {
                    Console.WriteLine("La venta no es posible porque el inventario final es menor al mínimo a mantener " +
                        "en existencia en inventario, intente la venta de nuevo.");
                }
            }
        }

        //método que reabastese el inventario de un producto.
        public void Reabastecimiento(string clavee)
        {
            int i = 0;
            int cantidadComprada;
            while ((i <= indice) && (!clavee.Equals(clave[i])))
            {
                i++;
            }
            if (i>indice)
            {
                Console.WriteLine("La clave digitada es inexistente.");
            }
            else
            {
                Console.WriteLine("Digite la cantidad a comprar: ");
                cantidadComprada = int.Parse(Console.ReadLine());
                existencia[i] += cantidadComprada;
            }
        }

        //método para actualizar el precio de un producto según el porcentaje que se ingrese.
        public void ActualizarPrecio(string clavv)
        {
            int i = 0;
            float porcentajeAumento;
            float totalCalculo;
            while ((i <= indice) && (!clavv.Equals(clave[i])))
            {
                i++;
            }
            if (i>indice)
            {
                Console.WriteLine("La clave digitada es inexistente.");
            }
            else
            {
                Console.WriteLine("Digite el porcentaje a aumentar en el precio del producto (Ejemplo: 10): ");
                porcentajeAumento = float.Parse(Console.ReadLine());
                totalCalculo = (precioUnitario[i] * (porcentajeAumento/100));
                precioUnitario[i] += totalCalculo;
            }
        }

        //método para dar información de un producto en especifico.<, según la clave
        public void InformeProducto(string cl)
        {
            int i = 0;
            while ((i <= indice) && (!cl.Equals(clave[i])))
            {
                i++;
            }
            if (i>indice)
            {
                Console.WriteLine("La clave digitada es inexistente.");
            }
            else
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine($"Reporte del producto: \nClave: {clave[i]} \n Descipción: {descripcion[i]}\n " +
                    $"Inventario existente: {existencia[i]}\n Inventario mínimo a mantener en existencia: {minimoExistencia[i]}" +
                    $"\n Precio unitario: {precioUnitario[i]}"); 
            }
        }  
    }
}
