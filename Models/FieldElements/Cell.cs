using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableSapper.Models.FieldElements
{
    internal class Cell
    {
        public int Row { get; private set; }
        public int Column { get; private set; }





        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
