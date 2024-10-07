using System;
using FundamentosListasDobles;  // Importa el namespace del proyecto

namespace FundamentosListasDobles
{
    class Program
    {
        static void Main()
        {
            ListaDoblementeEnlazada<int> lista = new ListaDoblementeEnlazada<int>();

            lista.InsertarAlFinal(10);
            lista.InsertarAlFinal(20);
            lista.InsertarAlFinal(30);
            lista.InsertarAlPrincipio(5);
            lista.InsertarEnPosicion(15, 2);

            Console.WriteLine("Recorrer hacia adelante:");
            lista.RecorrerHaciaAdelante();

            lista.EliminarEnPosicion(2);

            Console.WriteLine("\nDespués de eliminar en la posición 2:");
            lista.RecorrerHaciaAdelante();
        }
    }
}
