using System;
using System.Collections.Generic;
using System.Text;

namespace MazesForProgrammers {
    public class Distances {
        private Cell Root { get; }
        private Dictionary<Cell, int> cellDistances;

        public IEnumerable<Cell> Cells {
            get { return cellDistances.Keys; }
        }

        public int this[Cell cell] {
            get {
                if (cellDistances.ContainsKey(cell)) {
                    return cellDistances[cell];
                }
                return -1;
            }
            set {
                cellDistances[cell] = value;
            }
        }

        public Distances(Cell root) {
            Root = root;
            cellDistances = new Dictionary<Cell, int>() { { root, 0 } };
        }
    }
}
