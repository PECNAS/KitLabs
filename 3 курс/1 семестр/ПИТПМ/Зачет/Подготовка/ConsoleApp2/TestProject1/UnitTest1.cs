using ConsoleApp2;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int actual = 1;
            Adder adder = new Adder();
            var expected = adder.AddObject("яблоко", 30);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestMethod2()
        {
            int actual = 2;
            Adder adder = new Adder();
            var expected = adder.AddObject("яблоко", 30);
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int actual = 555;
            Adder adder = new Adder();
            var expected = adder.AddObject("яблоко", 30);
            Assert.AreEqual(actual, expected);
        }
    }
}

