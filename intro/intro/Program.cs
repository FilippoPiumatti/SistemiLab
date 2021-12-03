using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace intro
{
    class Program
    {
        static void Main(string[] args)
        {
            //oggetto thread
            //varie caratteristiche:
            //- li startiamo solo noi
            //- costruttorea accetta 4 overload 
            //- ha get e set
            Thread t1 = new Thread(EseguiAsterischi);

            Console.WriteLine("AVVIO PROGRAMMA [" + DateTime.Now.ToString("hh:mm:ss,fff") + "]");

            t1.Name = "_t1_"; //assegnamo, attreaverso i get e set, un nome personalizzato al thread

            t1.Start();//starta il thread
           // t1.Join();// il thread main aspetta la terminazione di t1, tipo form modale; equivale alla wait() in ANSI c


            for (int i = 0; i < 200; i++)
            {
                Console.Write("+");
            }
           
            Console.WriteLine("FINE PROGRAMMA [" + DateTime.Now.ToString("hh:mm:ss,fff") + "]");
            Console.ReadKey();
        }

        private static void EseguiAsterischi()
        {
            for (int i = 0; i < 200; i++)
            {
                Console.Write("*");//questa è la sezione critica, quando la individuiamo, diamol delle regoloe di esecuzione
            }
        }
    }
}
