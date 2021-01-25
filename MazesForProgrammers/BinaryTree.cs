using System;
using System.Collections.Generic;
using System.Text;

namespace MazesForProgrammers {
    public class BinaryTree {
        public static Grid On(Grid grid) {
            foreach (Cell cell in grid.EachCell()) {
                //in binary tree, we either move to north or to east. So collect those cells
                List<Cell> neighbours = cell.Neighbours();

                //a cell in northeast corner does not have any neighbour, so we just continue
                //the cell in southeast corner would only have 1 neighbour. So pick that 
                if (neighbours.Count > 0) {
                    Random rnd = new Random();
                    int index = rnd.Next(neighbours.Count);

                    cell.Link(neighbours[index]);//Link is akin to removing the boundary wall between those 2 cells
                }
            }

            return grid;
        }
    }
}
