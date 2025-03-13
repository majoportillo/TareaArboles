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

    public void preOrden(Nodo nodo)
    {
        if(nodo != null)
        {
            Console.WriteLine(nodo.valor + "");
            preOrden(nodo.izquierdo);
            preOrden(nodo.derecho);
        }
    }

    public void InOrden(Nodo nodo)
    {
        if (nodo != null)
        {
            InOrden(nodo.izquierdo);
            Console.Write(nodo.valor + "");
            InOrden(nodo.derecho);
        }
    }
    public void postOrden(Nodo nodo)
    {
         if (nodo != null)
        {
            postOrden(nodo.izquierdo);
            postOrden(nodo.derecho);
            Console.Write(nodo.valor + "");
        }

    }
}
class Program
{
    static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();
        //Crear arbol binario
        arbol.raiz = new Nodo("A");
        arbol.raiz.izquierdo = new Nodo("B");
        arbol.raiz.derecho = new Nodo("C");
        arbol.raiz.izquierdo.izquierdo = new Nodo("D");
        arbol.raiz.izquierdo.derecho = new Nodo("E");
        arbol.raiz.derecho.izquierdo = new Nodo("F");
        arbol.raiz.derecho.derecho = new Nodo("G");
        
    }
}