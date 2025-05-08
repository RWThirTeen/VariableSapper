using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using VariableSapper.Infrastructure.Commands;

namespace VariableSapper.Models.FieldElements
{
    internal class MineField
    {
        public int NumberOfRows {  get; private set; }
        public int NumberOfColumns { get; private set; }


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



        public ObservableCollection<Row> Rows { get; private set; }

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





        public MineField(int rows, int columns, int minesCount)
        {
            NumberOfRows = rows;
            NumberOfColumns = columns;
            StartMinesCount = minesCount;
            MinesCount = minesCount;

            Rows = new ObservableCollection<Row>();

            for (int i = 0; i < NumberOfRows; i++)
            {
                Rows.Add(new Row(i, NumberOfColumns, this));
            }
        }
    }
}
