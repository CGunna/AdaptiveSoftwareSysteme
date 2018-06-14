using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionTree.Implementation.Interfaces
{
    public interface ITreeSaver
    {
        void Export(Tree tree, string path);

        Tree Import(string path);
    }
}
