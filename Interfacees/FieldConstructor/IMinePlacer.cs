﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariableSapper.Models.FieldElements;

namespace VariableSapper.Interfacees.FieldConstructor
{
    internal interface IMinePlacer
    {
        public void PlaceMines(MineField field);
    }
}
