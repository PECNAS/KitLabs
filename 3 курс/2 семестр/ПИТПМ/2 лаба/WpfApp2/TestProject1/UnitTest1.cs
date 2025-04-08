using WpfApp2;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShellTest()
        {
            var unsorted_array = NumGenerator.Generate(20);
            unsorted_array.Sort();
            var expected = unsorted_array;

            ShellSort sorter = new ShellSort();
            List<int> actual = sorter.sort(unsorted_array);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SwapTest()
        {
            var unsorted_array = NumGenerator.Generate(20);
            unsorted_array.Sort();
            var expected = unsorted_array;

            SwapSort sorter = new SwapSort();
            var actual = sorter.sort(unsorted_array);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ViborTest()
        {
            var unsorted_array = NumGenerator.Generate(20);
            unsorted_array.Sort();
            var expected = NumGenerator.Generate(20);

            ViborSort sorter = new ViborSort();
            var actual = sorter.sort(unsorted_array);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}