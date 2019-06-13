using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstarAlgorithm
{
    interface IGraph
    {
        void AddNode(Node n);
        void RemoveNode(Node n);
        void AddEdge(Node n, Node _n, int value);
    }
}
