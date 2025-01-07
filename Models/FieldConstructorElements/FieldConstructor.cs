using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariableSapper.Interfacees.FieldConstructor;
using VariableSapper.Models.FieldElements;

namespace VariableSapper.Models.FieldConstructorElements
{
    internal class FieldConstructor : IFieldConstructor
    {
        private readonly IMinePlacer _minePlacer;
        private readonly INumbersFiller _numbersFiller;

        public MineField CreateField(int rows, int columns, int minesCount)
        {
            if (rows <= 0 || columns <= 0) return null;

            MineField field = new MineField(rows, columns, minesCount);

            _minePlacer.PlaceMines(field);

            _numbersFiller.FillNumbersOnField(field);

            return field;
        }




        public FieldConstructor()
        {
            _minePlacer = new MinePlacer();
            _numbersFiller = new NumbersFiller();
        }
    }
}
