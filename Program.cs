using System;
using System.Collections.Generic;

class Nodo
{
    public string valor;
    public Nodo izquierdo;
    public Nodo derecho;

    public Nodo(string valor)
    {
        this.valor = valor;
        this.izquierdo = null;
        this.derecho = null;
    }
}

class ArbolBinario
{
    public Nodo raiz;

    public ArbolBinario()
    {
        raiz = null;
    }

    public void Insertar(string valor, string padre, string lado)
    {
        if (raiz == null)
        {
            raiz = new Nodo(valor);
            Console.WriteLine($"Nodo raíz '{valor}' insertado.");
            return;
        }

        Nodo nodoPadre = Buscar(raiz, padre);
        if (nodoPadre == null)
        {
            Console.WriteLine($"Error: No se encontró el nodo '{padre}'.");
            return;
        }

        if (lado.ToLower() == "izquierdo")
        {
            if (nodoPadre.izquierdo == null)
            {
                nodoPadre.izquierdo = new Nodo(valor);
                Console.WriteLine($"Nodo '{valor}' insertado a la izquierda de '{padre}'.");
            }
            else
            {
                Console.WriteLine($"Error: '{padre}' ya tiene un hijo izquierdo.");
            }
        }
        else if (lado.ToLower() == "derecho")
        {
            if (nodoPadre.derecho == null)
            {
                nodoPadre.derecho = new Nodo(valor);
                Console.WriteLine($"Nodo '{valor}' insertado a la derecha de '{padre}'.");
            }
            else
            {
                Console.WriteLine($"Error: '{padre}' ya tiene un hijo derecho.");
            }
        }
        else
        {
            Console.WriteLine("Error: La posición debe ser 'izquierdo' o 'derecho'.");
        }
    }

    private Nodo Buscar(Nodo nodo, string valor)
    {
        if (nodo == null) return null;
        if (nodo.valor == valor) return nodo;

        Nodo encontrado = Buscar(nodo.izquierdo, valor);
        if (encontrado == null)
        {
            encontrado = Buscar(nodo.derecho, valor);
        }
        return encontrado;
    }

    public void ImprimirArbol()
    {
        if (raiz == null)
        {
            Console.WriteLine("El árbol está vacío.");
            return;
        }

        Queue<(Nodo, int)> cola = new Queue<(Nodo, int)>();
        cola.Enqueue((raiz, 0));
        int nivelActual = 0;

        while (cola.Count > 0)
        {
            var (nodo, nivel) = cola.Dequeue();

            if (nivel != nivelActual)
            {
                Console.WriteLine();
                nivelActual = nivel;
            }

            Console.Write($"{nodo.valor} ");

            if (nodo.izquierdo != null) cola.Enqueue((nodo.izquierdo, nivel + 1));
            if (nodo.derecho != null) cola.Enqueue((nodo.derecho, nivel + 1));
        }
        Console.WriteLine("\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();

        int opcion;
        do
        {
            Console.WriteLine("\n--- Menú Árbol Binario ---");
            Console.WriteLine("1. Insertar un nuevo nodo");
            Console.WriteLine("2. Imprimir árbol");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.Write("Ingrese el valor del nuevo nodo: ");
                    string valor = Console.ReadLine();

                    if (arbol.raiz == null)
                    {
                        arbol.Insertar(valor, "", "");
                    }
                    else
                    {
                        Console.Write("Ingrese el valor del nodo padre: ");
                        string padre = Console.ReadLine();
                        Console.Write("¿Dónde insertarlo? (izquierdo/derecho): ");
                        string lado = Console.ReadLine();
                        arbol.Insertar(valor, padre, lado);
                    }
                    break;
                case 2:
                    Console.WriteLine("\nÁrbol Binario:");
                    arbol.ImprimirArbol();
                    break;
                case 3:
                    Console.WriteLine("\nSaliendo del programa...");
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Intente nuevamente.");
                    break;
            }
        } while (opcion != 3);
    }
}

