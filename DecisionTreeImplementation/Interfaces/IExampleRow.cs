﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    interface IExampleRow
    {
        string Class { get; }

        List<IExample> Items { get; }
    }
}