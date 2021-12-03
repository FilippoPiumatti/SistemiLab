using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutuaEsclusione
{
    class Program
    {
        const int MAX_INTERAZIONI = 1000000;
        static int n; //Variabile condivisa
        static SemaphoreSlim sem = new SemaphoreSlim(1); // semaforo binario visto in classe, accetta un parametro ed e l inizializzazione di esso. verde1 o rosso0?
        static void Main(string[] args)
        {
            Console.WriteLine("AVVIO PROGRAMMA [" + DateTime.Now.ToString("hh:mm:ss,fff") + "]");
            n = 0;

            Parallel.Invoke(incrementa,decrementa);//questo metodo della classe parallel
            //permette di invocare due metodi in parallelo, stoppando il main trhead(wait)


            Console.WriteLine("TERMINE PROGRAMMA [" + DateTime.Now.ToString("hh:mm:ss,fff") + "]");

            Console.WriteLine("N: " + n.ToString());

            Console.ReadKey();
        }

        public static void incrementa()
        {
            int i , temp;
            i = 0;
            while (i<MAX_INTERAZIONI)
            {   /*SEZIONE CRITICA*/
                sem.Wait();
                temp = n; // salvo n in variabile locale
                temp = temp + 1;// incremento
                n = temp;//  ricarico il valore modificato in n
                sem.Release();
                /* FINE SEZIONE CRITICA*/

                i++;
            }
            
        }

        public static void decrementa()
        {
            int i, temp;
            i = 0;
            while (i < MAX_INTERAZIONI)
            {
                sem.Wait();
                /*SEZIONE CRITICA*/

                temp = n; // salvo n in variabile locale
                temp = temp - 1;// incremento
                n = temp;//  ricarico il valore modificato in n
                /*FINE SEZIONE CRITICA*/
                sem.Release();

                i++;
            }
            
        }
    }
}
