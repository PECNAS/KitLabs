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
            Book actual = adder.AddObject("����� ������ �������", "������ ������� ���������");

            Assert.AreEqual(expectedId, actual.Id);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string expectedTitle = "����� ������ �������";
            Adder adder = new Adder();
            Book actual = adder.AddObject("����� ������ �������", "������ ������� ���������");

            Assert.AreEqual(expectedTitle, actual.Title);
        }

        [TestMethod]
        public void TestMethod3()
        {
            string expectedAuthor = "������ ������� ���������";
            Adder adder = new Adder();
            Book actual = adder.AddObject("��������", "������ ������� ���������");

            Assert.AreEqual(expectedAuthor, actual.Author);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int expectedId = 10;
            Adder adder = new Adder();
            Book actual = adder.AddObject("����� � ���", "��� ���������� �������");

            Assert.AreEqual(expectedId, actual.Id);
        }

        [TestMethod]
        public void TestMethod5()
        {
            string expectedAuthor = "�.�.������";
            Adder adder = new Adder();
            Book actual = adder.AddObject("����������� �����", "��������� ��������� ������");

            Assert.AreEqual(expectedAuthor, actual.Author);
        }
    }
}