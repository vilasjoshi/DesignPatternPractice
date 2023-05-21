using System;
namespace DesignPattern.Singleton
{
	public sealed class SingletonThreadSafe
	{
        private static SingletonThreadSafe _instance;
        private static readonly object padlock = new object();

        public SingletonThreadSafe()
        {
            Console.WriteLine("Constructor Invoked");
            //Logger.Log("Constructor Invoked...");
        }
      
        public static SingletonThreadSafe Instance
        {
            get
            {
                if (_instance == null) // approch II : this pulls the lock only first time creation and later it will not use lock
                {

                    lock (padlock)  // approch I : but this fetch lock on every request. to tackle it, we use double check -locking
                    {

                        Console.WriteLine("Instance Called ...");
                        if (_instance == null)
                        {
                            _instance = new SingletonThreadSafe();

                        }
                    }
                }
                return _instance;
            }
        }
    }
}

