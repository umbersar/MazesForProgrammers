using System;
using System.Collections.Generic;
using System.Text;

namespace MazesForProgrammers {
    public class Grid {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Cell[,] Cells { get; private set; }
        public Grid(int rows, int columns) {
            this.Rows = rows;
            this.Columns = columns;
            this.Cells = new Cell[rows, columns];

            Initialize();
        }

        private void Initialize() {
            Prepare_Grid();
            Configure_Cells();
        }

        private void Prepare_Grid() {
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Columns; j++) {
                    Cells[i, j] = new Cell(i, j);
                }
            }
        }
        private void Configure_Cells() {
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Columns; j++) {
                    Cells[i, j].North = new Cell(i, j);
                    Cells[i, j].South = new Cell(i, j);
                    Cells[i, j].East = new Cell(i, j);
                    Cells[i, j].West = new Cell(i, j);
                }
            }
        }

        private Cell GetCell(int row, int col) {
            if (row < 0 || col < 0 || row + 1 > Rows || col + 1 > Columns)
                return null;
            else
                return this.Cells[row, col];
        }

    }
}
