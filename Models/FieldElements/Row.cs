using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableSapper.Models.FieldElements
{
    internal class Row
    {
        public int RowNumber { get; private set; }

        public ObservableCollection<Cell> Cells { get; private set; }

        public Row(int rowNumber, int columnCount, MineField field)
        {
            RowNumber = rowNumber;
            Cells = new ObservableCollection<Cell>();

            for (int i = 0; i < columnCount - 1; i++)
            {
                Cells.Add(new Cell(RowNumber, i, field));
            }
        }
    }
}
