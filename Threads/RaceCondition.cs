public class RaceCondition
{
    public static void Example1_WithouLock()
    {
        int n = 0;
        Thread t1 = new(() =>
        {
            for (int i = 0; i < 100000; i++)
            {
                n++;
            }
        });
        Thread t2 = new(() =>
        {
            for (int i = 0; i < 100000; i++)
            {
                n--;
            }
        });
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        System.Console.WriteLine($"Example 1 without lock: {n}");
    }

    public static void Example2_WitLock()
    {
        int n = 0;        
        object _lock = new();
        Thread t1 = new(() =>
        {
            for (int i = 0; i < 100000; i++)
            {
                lock (_lock)
                {
                    n++;
                }                
            }
        });
        Thread t2 = new(() =>
        {
            for (int i = 0; i < 100000; i++)
            {
                lock(_lock)
                {
                    n--;
                }                
            }
        });
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        System.Console.WriteLine($"Example 2 using lock: {n}");
    }
}