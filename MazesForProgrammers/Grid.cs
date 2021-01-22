using System;
using System.Collections.Generic;
using System.Text;

namespace MazesForProgrammers {
    public class Grid {
        public int Rows { get; private set; }
        public int Columns { get; private set; }
        public List<List<Cell>> Cells { get; private set; }
        public Grid(int rows, int columns) {
            this.Rows = rows;
            this.Columns = columns;
            this.Cells = new List<List<Cell>>(rows * columns);

            Initialize();
        }

        private void Initialize() {
            Prepare_Grid();
            Configure_Cells();
        }

        private void Prepare_Grid() {
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Columns; j++) {
                    Cells[i][j] = new Cell(i, j);
                }
            }
        }

        /*   c0     c3 
         row0 * * * *
         row1 * * * *
         row2 * * * * 
        */
        private void Configure_Cells() {
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Columns; j++) {
                    Cells[i][j].North = GetCell(i - 1, j);
                    Cells[i][j].South = GetCell(i + 1, j);
                    Cells[i][j].East = GetCell(i, j + 1);
                    Cells[i][j].West = GetCell(i, j - 1);
                }
            }
        }

        private Cell GetCell(int row, int col) {
            if (row < 0 || col < 0 || row + 1 > Rows || col + 1 > Columns)
                return null;
            else
                return this.Cells[row][col];
        }

        public Cell this[int row, int col] {
            get { return GetCell(row, col); }
        }

        public int Size() {
            return Rows * Columns;
        }

        public Cell GetRandomCell() {
            Random rnd = new Random();
            int randRow = rnd.Next(0, Rows);
            int randCol = rnd.Next(0, Columns);

            return GetCell(randRow, randCol);
        }

        public IEnumerable<List<Cell>> EachRow() {
            foreach (List<Cell> row in Cells) {
                yield return row;
            }
        }

        public IEnumerable<Cell> EachCell() {
            foreach (List<Cell> row in Cells) {
                foreach (Cell col in row) {
                    yield return col;
                }
            }
        }
    }
}
