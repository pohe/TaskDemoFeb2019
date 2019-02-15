using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemoFeb2019
{
    class Program
    {
        static void Main(string[] args)
        {

            //Task taskA = new Task(DoUnitOfWorkA);

            Task taskA = Task.Run(() => DoUnitOfWorkA());
            Task taskB = new Task(DoUnitOfWorkB);
            Object data = new List<int>() { 12, 4, 5, 34, 77 };
            
            Task taskC = new Task(DoUnitOfWorkC, data);

            Task taskCalculate = new Task(Calculate);
            taskCalculate.Start();


            //taskA.Start();
            taskB.Start();
            //taskCalculate.Wait();
            //taskA.Wait();
            taskC.Start();
            Task.WaitAll(taskA, taskB, taskC);
            Task taskAD = taskA.ContinueWith(DoUnitOfWorkD);
            //taskAD.Start();
            Parallel.For(0, 100, Calculate);

            Console.WriteLine("Done");
            Console.ReadLine();
        }

        private static void Calculate(int obj)
        {
            Console.WriteLine(obj);
        }

        private static void Calculate()
        {
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            System.Console.WriteLine("Hi I am in Calculate");
        }

        private static void DoUnitOfWorkD(Task obj)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Do work D");
            }
        }

        private static void DoUnitOfWorkC(Object data)
        {
            foreach (int tal in (List<int>)data)
            {
                Console.WriteLine($"DoUnitWorkOFC {tal}");
            }
        }

        private static void DoUnitOfWorkB()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Do work B");
            }
            
        }

        private static void DoUnitOfWorkA()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Do work A");
            }
            
        }
    }
}
