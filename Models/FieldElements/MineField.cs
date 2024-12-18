using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableSapper.Models.FieldElements
{
    internal class MineField
    {
        int _rows;
        int _columns;

        public Cell[,] Cells;



        public MineField(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
        }
    }
}
