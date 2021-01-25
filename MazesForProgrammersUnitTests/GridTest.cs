using MazesForProgrammers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazesForProgrammersUnitTests {
    [TestClass]
    public class GridTest {
        [TestMethod]
        public void TestGridInit() {
            Grid grd = new Grid(3, 4);

            Cell bottomLeftCell = grd.GetCell(2, 3);
            Assert.IsNull(bottomLeftCell.South);
            Assert.IsNull(bottomLeftCell.East);

            Cell topRightCell = grd.GetCell(0, 3);
            Assert.IsNull(topRightCell.North);
            Assert.IsNull(topRightCell.East);
        }

        [TestMethod]
        public void TestGetCell() {
            Grid grd = new Grid(3, 4);

            //out of bounds 
            Cell cell = grd.GetCell(3, 4);
            Assert.IsNull(cell);
        }
    }
}
