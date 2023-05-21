using System;
namespace DesignPattern.Singleton
{
	public sealed class SingletonNaive
	{
		private static SingletonNaive _instance;

		private SingletonNaive()
		{
			Console.WriteLine("Constructor Invoked");
			//Logger.Log("Constructor Invoked...");
		}

		public static SingletonNaive Instance
		{
			get
			{
				Console.WriteLine("Instance Called ...");
				if(_instance == null)
				{
					_instance = new SingletonNaive();

				}
				return _instance;
			}
		}
	}
}

// this approach is naive and not thread safe, it can have issue when used with parallelism.
