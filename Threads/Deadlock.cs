public class Deadlock
{
    public static void Example1()
    {
        object lock1 = new object();
        object lock2 = new object();

        Thread t1 = new Thread(() =>
        {
            lock (lock1)
            {
                Thread.Sleep(100); // Simula trabalho
                lock (lock2) { Console.WriteLine("T1"); }
            }
        });

        Thread t2 = new Thread(() =>
        {
            lock (lock2)
            {
                Thread.Sleep(100);
                lock (lock1) { Console.WriteLine("T2"); }
            }
        });

        t1.Start(); t2.Start();
    }

    /// <summary>
    /// Using global order for locks. 
    // lock1 and lock2 are always locked in the same order.
    /// </summary>
    public static void Example2()
    {
        object lock1 = new object();
        object lock2 = new object();

        Thread t1 = new Thread(() =>
        {
            lock (lock1)
            {
                Thread.Sleep(100); // Simula trabalho
                lock (lock2) { Console.WriteLine("T1"); }
            }
        });

        Thread t2 = new Thread(() =>
        {
            lock (lock1)
            {
                Thread.Sleep(100);
                lock (lock2) { Console.WriteLine("T2"); }
            }
        });

        t1.Start(); t2.Start();
    }

}