using MazesForProgrammers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazesForProgrammersUnitTests {
    [TestClass]
    public class GridTest {
        [TestMethod]
        public void TestGridInit() {
            Grid grd = new Grid(3, 4);
            Cell cell = grd.GetCell(2, 3);
        }
    }
}
