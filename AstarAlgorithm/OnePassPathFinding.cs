using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstarAlgorithm
{
    class OnePassPathFinding
    {
        //OnePass node graph
        private List<Node> onePassNodes;
        //Constructor for one pass node
        public OnePassPathFinding(List<Node> _onePassNodes)
        {
            onePassNodes = _onePassNodes;
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
                foreach (Node neighbour in currentNode.neighbours)
                {
                    if (neighbour == null) { continue; }
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
        public void FindNodes()
        {
            foreach (Node n in onePassNodes)
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
        //Modified Non-Diagonal cost calculation
        public int ModifiedManhattanDistance(Node current, Node target)
        {
            int distanceX = Math.Abs(current.posI - target.posI);
            int distanceY = Math.Abs(current.posJ - target.posJ);

            if (distanceX > distanceY)
            {
                return (distanceY + 10 * (distanceX - distanceY));
            }
            else
            {
                return (distanceX + 10 * (distanceY - distanceX));
            }
        }
        //Non-Diagonal cost calculation
        public int ManhattanDistance(Node current, Node target)
        {
            int distanceX = Math.Abs(current.posI - target.posI);
            int distanceY = Math.Abs(current.posJ - target.posJ);
            return 10 * (distanceX + distanceY);
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

