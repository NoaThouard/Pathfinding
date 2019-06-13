using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstarAlgorithm
{
    class Node
    {
        public string nodeType;
        public int gCost, hCost;
        public int fCost
        {
            get
            {
                return gCost + hCost;
            }
        }
        public int posI, posJ;
        public Node parent;
        //Constructor - when called "new Node()"
        public Node(string _nodeType, int _posI, int _posJ)
        {
            nodeType = _nodeType;
            posI = _posI;
            posJ = _posJ;
        }

       //NESW aka top, right, down
       public Node[] neighbours = { null,null,null,null }; 
    }
}
