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


         int _startMinesCount;
        public int StartMinesCount
        {
            get => _startMinesCount;
            private set => _startMinesCount = value;
        }

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
            StartMinesCount = minesCount;
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

            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    Cells[row, column] = new Cell(row, column);
                }
            }
        }
    }
}
