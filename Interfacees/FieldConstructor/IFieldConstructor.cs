using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariableSapper.Models.FieldElements;

namespace VariableSapper.Interfacees.FieldConstructor
{
    internal interface IFieldConstructor
    {
        public MineField CreateField(int rows, int columns, int minesCount);
    }
}
