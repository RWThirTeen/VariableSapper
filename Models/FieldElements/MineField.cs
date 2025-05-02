using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VariableSapper.Models.FieldElements
{
    internal class MineField
    {
        public int Rows {  get; private set; }
        public int Columns { get; private set; }

        int _minesCount;
        public int MinesCount
        {
            get
            {
                if (_minesCount <= 0) return 0;
                else return _minesCount;
            }
            private set => _minesCount = value;
        }

        public Cell[,] Cells;


        #region Логика работы со счетчиком мин

        public void SetMinesCount(int minesCount)
        {
            MinesCount = minesCount;
        }

        public void ChangeMinesCount(bool isIncrease)
        {
            if (isIncrease) MinesCount++;
            else MinesCount--;
        }

        #endregion





        public MineField(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Cells = new Cell[Rows, Columns];
        }
    }
}
