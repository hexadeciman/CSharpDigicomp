internal class TP04Prog
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        /*
         //Normal call:
         LongFn("main");
         */

        /*
         // Threads:
        Thread th1 = new Thread(() => { LongFn("Th1"); });
        Thread th2 = new Thread(() => { LongFn("Th2"); });
        th1.Start();
        th2.Start();

        th1.Join();
        Console.WriteLine("Done th1");
        th2.Join();
        */

        
        //Tasks
        Action<object> action = (c) =>
        {
            LongFn(c as string);
        };
        /*
        Task t1 = new Task(action, "t1");
        Task t2 = new Task(action, "t2");
        t1.Start();
        t2.Start();

        t2.Wait();
        t1.Wait();*/

        //Parallel
        /*try
        {
            Parallel.Invoke(
                delegate() { LongFn("t1"); },
                delegate () { LongFn("t2"); },
                delegate () { LongFn("t3"); },
                delegate () { LongFn("t4"); }
            );
        }
        // No exception is expected in this example, but if one is still thrown from a task,
        // it will be wrapped in AggregateException and propagated to the main thread.
        catch (AggregateException e)
        {
            Console.WriteLine("An action has thrown an exception. THIS WAS UNEXPECTED.\n{0}", e.InnerException.ToString());
        }*/

        await LongFnAsync("t1", 1000);

    }

    static void LongFn(string caller, int delay = 500)
    {
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine($"caller {caller}");
            Thread.Sleep(delay);
        }
    }

    static async Task LongFnAsync(string caller, int delay = 500)
    {
        var tasks = new List<Task>();
        tasks.Add(Task.Run(() => LongFn(caller, delay)));
        tasks.Add(Task.Run(() => LongFn(caller, delay)));
        tasks.Add(Task.Run(() => LongFn(caller, delay)));
        await Task.WhenAll(tasks);
    }
}