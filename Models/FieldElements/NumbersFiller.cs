using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariableSapper.Interfacees.FieldConstructor;
using VariableSapper.Models.FieldElements;

namespace VariableSapper.Models.FieldConstructorElements
{
    internal class NumbersFiller : INumbersFiller
    {
        public void FillNumbersOnField(MineField field)
        {
            for (int i = 0; i<field.Rows; i++)
            {
                for (int j = 0; j < field.Columns; j++)
                {
                    int count = 0;

                    if (i - 1 > 0 && j - 1 > 0 && field.Cells[i - 1, j - 1].IsMine) count++;
                    if (i - 1 > 0 && j > 0 && field.Cells[i - 1, j].IsMine) count++;
                    if (i - 1 > 0 && j + 1 > 0 && field.Cells[i - 1, j + 1].IsMine) count++;
                    if (i > 0 && j - 1 > 0 && field.Cells[i, j - 1].IsMine) count++;
                    if (i > 0 && j + 1 > 0 && field.Cells[i, j + 1].IsMine) count++;
                    if (i + 1 > 0 && j - 1 > 0 && field.Cells[i + 1, j - 1].IsMine) count++;
                    if (i + 1 > 0 && j > 0 && field.Cells[i + 1, j].IsMine) count++;
                    if (i + 1 > 0 && j + 1 > 0 && field.Cells[i + 1, j + 1].IsMine) count++;

                    field.Cells[i, j].SetMinesCountAround(count);
                }
            }
        }
    }
}
