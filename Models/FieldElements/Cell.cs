using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariableSapper.Models.Enums;

namespace VariableSapper.Models.FieldElements
{
    internal class Cell
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public bool IsMine { get; private set; }

        public int MinesCountAround { get; private set; }


        public void SetAsMine() => IsMine = true;
        public void IncreaseMinesCountAround()
        {
            if (IsMine) return;
            MinesCountAround++;
        }
        

        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
