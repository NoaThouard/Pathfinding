using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding_Altitudes
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
        public int altitude;
        public int posI, posJ;
        public Node parent;
        //Constructor - when called "new Node()"
        public Node(string _nodeType, int _posI, int _posJ, int _altitude)
        {
            nodeType = _nodeType;
            posI = _posI;
            posJ = _posJ;
            altitude = _altitude;
        }
    }
}
