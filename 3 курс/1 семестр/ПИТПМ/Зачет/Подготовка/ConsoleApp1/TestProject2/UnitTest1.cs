using ConsoleApp1;
using ConsoleApp1.Base.Entities;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace TestProject2
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
            Assert.AreEqual(expected, actual);
        }
    }
}