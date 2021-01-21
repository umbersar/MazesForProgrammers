using System;
using System.Collections.Generic;
using System.Text;

namespace MazesForProgrammers {
    public class Cell {
        public int Row { get; private set; }//x co-ordinate of the cell
        public int Column { get; private set; }//y co-ordinate of the cell
        public List<Cell> Links { get; private set; }
        public Cell North { get; set; }
        public Cell South { get; set; }
        public Cell East { get; set; }
        public Cell West { get; set; }

        public Cell(int row, int column) {
            this.Row = row;
            this.Column = column;
            this.Links = new List<Cell>();
        }

        public void Link(Cell cell, bool biDir = true) {
            this.Links.Add(cell);

            if (biDir)
                cell.Link(this, false);
        }

        public void UnLink(Cell cell, bool biDir = true) {
            this.Links.Remove(cell);

            if (biDir)
                cell.UnLink(this, false);
        }

        public bool IsLinked(Cell cell) {
            return this.Links.Contains(cell);
        }

        public List<Cell> Neighbours() {
            List<Cell> neighbours = new List<Cell>() { North, South, East, West };
            return neighbours.FindAll(nr => nr != null);
        }
    }
}
