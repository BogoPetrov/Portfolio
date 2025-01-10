namespace DeadLock_LiveLock_Starvation
{
    internal class Program
    {
        #region DeadLock
        private static readonly object lock1 = new();
        private static readonly object lock2 = new();

        static void Thread1()
        {
            lock (lock1)
            {
                Console.WriteLine("Thread 1: Locked lock1");
                Thread.Sleep(100); // Simulate some work
                lock (lock2)
                {
                    Console.WriteLine("Thread 1: Locked lock2");
                }
            }
        }

        static void Thread2()
        {
            lock (lock2)
            {
                Console.WriteLine("Thread 2: Locked lock2");
                Thread.Sleep(100); // Simulate some work
                lock (lock1)
                {
                    Console.WriteLine("Thread 2: Locked lock1");
                }
            }
        }
        #endregion

        #region LiveLock
        private static readonly object lock3 = new();
        private static readonly object lock4 = new();
        private static bool isThread3Helping = true;
        private static bool isThread4Helping = true;

        static void Thread3()
        {
            while (isThread3Helping)
            {
                if (Monitor.TryEnter(lock3))
                {
                    Console.WriteLine("Thread 3: Acquired lock3. Trying for lock4...");
                    Thread.Sleep(100); // Simulate work

                    if (Monitor.TryEnter(lock4))
                    {
                        Console.WriteLine("Thread 3: Acquired lock4.");
                        isThread3Helping = false;
                        Monitor.Exit(lock3);
                    }
                    else
                    {
                        Console.WriteLine("Thread 3: Failed to acquire lock4, releasing lock3...");
                        Monitor.Exit(lock3);
                    }
                }
            }
        }

        static void Thread4()
        {
            while (isThread4Helping)
            {
                if (!Monitor.TryEnter(lock4))
                {
                    Console.WriteLine("Thread 4: Acquired lock4. Trying for lock3...");
                    Thread.Sleep(100); // Simulate work

                    if (Monitor.TryEnter(lock3))
                    {
                        Console.WriteLine("Thread 4: Acquired lock3.");
                        isThread4Helping = false;
                        Monitor.Exit(lock3);
                    }
                    else
                    {
                        Console.WriteLine("Thread 4: Failed to acquire lock3, releasing lock4...");
                        Monitor.Exit(lock4);
                    }
                }
            }
        }
        #endregion

        #region Starvation 
        static void HighPriorityTask()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"High-priority task {i + 1} is running.");
                Thread.Sleep(10); // Simulate work
            }
        }

        static void LowPriorityTask()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Low-priority task {i + 1} is running.");
                Thread.Sleep(100); // Simulate work
            }
        }
        #endregion

        public static void Main()
        {
            //Fix DeadLock
            Thread t1 = new(Thread1);
            Thread t2 = new(Thread2);

            t1.Start();
            t1.Join();

            t2.Start();
            t2.Join();


            Console.WriteLine("This line will never be reached due to deadlock.");

            //Fix LiveLock
            Thread t3 = new(Thread3);
            Thread t4 = new(Thread4);

            t3.Start();
            t3.Join();

            t4.Start();
            t4.Join();


            Console.WriteLine("Program completed.");

            //Fix Starvation
            Thread highPriority = new(HighPriorityTask) { Priority = ThreadPriority.Highest };
            Thread lowPriority = new(LowPriorityTask) { Priority = ThreadPriority.Lowest };

            highPriority.Start();
            highPriority.Join();

            lowPriority.Start();
            lowPriority.Join();


            Console.WriteLine("Program completed.");

            Console.ReadKey(true);
        }
    }
}

namespace Bank_Example_DeadLock
{
    public class BankAccount(int id, decimal initialBalance)
    {
        public int Id { get; } = id;
        public decimal Balance { get; private set; } = initialBalance;
        private readonly object accountLock = new();

        public void Deposit(decimal amount)
        {
            lock (accountLock)
            {
                Balance += amount;
            }
        }

        public void Withdraw(decimal amount)
        {
            lock (accountLock)
            {
                Balance -= amount;
            }
        }

        public bool TransferTo(BankAccount targetAccount, decimal amount)
        {
            lock (accountLock)
            {
                Thread.Sleep(100); // Simulate processing delay
                lock (targetAccount.accountLock)
                {
                    if (Balance >= amount)
                    {
                        Withdraw(amount);
                        targetAccount.Deposit(amount);
                        return true;
                    }
                    return false;
                }
            }
        }
    }


    internal class Program
    {
        private static readonly BankAccount accountA = new(1, 5000);
        private static readonly BankAccount accountB = new(2, 3000);

        // Deadlock scenario
        static void DeadlockExample()
        {
            Thread t1 = new(() =>
            {
                accountA.TransferTo(accountB, 1000);
                Console.WriteLine("Thread 1: Transferred $1000 from Account A to B");
            });

            Thread t2 = new(() =>
            {
                accountB.TransferTo(accountA, 500);
                Console.WriteLine("Thread 2: Transferred $500 from Account B to A");
            });

            t1.Start();
            t1.Join();

            t2.Start();
            t2.Join();

        }

        // Livelock scenario
        static void LivelockExample()
        {
            Thread t1 = new(() =>
            {
                while (!accountA.TransferTo(accountB, 1000))
                {
                    Console.WriteLine("Thread 1: Retrying transfer from Account A to B");
                    Thread.Sleep(50); // Simulate retrying
                }
                Console.WriteLine("Thread 1: Successfully transferred $1000 from Account A to B");
            });

            Thread t2 = new(() =>
            {
                while (!accountB.TransferTo(accountA, 1000))
                {
                    Console.WriteLine("Thread 2: Retrying transfer from Account B to A");
                    Thread.Sleep(50); // Simulate retrying
                }
                Console.WriteLine("Thread 2: Successfully transferred $1000 from Account B to A");
            });

            t1.Start();
            t1.Join();

            t2.Start();
            t2.Join();

        }

        // Starvation scenario
        static void StarvationExample()
        {
            object bankLock = new();
            int completedTransactions = 0;

            Thread highPriorityThread = new(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    lock (bankLock)
                    {
                        Console.WriteLine($"High-priority transaction {i + 1} completed.");
                        Thread.Sleep(50); // Simulate work
                        if (completedTransactions == 5) break;
                    }
                }
            })
            { Priority = ThreadPriority.Highest };

            Thread lowPriorityThread = new(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    lock (bankLock)
                    {
                        Console.WriteLine($"Low-priority transaction {i + 1} completed.");
                        completedTransactions++;
                    }
                    Thread.Sleep(200); // Simulate work
                }
            })
            { Priority = ThreadPriority.Lowest };

            highPriorityThread.Start();
            highPriorityThread.Join();

            lowPriorityThread.Start();
            lowPriorityThread.Join();

        }


        static void Main()
        {
            Console.WriteLine("1. Deadlock Example");
            DeadlockExample();

            Console.WriteLine("\n2. Livelock Example");
            LivelockExample();

            Console.WriteLine("\n3. Starvation Example");
            StarvationExample();

            Console.ReadKey();
        }
    }
}
