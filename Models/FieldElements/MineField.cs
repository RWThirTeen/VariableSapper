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


        //Cell[,] _cells;
        //public Cell[,] Cells
        //{
        //    get => _cells;
        //    set => _cells = value;
        //}

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


        #region Логика нажатия на ячйеки

        public ICommand OpenCellCommand { get; }
        void OnOpenCellCommandExecuted(object p)
        {
            Text = Convert.ToString(p);
        }
        bool CanOpenCellCommandExecute(object p) => true;

        public ICommand SetFlagCommand { get; }
        void OnSetFlagCommandExecuted(object p)
        {
            
        }
        bool CanSetFlagCommandExecute(object p) => true;

        #endregion



        #region Временное поле
        /// <summary>
        /// 
        /// </summary>
        string _text;
        public string Text { get; set; }


        #endregion



        public MineField(int rows, int columns)
        {
            NumberOfRows = rows;
            NumberOfColumns = columns;

            Rows = new ObservableCollection<Row>();

            for (int i = 0; i < NumberOfRows; i++)
            {
                Rows.Add(new Row(i, NumberOfColumns));
            }

            //Cells = new Cell[Rows, Columns];

            //for (int row = 0; row < Rows; row++)
            //{
            //    for (int column = 0; column < Columns; column++)
            //    {
            //        Cells[row, column] = new Cell(row, column);
            //    }
            //}


            OpenCellCommand = new LambdaCommand(OnOpenCellCommandExecuted, CanOpenCellCommandExecute);
            SetFlagCommand = new LambdaCommand(OnSetFlagCommandExecuted, CanSetFlagCommandExecute);
        }
    }
}
