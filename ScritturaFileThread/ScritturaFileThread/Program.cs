using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;
namespace ScritturaFileThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(EseguiScrittura);
            StreamWriter sw;
            Console.WriteLine("AVVIO PROGRAMMA [" + DateTime.Now.ToString("hh:mm:ss, fff") + "]");
            t1.Name = "_t1_";
            t1.Start();
            sw = new StreamWriter("file_Main.txt");
            for (int i = 0; i < 20000000; i++)
            {
                sw.Write("+");
            }
            sw.Close();
            Console.WriteLine("FINE PROGRAMMA [" + DateTime.Now.ToString("hh:mm:ss , fff") + "]");
            Console.ReadKey();
            Process.Start("file_Main.txt");
            Process.Start("file_thread.txt");
        }

        private static void EseguiScrittura()
        {
            StreamWriter sw = new StreamWriter("file_thread.txt");
            Console.WriteLine("***THREAD: " + Thread.CurrentThread.Name + " AVVIATO");
            for (int i = 0; i < 20000000; i++)
            {
                sw.Write("*");
            }
            
            sw.Close();
            Console.WriteLine("***THREAD: " + Thread.CurrentThread.Name + " TERMINATO...");
        }
    }
}
