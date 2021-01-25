using MazesForProgrammers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazesForProgrammersUnitTests {
    [TestClass]
    public class BinaryTreeTest {
        [TestMethod]
        public void TestBinaryTree() {
            Grid grd = new Grid(3, 4);
            BinaryTree.On(grd);
            string output = grd.ToString();
            Console.WriteLine(output);
        }
    }
}
