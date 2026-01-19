using System;
using System.Collections.Generic;

namespace EstructurasDatos_pilas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Quitamos el Clear() para evitar el error de "Controlador no válido"
            Console.WriteLine("--- TAREA DE PILAS (STACKS) ---");
            Console.WriteLine("1. Verificar Parentesis");
            Console.WriteLine("2. Torres de Hanoi");
            Console.Write("Elija opcion (1 o 2): ");

            string entrada = Console.ReadLine();

            if (entrada == "1")
            {
                EjecutarParentesis();
            }
            else if (entrada == "2")
            {
                EjecutarHanoi();
            }

            Console.WriteLine("\nPrograma finalizado. Presione Enter para cerrar.");
            Console.ReadLine();
        }

        static void EjecutarParentesis()
        {
            Console.WriteLine("\nIngrese la expresion:");
            string exp = Console.ReadLine();
            Stack<char> pila = new Stack<char>();
            bool balanceado = true;

            foreach (char c in exp)
            {
                if (c == '(' || c == '[' || c == '{') pila.Push(c);
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (pila.Count == 0) { balanceado = false; break; }
                    char ant = pila.Pop();
                    if ((c == ')' && ant != '(') || (c == ']' && ant != '[') || (c == '}' && ant != '{'))
                    { balanceado = false; break; }
                }
            }
            if (balanceado && pila.Count == 0) Console.WriteLine(">>> Formula balanceada.");
            else Console.WriteLine(">>> Formula NO balanceada.");
        }

        static void EjecutarHanoi()
        {
            Console.Write("\nNumero de discos: ");
            int n = int.Parse(Console.ReadLine());
            ResolverHanoi(n, 'A', 'B', 'C');
        }

        static void ResolverHanoi(int n, char origen, char aux, char dest)
        {
            if (n == 1) { Console.WriteLine($"Mover disco 1 de {origen} a {dest}"); return; }
            ResolverHanoi(n - 1, origen, dest, aux);
            Console.WriteLine($"Mover disco {n} de {origen} a {dest}");
            ResolverHanoi(n - 1, aux, origen, dest);
        }
    }
}