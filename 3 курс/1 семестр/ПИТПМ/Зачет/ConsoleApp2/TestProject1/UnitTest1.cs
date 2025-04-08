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
            var expected = adder.AddObject("name1", 10);
        }
    }
}