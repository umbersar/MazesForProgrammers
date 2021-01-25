using System;
using System.Collections.Generic;
using System.Text;

namespace MazesForProgrammers {
    public class SideWinder {
        public static Grid On(Grid grid) {

            foreach (var row in grid.EachRow()) {
                List<Cell> run = new List<Cell>();

                foreach (var cell in grid.EachCell()) {
                    run.Add(cell);

                    bool at_eastern_boundary = (cell.East == null);
                    bool at_northern_boundary = (cell.North == null);

                    //we always close the run at the end of a row(at the eastern boundary), but we also 
                    //do it randomly within a row(i.e.rand(2) == 0), as long as we’re not in the 
                    //northernmost row(to avoid carving through the outer wall of the maze).
                    bool should_close_out = at_eastern_boundary || (!at_northern_boundary
                                                                        && (new Random().Next(2) == 0));

                    if (should_close_out) {
                        var member = run.Sample();//pick a random cell from the run to close it
                        if (member.North != null) 
                            member.Link(member.North);
                        
                        run.Clear();
                    } else {
                        cell.Link(cell.East);
                    }
                }
            }

            return grid;
        }
    }
}
