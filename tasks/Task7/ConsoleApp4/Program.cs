using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;


namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => DoSomething(1, 2000)).ContinueWith((prev) => DoSomething(4, 1000));           
            Task.Run(() => DoSomething(2, 5000)); 
            Task.Run(() => DoSomething(3, 1500));
            DoMore();
            Console.ReadLine();
        }
 
        static void DoSomething(int taskid, int sleeptime)
        {
            Console.WriteLine("Start of task #{0}", taskid);
            Thread.Sleep(sleeptime);
            Console.WriteLine("End of task #{0}", taskid);
        }

        public static async void DoMore()
        {
            await Task.Run(() => DoSomething(5, 3000));
            var task6 = Task.Run(() => DoSomething(6, 1500));
            task6.Wait();
            Console.WriteLine("All Tasks finished");
        }
    }  
}
