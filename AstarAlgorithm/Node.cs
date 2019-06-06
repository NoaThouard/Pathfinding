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
        public int posX, posY;
        public Node parent;
        //Constructor - when called "new Node()"
        public Node(string _nodeType, int _posX, int _posY)
        {
            nodeType = _nodeType;
            posX = _posX;
            posY = _posY;
        }

    }
}
