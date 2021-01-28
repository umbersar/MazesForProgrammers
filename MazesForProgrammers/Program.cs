using System;

namespace MazesForProgrammers {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Welcome to Mazes for Programmers!");
            Grid grdBinaryTree = new Grid(5, 5);
            BinaryTree.On(grdBinaryTree);
            Console.WriteLine(grdBinaryTree);
            System.Drawing.Bitmap btmBinTree = grdBinaryTree.ToPng();
            btmBinTree.Save("BinaryTree.png");

            Grid grdSideWinder = new Grid(5, 5);
            SideWinder.On(grdSideWinder);
            Console.WriteLine(grdSideWinder);
            System.Drawing.Bitmap bmpSideWinder = grdSideWinder.ToPng();
            bmpSideWinder.Save("SideWinder.png");
        }
    }
}
