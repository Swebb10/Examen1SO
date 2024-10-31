using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Examen1SO
{
    class Program
    {
        static object lockBinario = new object();
        static object lockOctal = new object();
        static object lockHexadecimal = new object();

        static void Main(string[] args)
        {
            int numero = 100; 

            Thread hiloBinario = new Thread(() => ConvertirABinario(numero));
            Thread hiloOctal = new Thread(() => ConvertirAOctal(numero));
            Thread hiloHexadecimal = new Thread(() => ConvertirAHexadecimal(numero));

            hiloBinario.Start();
            hiloOctal.Start();
            hiloHexadecimal.Start();

            hiloBinario.Join();
            hiloOctal.Join();
            hiloHexadecimal.Join();

            Console.WriteLine("Conversión completa. Presione una tecla para salir.");
            Console.ReadKey();
        }

        static void ConvertirABinario(int numero)
        {
            lock (lockBinario)
            {
                lock (lockHexadecimal) 
                {
                    Console.WriteLine("Convirtiendo a Binario...");
                    Thread.Sleep(5000);
                    Console.WriteLine($"Binario: {Convert.ToString(numero, 2)}");
                    Console.WriteLine("");
                }
            }
        }

        static void ConvertirAOctal(int numero)
        {
            lock (lockOctal)
            {
                lock (lockBinario) 
                {
                    Console.WriteLine("Convirtiendo a Octal...");
                    Thread.Sleep(5000);
                    Console.WriteLine($"Octal: {Convert.ToString(numero, 8)}");
                    Console.WriteLine("");
                }
            }
        }

        static void ConvertirAHexadecimal(int numero)
        {
            lock (lockHexadecimal)
            {
                lock (lockOctal) 
                {
                    Console.WriteLine("Convirtiendo a Hexadecimal...");
                    Thread.Sleep(5000);
                    Console.WriteLine($"Hexadecimal: {Convert.ToString(numero, 16)}");
                    Console.WriteLine("");
                }
            }
        }
    }
}
