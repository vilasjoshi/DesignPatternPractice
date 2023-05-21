using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPattern.Singleton;
namespace DesignPatterns.Test.Singleton.Test
{
	[TestClass]
	public class SingletonNaiveTest
	{
		public SingletonNaiveTest()
		{
		}

		[TestMethod]
		public void ReturnsNonNullInstance()
		{
            var result = SingletonNaive.Instance;
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(SingletonNaive));

		}

		[TestMethod]
		public void SingleInstanceOnThreeInstanceCall()
		{
			var one = SingletonNaive.Instance;
			var two = SingletonNaive.Instance;
			var three = SingletonNaive.Instance;

			Assert.AreEqual(one, two);
			Assert.AreEqual(two, three);
		}

		[TestMethod]
		public void CallingOnDifferentParallelThreads_NotEqualInstance()
		{
			var strings = new List<string>() { "one", "two", "three" };
			var instances = new List<SingletonNaive>();
			var parallel = new ParallelOptions() { MaxDegreeOfParallelism = 3 };
			Parallel.ForEach(strings, parallel, instance =>
			{
				instances.Add(SingletonNaive.Instance);
			});
			Assert.AreNotEqual(instances[0], instances[1]);
			Assert.AreNotEqual(instances[1], instances[2]);
			Assert.AreNotEqual(instances[0], instances[2]);
        }
	}
}

