using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstarAlgorithm
{
    class PathFinding
    {
        //Grid
        private Node[,] nodes;
        //Constructor for node grid
        public PathFinding(Node[,] _nodes)
        {
            nodes = _nodes;
        }
        //open set
        private List<Node> openSet;
        //close set - Hash set is a collection that doesnt store duplicates
        private HashSet<Node> closeSet;
        private Node startingNode, goalNode;
        
        //Calculates Path using a grid of nodes
        public void CalculatePath()
        {
            openSet = new List<Node>();
            closeSet = new HashSet<Node>();
            if (startingNode == null || goalNode == null)
            {
                FindNodes();
            }
            openSet.Add(startingNode);

            //Run while loop while openSet is greater then 0
            while (openSet.Count > 0)
            {
                //take the first node in the collection
                Node currentNode = openSet[0];

                //Scan other nodes in openSet comparing it to current node, if another node has a lower fcost or equal fcost (but lower hCost) switch to that node as it's closer to the goal
                for (int i = 1 /*= 1 because current node is 0 and this is checking all nodes besides current node*/; i < openSet.Count; i++)
                {
                    ////Uncomment for dijkstra
                    //if (currentNode.gCost > openSet[i].gCost || currentNode.gCost == openSet[i].gCost)

                    ////Uncomment for greedy best-first seach
                    //if (currentNode.hCost > openSet[i].hCost || currentNode.hCost == openSet[i].hCost)

                    //Uncomment for A* search algorthm
                    if (currentNode.fCost > openSet[i].fCost || currentNode.fCost == openSet[i].fCost && currentNode.hCost > openSet[i].hCost)
                        {
                        currentNode = openSet[i];
                    }
                }

                //Remove current node from openset as it's beening checked and isn't waiting to be checked
                openSet.Remove(currentNode);
                closeSet.Add(currentNode);

                //if goal is reached
                if (currentNode == goalNode)
                {
                    CreatePath(startingNode, goalNode);
                    return;
                }
                
                //Check all neighbours of the current node
                foreach (Node neighbour in GetNeighbours(currentNode))
                {
                    if (neighbour.nodeType == "Obstacle" || closeSet.Contains(neighbour))
                    {
                        continue;
                    }
                    //calculate costs
                    int movementCost = currentNode.gCost + ManhattanDistance(currentNode, neighbour);
                    if (movementCost < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = movementCost;
                        neighbour.hCost = ManhattanDistance(neighbour, goalNode);
                        neighbour.parent = currentNode;
                        openSet.Add(neighbour);
                    }
                }
            }

        }
        public List<Node> GetNeighbours(Node n)
        {
            List<Node> neighbours = new List<Node>();
            //Checks x - 1 & x + 1 thus top and bottom, adds neighbour if they're within bounds
            for (int x = -1; x <= 1; x++)
            {
                if (x == 0)
                {
                    continue;
                }
                else
                {
                    //if neighbour is within bounds
                    int checkX = n.posI + x;
                    int checkY = n.posJ;
                    //If the Neighbour is within the bounds of the grid add it to the list
                    if (checkX > -1 && checkX < nodes.GetLength(0) && checkY > -1 && checkY < nodes.GetLength(1))
                    {
                        neighbours.Add(RetrieveNode(checkX, checkY));
                    }
                }
            }
            for (int y = -1; y <= 1; y++)
            {
                if (y == 0)
                {
                    continue;
                }
                else
                {
                    int checkX = n.posI;
                    int checkY = n.posJ + y;
                    //If the Neighbour is within the bounds of the grid add it to the list
                    if (checkX > -1 && checkX < nodes.GetLength(0) && checkY > -1 && checkY < nodes.GetLength(1))
                    {
                        neighbours.Add(RetrieveNode(checkX, checkY));
                    }
                }
            }
            return neighbours;
        }
        public void FindNodes()
        {
            foreach (Node n in nodes)
            {
                if (n.nodeType == "Walkable")
                {
                    continue;
                }
                else if (n.nodeType == "Start")
                {
                    startingNode = n;
                }
                else if (n.nodeType == "Goal")
                {
                    goalNode = n;
                }
            }
        }
        //Used to retrieve node from the grid
        public Node RetrieveNode(int posX, int posY)
        {
            return nodes[posX, posY];
        }
        //Modified Non-Diagonal cost calculation
        public int ModifiedManhattanDistance(Node current, Node target)
        {
            int distanceX = Math.Abs(current.posI - target.posI);
            int distanceY = Math.Abs(current.posJ - target.posJ);

            if (distanceX > distanceY)
            {
                return (14 * distanceY + 10 * (distanceX - distanceY));
            }
            else
            {
                return (14 * distanceX + 10 * (distanceY - distanceX));
            }
        }
        //Modified Non-Diagonal cost calculation
        public int ManhattanDistance(Node current, Node target)
        {
            int movementCost = 10;
            int distanceX = Math.Abs(current.posI - target.posI);
            int distanceY = Math.Abs(current.posJ - target.posJ);
            return movementCost * (distanceX + distanceY);
        }
        //Diagonal cost calculation
        public int DiagonalManhattanDistance(Node current, Node target)
        {
            int movementCost = 10;
            int diagonalMovementCost = 14;
            int distanceX = Math.Abs(current.posI - target.posI);
            int distanceY = Math.Abs(current.posJ = target.posJ);
            return (movementCost * (distanceX + distanceY) + (diagonalMovementCost - 2 * movementCost) * Math.Min(distanceX, distanceY));
        }

        //Creates a list linking each step took to reach the goal 
        public List<Node> path;
        void CreatePath(Node start, Node end)
        {
            path = new List<Node>();
            Node current = end.parent;
            while (current != start)
            {
                path.Add(current);
                current = current.parent;
            }
            path.Reverse();
        }
    }
}
