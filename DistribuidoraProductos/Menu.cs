using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistribuidoraProductos
{
    internal class Menu
    {
        ControlDatos controlDatos =new ControlDatos();//llamar a clase ControlDatos.
        //método para mostrar menú de opciones.
        public void MostrarMenu()
        {
            string opcionesMenu = "-----Menú control de productos-----\n";
            opcionesMenu += "A.Agregar productos.\n";
            opcionesMenu += "B.Venta de un producto.\n";
            opcionesMenu += "C.Reabastecimiento de un producto.\n";
            opcionesMenu += "D.Actualizar el precio de un producto.\n";
            opcionesMenu += "E.Informar sobre un producto.\n";
            opcionesMenu += "F.Salir.\n";
            opcionesMenu += "---------------------------------------\n";
            opcionesMenu += "Digite una opción:";
            char opcion;


            do
            {
                Console.WriteLine(opcionesMenu);
                opcion = char.Parse(Console.ReadLine().ToUpper());

                switch (opcion)
                {
                    case 'A':
                        controlDatos.Agregar();
                        break;
                    case 'B':
                        controlDatos.VentaProducto(ControlDatos.SolicitarClave());
                        break;
                    case 'C':
                        controlDatos.Reabastecimiento(ControlDatos.SolicitarClave());
                        break;
                    case 'D':
                        controlDatos.ActualizarPrecio(ControlDatos.SolicitarClave());
                        break;
                    case 'E':
                        controlDatos.InformeProducto(ControlDatos.SolicitarClave());
                        break;
                    case 'F':
                        break;
                    default:
                        Console.WriteLine("La opción no existe, intentelo de nuevo.");
                        break;
                }
            } while (!opcion.Equals('F'));
        }
    }
}
