using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstarAlgorithm
{
    class Graph : IGraph
    {
        private int nodeCount;
        private List<Int32> adj;

        public Graph(int nCount)
        {

        }
        public void GenerateLinkList()
        {
            LinkedList<Node> graph = new LinkedList<Node>();

        }
        public void AddEdge(Node n, Node _n, int value)
        {
            throw new NotImplementedException();
        }

        public void AddNode(Node n)
        {
            throw new NotImplementedException();
        }

        public void RemoveNode(Node n)
        {
            throw new NotImplementedException();
        }
    }
}
