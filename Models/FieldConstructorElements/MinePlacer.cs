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
            if (field != null) return; //сделать сообщение об ошибке

            int countMinesToSet = field.MinesCount;

            Random rnd = new Random();

            while (countMinesToSet > 0)
            {
                SetMineInCell();
            }

            







            void SetMineInCell()
            {
                int row = rnd.Next(1, field.Rows);
                int column = rnd.Next(1, field.Columns);

                if (field.Cells[row, column].IsMine == true) return;

                field.Cells[row, column].SetAsMine();
            }
        }
    }
}
