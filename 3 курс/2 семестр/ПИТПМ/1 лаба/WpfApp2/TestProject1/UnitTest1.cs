using WpfApp2;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private List<int> unsorted_array = new List<int> { 1, 2 };
        private List<int> expected = new List<int> { 1, 2 };

        [TestMethod]
        public void ShellTest()
        {
            ShellSort sorter = new ShellSort();
            List<int> actual = sorter.sort(unsorted_array);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SwapTest()
        {
            SwapSort sorter = new SwapSort();
            var actual = sorter.sort(unsorted_array);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ViborTest()
        {
            ViborSort sorter = new ViborSort();
            var actual = sorter.sort(unsorted_array);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}