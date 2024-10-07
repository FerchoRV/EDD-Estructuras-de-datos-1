namespace FundamentosListasDobles
{
    public class ListasDobleEnlazada<T>
    {
        private Nodo<T> cabeza;
        private Nodo<T> cola;

        public ListasDobleEnlazada()
        {
            cabeza = null;
            cola = null;
        }

        public void InsertarAlPrincipio(T valor)
        {
            Nodo<T> nuevoNodo = new Nodo<T>(valor);
            if (cabeza == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = cabeza;
                cabeza.Anterior = nuevoNodo;
                cabeza = nuevoNodo;
            }
        }

        public void InsertarAlFinal(T valor)
        {
            Nodo<T> nuevoNodo = new Nodo<T>(valor);
            if (cola == null)
            {
                cabeza = nuevoNodo;
                cola = nuevoNodo;
            }
            else
            {
                cola.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = cola;
                cola = nuevoNodo;
            }
        }

        public void InsertarEnPosicion(T valor, int posicion)
        {
            if (posicion == 0)
            {
                InsertarAlPrincipio(valor);
                return;
            }

            Nodo<T> nuevoNodo = new Nodo<T>(valor);
            Nodo<T> actual = cabeza;
            int contador = 0;

            while (actual != null && contador < posicion - 1)
            {
                actual = actual.Siguiente;
                contador++;
            }

            if (actual == null)
            {
                InsertarAlFinal(valor);
            }
            else
            {
                nuevoNodo.Siguiente = actual.Siguiente;
                if (actual.Siguiente != null)
                {
                    actual.Siguiente.Anterior = nuevoNodo;
                }
                actual.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = actual;
            }
        }

        public void EliminarAlPrincipio()
        {
            if (cabeza != null)
            {
                if (cabeza.Siguiente == null)
                {
                    cabeza = null;
                    cola = null;
                }
                else
                {
                    cabeza = cabeza.Siguiente;
                    cabeza.Anterior = null;
                }
            }
        }

        public void EliminarAlFinal()
        {
            if (cola != null)
            {
                if (cola.Anterior == null)
                {
                    cabeza = null;
                    cola = null;
                }
                else
                {
                    cola = cola.Anterior;
                    cola.Siguiente = null;
                }
            }
        }

        public void EliminarEnPosicion(int posicion)
        {
            if (posicion == 0)
            {
                EliminarAlPrincipio();
                return;
            }

            Nodo<T> actual = cabeza;
            int contador = 0;

            while (actual != null && contador < posicion)
            {
                actual = actual.Siguiente;
                contador++;
            }

            if (actual != null && actual.Anterior != null)
            {
                actual.Anterior.Siguiente = actual.Siguiente;
                if (actual.Siguiente != null)
                {
                    actual.Siguiente.Anterior = actual.Anterior;
                }
            }
        }

        public void RecorrerHaciaAdelante()
        {
            Nodo<T> actual = cabeza;
            while (actual != null)
            {
                System.Console.WriteLine(actual.Valor);
                actual = actual.Siguiente;
            }
        }

        public void RecorrerHaciaAtras()
        {
            Nodo<T> actual = cola;
            while (actual != null)
            {
                System.Console.WriteLine(actual.Valor);
                actual = actual.Anterior;
            }
        }

        // Implementación del TDA de búsqueda
        public Nodo<T> BuscarElemento(T valor)
        {
            if (cabeza == null)
            {
                System.Console.WriteLine("La lista está vacía");
                return null;
            }

            Nodo<T> nodoDesdeCabeza = cabeza;  // Empezamos desde la cabeza
            Nodo<T> nodoDesdeCola = cola;      // Empezamos desde la cola

            while (nodoDesdeCabeza != null && nodoDesdeCola != null)
            {
                // Si encontramos el valor desde la cabeza
                if (nodoDesdeCabeza.Valor.Equals(valor))
                {
                    System.Console.WriteLine("Elemento encontrado desde la cabeza");
                    return nodoDesdeCabeza;  // Retorna el nodo encontrado
                }

                // Si encontramos el valor desde la cola
                if (nodoDesdeCola.Valor.Equals(valor))
                {
                    System.Console.WriteLine("Elemento encontrado desde la cola");
                    return nodoDesdeCola;  // Retorna el nodo encontrado
                }

                // Si los dos punteros se encuentran, el valor no está en la lista
                if (nodoDesdeCabeza == nodoDesdeCola || nodoDesdeCabeza.Siguiente == nodoDesdeCola)
                {
                    System.Console.WriteLine("Elemento no encontrado en la lista");
                    return null;  // Retorna null si no se encuentra el valor
                }

                // Avanzamos desde la cabeza
                nodoDesdeCabeza = nodoDesdeCabeza.Siguiente;

                // Avanzamos desde la cola
                nodoDesdeCola = nodoDesdeCola.Anterior;
            }

            System.Console.WriteLine("Elemento no encontrado en la lista");
            return null;  // Retorna null si no se encuentra el valor
        }
    }
}
