﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation
{
    interface IExample
    {
        IFeature RelatedFeature { get; set; }

        object Value { get; set; }
    }
}