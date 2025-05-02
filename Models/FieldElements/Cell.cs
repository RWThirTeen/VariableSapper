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
        public void SetAsMine() => IsMine = true;

        public int MinesCountAround { get; private set; }
        public void IncreaseMinesCountAround()
        {
            if (IsMine) return;
            MinesCountAround++;
        }

        public bool IsOpen { get; private set; }
        public void SetAsOpen() => IsOpen = true;

        public bool IsFlaged { get; private set; }
        public void ChangeFlagedStatus() => IsFlaged = !IsFlaged;


        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
            IsMine = false;
        }
    }
}
