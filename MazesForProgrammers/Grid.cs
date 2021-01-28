using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using static MazesForProgrammers.Utilities;

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
                var row = new List<Cell>();
                for (int j = 0; j < Columns; j++) {
                    row.Add(new Cell(i, j));
                }

                this.Cells.Add(row);
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

        public Cell GetCell(int row, int col) {
            if (row < 0 || col < 0 || row + 1 > Rows || col + 1 > Columns)
                return null;
            else
                return this.Cells[row][col];
        }

        public Cell this[int row, int col] {//index operator
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
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append("+");

            for (int i = 0; i < Columns; i++) {
                sb.Append("---+");//this is the top row/northernmost boundary
            }

            sb.AppendLine();

            foreach (List<Cell> row in EachRow()) {
                var easternSection = new StringBuilder("|");
                var bottom = new StringBuilder("+");//southern_section

                foreach (Cell cell in row) {
                    string bodyOfCell = "   ";//hard code 3 horizontal spaces for cell contents
                    var east_boundary = cell.IsLinked(cell.East) ? " " : "|";
                    easternSection.Append(bodyOfCell).Append(east_boundary);

                    var cell_corner = "+";
                    var south_boundary = cell.IsLinked(cell.South) ? "   " : "---";
                    bottom.Append(south_boundary).Append(cell_corner);
                }
                sb.AppendLine(easternSection.ToString());
                sb.AppendLine(bottom.ToString());
            }

            return sb.ToString();
        }

        public Bitmap ToPng(int cellSize = 10) {
            int image_width = cellSize * Columns;
            int image_height = cellSize * Rows;

            var bitmap = new Bitmap(image_width + 1, image_height + 1);

            using (var graphic = Graphics.FromImage(bitmap)) {
                graphic.Clear(Color.White);//background color (white) 

                // Paint the walls
                foreach (Cell cell in EachCell()) {
                    var x1 = cell.Column * cellSize;
                    var y1 = cell.Row * cellSize;//northwest (x1,y1) corner

                    var x2 = (cell.Column + 1) * cellSize;
                    var y2 = (cell.Row + 1) * cellSize;//southeast (x2,y2) corner

                    var pen = Pens.Black;//wall color (black)

                    if (!cell.IsLinked(cell.North)) {//check if the cell has any neighbors to the north, and if not, we draw that wall
                        graphic.DrawLine(pen, new Point { X = x1, Y = y1 }, new Point { X = x2, Y = y1 });
                    }
                    if (!cell.IsLinked(cell.West)) {//check if the cell has any neighbors to the west, and if not, we draw that wall
                        graphic.DrawLine(pen, new Point { X = x1, Y = y1 }, new Point { X = x1, Y = y2 });
                    }
                    if (!cell.IsLinked(cell.East)) {
                        graphic.DrawLine(pen, new Point { X = x2, Y = y1 }, new Point { X = x2, Y = y2 });
                    }
                    if (!cell.IsLinked(cell.South)) {
                        graphic.DrawLine(pen, new Point { X = x1, Y = y2 }, new Point { X = x2, Y = y2 });
                    }

                }
                graphic.Save();
            }

            return bitmap;
        }
    }
}
