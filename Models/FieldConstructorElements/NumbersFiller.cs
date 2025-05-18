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
            //for (int i = 0; i<field.Rows; i++)
            //{
            //    for (int j = 0; j < field.Columns; j++)
            //    {
            //        if (field.Cells[i, j].IsMine)
            //        {
            //            //верхние ячейки
            //            if (i == 0)
            //            {
            //                if (j == 0)
            //                {
            //                    field.Cells[i, j + 1].IncreaseMinesCountAround();
            //                    field.Cells[i + 1, j].IncreaseMinesCountAround();
            //                    field.Cells[i + 1, j + 1].IncreaseMinesCountAround();
            //                }
            //                if (j > 0 && j < field.Columns - 1)
            //                {
            //                    field.Cells[i, j - 1].IncreaseMinesCountAround();
            //                    field.Cells[i, j + 1].IncreaseMinesCountAround();
            //                    field.Cells[i + 1, j - 1].IncreaseMinesCountAround();
            //                    field.Cells[i + 1, j].IncreaseMinesCountAround();
            //                    field.Cells[i + 1, j + 1].IncreaseMinesCountAround();
            //                }
            //                if (j == field.Columns - 1)
            //                {
            //                    field.Cells[i, j - 1].IncreaseMinesCountAround();
            //                    field.Cells[i + 1, j - 1].IncreaseMinesCountAround();
            //                    field.Cells[i + 1, j].IncreaseMinesCountAround();
            //                }
            //            }

            //            //боковые слева и справа
            //            else if (i > 0 && i < field.Rows - 1)
            //            {
            //                if (j == 0)
            //                {
            //                    field.Cells[i - 1, j].IncreaseMinesCountAround();
            //                    field.Cells[i - 1, j + 1].IncreaseMinesCountAround();
            //                    field.Cells[i, j + 1].IncreaseMinesCountAround();
            //                    field.Cells[i + 1, j].IncreaseMinesCountAround();
            //                    field.Cells[i + 1, j + 1].IncreaseMinesCountAround();
            //                }
            //                if (j == field.Columns - 1)
            //                {
            //                    field.Cells[i - 1, j - 1].IncreaseMinesCountAround();
            //                    field.Cells[i - 1, j].IncreaseMinesCountAround();
            //                    field.Cells[i, j - 1].IncreaseMinesCountAround();
            //                    field.Cells[i + 1, j - 1].IncreaseMinesCountAround();
            //                    field.Cells[i + 1, j].IncreaseMinesCountAround();
            //                }
            //            }

            //            //нижние ячейки
            //            else if (i == field.Rows - 1)
            //            {
            //                if (j == 0)
            //                {
            //                    field.Cells[i - 1, j].IncreaseMinesCountAround();
            //                    field.Cells[i - 1, j + 1].IncreaseMinesCountAround();
            //                    field.Cells[i, j + 1].IncreaseMinesCountAround();
            //                }
            //                if (j > 0 && j < field.Columns - 1)
            //                {
            //                    field.Cells[i - 1, j - 1].IncreaseMinesCountAround();
            //                    field.Cells[i - 1, j].IncreaseMinesCountAround();
            //                    field.Cells[i - 1, j + 1].IncreaseMinesCountAround();
            //                    field.Cells[i, j - 1].IncreaseMinesCountAround();
            //                    field.Cells[i, j + 1].IncreaseMinesCountAround();
            //                }
            //                if (j == field.Columns - 1)
            //                {
            //                    field.Cells[i - 1, j - 1].IncreaseMinesCountAround();
            //                    field.Cells[i - 1, j].IncreaseMinesCountAround();
            //                    field.Cells[i, j - 1].IncreaseMinesCountAround();
            //                }
            //            }

            //            //центральные ячейки
            //            else
            //            {
            //                field.Cells[i - 1, j - 1].IncreaseMinesCountAround();
            //                field.Cells[i - 1, j].IncreaseMinesCountAround();
            //                field.Cells[i - 1, j + 1].IncreaseMinesCountAround();
            //                field.Cells[i, j - 1].IncreaseMinesCountAround();
            //                field.Cells[i, j + 1].IncreaseMinesCountAround();
            //                field.Cells[i + 1, j - 1].IncreaseMinesCountAround();
            //                field.Cells[i +1 , j].IncreaseMinesCountAround();
            //                field.Cells[i + 1, j + 1].IncreaseMinesCountAround();
            //            }
            //        }
            //    }
            //}

            //for (int i = 0; i < field.NumberOfRows - 1; i++)
            //{
            //    for (int j = 0; j < field.NumberOfColumns - 1; j++)
            //    {
            //        if (field.Rows[i].Cells[j].IsMine)
            //        {
            //            //верхние ячейки
            //            if (i == 0)
            //            {
            //                if (j == 0)
            //                {
            //                    field.Rows[i].Cells[j + 1].IncreaseMinesCountAround();
            //                    field.Rows[i + 1].Cells[j].IncreaseMinesCountAround();
            //                    field.Rows[i + 1].Cells[j + 1].IncreaseMinesCountAround();
            //                }
            //                if (j > 0 && j < field.NumberOfColumns - 1)
            //                {
            //                    field.Rows[i].Cells[j - 1].IncreaseMinesCountAround();
            //                    field.Rows[i].Cells[j + 1].IncreaseMinesCountAround();
            //                    field.Rows[i + 1].Cells[j - 1].IncreaseMinesCountAround();
            //                    field.Rows[i + 1].Cells[j].IncreaseMinesCountAround();
            //                    field.Rows[i + 1].Cells[j + 1].IncreaseMinesCountAround();
            //                }
            //                if (j == field.NumberOfColumns - 1)
            //                {
            //                    field.Rows[i].Cells[j - 1].IncreaseMinesCountAround();
            //                    field.Rows[i + 1].Cells[j - 1].IncreaseMinesCountAround();
            //                    field.Rows[i + 1].Cells[j].IncreaseMinesCountAround();
            //                }
            //            }

            //            //боковые слева и справа
            //            else if (i > 0 && i < field.NumberOfRows - 1)
            //            {
            //                if (j == 0)
            //                {
            //                    field.Rows[i - 1].Cells[j].IncreaseMinesCountAround();
            //                    field.Rows[i - 1].Cells[j + 1].IncreaseMinesCountAround();
            //                    field.Rows[i].Cells[j + 1].IncreaseMinesCountAround();
            //                    field.Rows[i + 1].Cells[j].IncreaseMinesCountAround();
            //                    field.Rows[i + 1].Cells[j + 1].IncreaseMinesCountAround();
            //                }
            //                if (j == field.NumberOfColumns - 1)
            //                {
            //                    field.Rows[i - 1].Cells[j - 1].IncreaseMinesCountAround();
            //                    field.Rows[i - 1].Cells[j].IncreaseMinesCountAround();
            //                    field.Rows[i].Cells[j - 1].IncreaseMinesCountAround();
            //                    field.Rows[i + 1].Cells[j - 1].IncreaseMinesCountAround();
            //                    field.Rows[i + 1].Cells[j].IncreaseMinesCountAround();
            //                }
            //            }

            //            //нижние ячейки
            //            else if (i == field.NumberOfRows - 1)
            //            {
            //                if (j == 0)
            //                {
            //                    field.Rows[i - 1].Cells[j].IncreaseMinesCountAround();
            //                    field.Rows[i - 1].Cells[j + 1].IncreaseMinesCountAround();
            //                    field.Rows[i].Cells[j + 1].IncreaseMinesCountAround();
            //                }
            //                if (j > 0 && j < field.NumberOfColumns - 1)
            //                {
            //                    field.Rows[i - 1].Cells[j - 1].IncreaseMinesCountAround();
            //                    field.Rows[i - 1].Cells[j].IncreaseMinesCountAround();
            //                    field.Rows[i - 1].Cells[j + 1].IncreaseMinesCountAround();
            //                    field.Rows[i].Cells[j - 1].IncreaseMinesCountAround();
            //                    field.Rows[i].Cells[j + 1].IncreaseMinesCountAround();
            //                }
            //                if (j == field.NumberOfColumns - 1)
            //                {
            //                    field.Rows[i - 1].Cells[j - 1].IncreaseMinesCountAround();
            //                    field.Rows[i - 1].Cells[j].IncreaseMinesCountAround();
            //                    field.Rows[i].Cells[j - 1].IncreaseMinesCountAround();
            //                }
            //            }

            //            //центральные ячейки
            //            else
            //            {
            //                field.Rows[i - 1].Cells[j - 1].IncreaseMinesCountAround();
            //                field.Rows[i - 1].Cells[j].IncreaseMinesCountAround();
            //                field.Rows[i - 1].Cells[j + 1].IncreaseMinesCountAround();
            //                field.Rows[i].Cells[j - 1].IncreaseMinesCountAround();
            //                field.Rows[i].Cells[j + 1].IncreaseMinesCountAround();
            //                field.Rows[i + 1].Cells[j - 1].IncreaseMinesCountAround();
            //                field.Rows[i + 1].Cells[j].IncreaseMinesCountAround();
            //                field.Rows[i + 1].Cells[j + 1].IncreaseMinesCountAround();
            //            }
            //        }
            //    }
            //}



            for (int i = 0; i < field.NumberOfRows; i++)
            {
                for (int j = 0; j < field.NumberOfColumns; j++)
                {
                    if (field.Cells[(i) * field.NumberOfColumns + j].IsMine)
                    {
                        //верхние ячейки
                        if (i == 0)
                        {
                            if (j == 0)
                            {
                                field.Cells[(i) * field.NumberOfColumns + j + 1].IncreaseMinesCountAround();
                                field.Cells[(i + 1) * field.NumberOfColumns + j].IncreaseMinesCountAround();
                                field.Cells[(i) * field.NumberOfColumns + j + 1].IncreaseMinesCountAround();
                            }
                            if (j > 0 && j < field.NumberOfColumns - 1)
                            {
                                field.Cells[(i) * field.NumberOfColumns + j - 1].IncreaseMinesCountAround();
                                field.Cells[(i) * field.NumberOfColumns + j + 1].IncreaseMinesCountAround();
                                field.Cells[(i + 1) * field.NumberOfColumns + j - 1].IncreaseMinesCountAround();
                                field.Cells[(i + 1) * field.NumberOfColumns + j].IncreaseMinesCountAround();
                                field.Cells[(i + 1) * field.NumberOfColumns + j + 1].IncreaseMinesCountAround();
                            }
                            if (j == field.NumberOfColumns - 1)
                            {
                                field.Cells[(i) * field.NumberOfColumns + j - 1].IncreaseMinesCountAround();
                                field.Cells[(i + 1) * field.NumberOfColumns + j - 1].IncreaseMinesCountAround();
                                field.Cells[(i + 1) * field.NumberOfColumns + j].IncreaseMinesCountAround();
                            }
                        }

                        //боковые слева и справа
                        else if (i > 0 && i < field.NumberOfRows - 1)
                        {
                            if (j == 0)
                            {
                                field.Cells[(i - 1) * field.NumberOfColumns + j].IncreaseMinesCountAround();
                                field.Cells[(i - 1) * field.NumberOfColumns + j + 1].IncreaseMinesCountAround();
                                field.Cells[(i) * field.NumberOfColumns + j + 1].IncreaseMinesCountAround();
                                field.Cells[(i + 1) * field.NumberOfColumns + j].IncreaseMinesCountAround();
                                field.Cells[(i + 1) * field.NumberOfColumns + j + 1].IncreaseMinesCountAround();
                            }
                            if (j == field.NumberOfColumns - 1)
                            {
                                field.Cells[(i - 1) * field.NumberOfColumns + j - 1].IncreaseMinesCountAround();
                                field.Cells[(i - 1) * field.NumberOfColumns + j].IncreaseMinesCountAround();
                                field.Cells[(i) * field.NumberOfColumns + j - 1].IncreaseMinesCountAround();
                                field.Cells[(i + 1) * field.NumberOfColumns + j - 1].IncreaseMinesCountAround();
                                field.Cells[(i + 1) * field.NumberOfColumns + j].IncreaseMinesCountAround();
                            }
                        }

                        //нижние ячейки
                        else if (i == field.NumberOfRows - 1)
                        {
                            if (j == 0)
                            {
                                field.Cells[(i - 1) * field.NumberOfColumns + j].IncreaseMinesCountAround();
                                field.Cells[(i - 1) * field.NumberOfColumns + j + 1].IncreaseMinesCountAround();
                                field.Cells[(i) * field.NumberOfColumns + j + 1].IncreaseMinesCountAround();
                            }
                            if (j > 0 && j < field.NumberOfColumns - 1)
                            {
                                field.Cells[(i - 1) * field.NumberOfColumns + j - 1].IncreaseMinesCountAround();
                                field.Cells[(i - 1) * field.NumberOfColumns + j].IncreaseMinesCountAround();
                                field.Cells[(i - 1) * field.NumberOfColumns + j + 1].IncreaseMinesCountAround();
                                field.Cells[(i) * field.NumberOfColumns + j - 1].IncreaseMinesCountAround();
                                field.Cells[(i) * field.NumberOfColumns + j + 1].IncreaseMinesCountAround();
                            }
                            if (j == field.NumberOfColumns - 1)
                            {
                                field.Cells[(i - 1) * field.NumberOfColumns + j - 1].IncreaseMinesCountAround();
                                field.Cells[(i - 1) * field.NumberOfColumns + j].IncreaseMinesCountAround();
                                field.Cells[(i) * field.NumberOfColumns + j - 1].IncreaseMinesCountAround();
                            }
                        }

                        //центральные ячейки
                        else
                        {
                            field.Cells[(i - 1) * field.NumberOfColumns + j - 1].IncreaseMinesCountAround();
                            field.Cells[(i - 1) * field.NumberOfColumns + j].IncreaseMinesCountAround();
                            field.Cells[(i - 1) * field.NumberOfColumns + j + 1].IncreaseMinesCountAround();
                            field.Cells[(i) * field.NumberOfColumns + j - 1].IncreaseMinesCountAround();
                            field.Cells[(i) * field.NumberOfColumns + j + 1].IncreaseMinesCountAround();
                            field.Cells[(i + 1) * field.NumberOfColumns + j - 1].IncreaseMinesCountAround();
                            field.Cells[(i + 1) * field.NumberOfColumns + j].IncreaseMinesCountAround();
                            field.Cells[(i + 1) * field.NumberOfColumns + j + 1].IncreaseMinesCountAround();
                        }
                    }
                }
            }
        }
    }
}
