using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using VariableSapper.Interfacees.FieldConstructor;
using VariableSapper.Models.FieldElements;

namespace VariableSapper.Models.FieldConstructorElements
{
    internal class MinePlacer : IMinePlacer
    {
        public void PlaceMines(MineField field)
        {
            if (field == null) return; //сделать сообщение об ошибке

            int countMinesToSet = field.MinesCount;

            Random rnd = new Random();

            while (countMinesToSet > 0)
            {
                if(SetMineInCell()) countMinesToSet--;
            }

            







            bool SetMineInCell()
            {
                int row = rnd.Next(0, field.NumberOfRows);
                int column = rnd.Next(field.NumberOfColumns);

                if (field.Cells[row * field.NumberOfColumns + column].IsMine) return false;

                field.Cells[row * field.NumberOfColumns + column].SetAsMine();

                //if (field.Rows[row].Cells[column].IsMine) return false;

                //field.Rows[row].Cells[column].SetAsMine();

                return true;

                //int row = rnd.Next(1, field.Rows);
                //int column = rnd.Next(1, field.Columns);

                //if (field.Cells[row, column].IsMine) return;

                //field.Cells[row, column].SetAsMine();
            }
        }
    }
}
