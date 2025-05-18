using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VariableSapper.Models.Enums;

namespace VariableSapper.Models.FieldElements
{
    internal class Cell : INotifyPropertyChanged
    {
        readonly MineField _field;

        public int Row { get; private set; }
        public int Column { get; private set; }

        public bool IsMine { get; private set; }
        public void SetAsMine()
        {
            IsMine = true;
        }
            

        public int MinesCountAround { get; private set; }
        public void IncreaseMinesCountAround()
        {
            if (IsMine) return;
            MinesCountAround++;
        }

        public bool IsOpen { get; private set; }
        public void SetAsOpen()
        {
            if (IsFlaged) return;

            if (IsMine) IconName = "Mine";
            else
            {
                if (MinesCountAround == 0) IconName = "StarFourPointsSmall";
                else IconName = $"Numeric{MinesCountAround}";
            }
                
            IsOpen = true;
        }


        bool _isFlaged;
        public bool IsFlaged
        {
            get => _isFlaged;
            private set
            {
                if (IsFlaged)
                {
                    IconName = "SquareOutline";
                    _isFlaged = value;
                }
                else
                {
                    IconName = "Flag";
                    _isFlaged = value;
                }
                
            }
        }
        public void ChangeFlagedStatus() => IsFlaged = !IsFlaged;

        string _iconName = "SquareOutline";



        public string IconName
        {
            get => _iconName;
            private set
            {
                if (_iconName == value) return;
                _iconName = value;
                OnPropertyChanged(nameof(IconName));
            }
                
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }



        public Cell(int row, int column, MineField field)
        {
            Row = row;
            Column = column;
            _field = field;
            IsMine = false;
            IsOpen = false;
        }

    }
}
