using System;
using System.Collections.Generic;
using System.Text;

namespace MazesForProgrammers {
    public static class Utilities {
        public static T Sample<T>(this List<T> list, Random rnd = null) {
            if (rnd == null) rnd = new Random();

            return list[rnd.Next(list.Count)];
        }
    }
}
