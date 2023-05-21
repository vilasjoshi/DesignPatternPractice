using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPattern.Singleton;

namespace DesignPatterns.Test.Singleton.Test
{
	[TestClass]
	public class SingletonThreadSafeTest
	{
		public SingletonThreadSafeTest()
		{
		}

        [TestMethod]
        public void ReturnsNonNullInstance()
        {
            var result = SingletonThreadSafe.Instance;
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(SingletonThreadSafe));

        }

        [TestMethod]
        public void SingleInstanceOnThreeInstanceCall()
        {
            var one = SingletonThreadSafe.Instance;
            var two = SingletonThreadSafe.Instance;
            var three = SingletonThreadSafe.Instance;

            Assert.AreEqual(one, two);
            Assert.AreEqual(two, three);
        }

        [TestMethod]
        public void CallingOnDifferentParallelThreads_NotEqualInstance()
        {
            var strings = new List<string>() { "one", "two", "three" };
            var instances = new List<SingletonThreadSafe>();
            var parallel = new ParallelOptions() { MaxDegreeOfParallelism = 3 };
            Parallel.ForEach(strings, parallel, instance =>
            {
                instances.Add(SingletonThreadSafe.Instance);
            });
            Assert.AreEqual(instances[0], instances[1]);
            Assert.AreEqual(instances[1], instances[2]);
            Assert.AreEqual(instances[0], instances[2]);
        }
    }
}

