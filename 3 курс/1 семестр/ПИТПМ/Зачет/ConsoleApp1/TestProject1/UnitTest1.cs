using ConsoleApp1;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int expectedId = 1;
            Adder adder = new Adder();
            Book actual = adder.AddObject("Герой нашего времени", "Михаил Юрьевич Лермонтов");

            Assert.AreEqual(expectedId, actual.Id);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string expectedTitle = "Герой нашего времени";
            Adder adder = new Adder();
            Book actual = adder.AddObject("Герой нашего времени", "Михаил Юрьевич Лермонтов");

            Assert.AreEqual(expectedTitle, actual.Title);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string expectedAuthor = "Михаил Юрьевич Лермонтов";
            Adder adder = new Adder();
            Book actual = adder.AddObject("Бородино", "Михаил Юрьевич Лермонтов");

            Assert.AreEqual(expectedAuthor, actual.Author);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int expectedId = 10;
            Adder adder = new Adder();
            Book actual = adder.AddObject("Война и Мир", "Лев Николаевич Толстой");

            Assert.AreEqual(expectedId, actual.Id);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string expectedAuthor = "А.С.Пушкин";
            Adder adder = new Adder();
            Book actual = adder.AddObject("Капитанская Дочка", "Александр Сергеевич Пушкин");

            Assert.AreEqual(expectedAuthor, actual.Author);
        }
    }
}