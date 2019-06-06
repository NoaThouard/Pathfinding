using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AstarAlgorithm
{
    class GridSquare
    {
        public ConsoleColor colour;
        public string type;
        public GridSquare(ConsoleColor _colour, string _type)
        {
            colour = _colour;
            type = _type;
        }
    }
}
