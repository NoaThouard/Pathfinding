using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstarAlgorithm
{
    class OnePass
    {
        public GridSquare[,] grid;
        public List<Node> nodes;

        public void generateNodeGraph(GridSquare[,] _grid)
        {
            grid = _grid;
            nodes = new List<Node>();

                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        //Skip current square if it = obstacle
                        if (grid[i, j].type == "Obstacle") { continue; }
                        else if (grid[i, j].type == "Walkable")
                        {
                            //Place node at index based on the combination of it's neighbours
                            if (ShouldNodeBePlaced(i,j) == true)
                            {
                                Node tempNode = new Node(grid[i, j].type, i, j);
                                nodes.Add(tempNode);
                                grid[i, j] = new GridSquare(ConsoleColor.White, "Walkable");
                            }
                            else { continue; }
                        }
                        //if not obstacle or walkable AKA starting and goal square, place a node.
                        else
                        {
                           Node tempNode = new Node(grid[i, j].type, i, j);
                            nodes.Add(tempNode);
                        }

                    }
                }

            
        }
        bool ShouldNodeBePlaced(int i, int j)
        {
            //ObstacleCount, WalkableCount
            int oCount = 0, wCount = 0;
            //0 = walkable, 1 = obstacle;
            //NESW aka N = [0], E = [1], S = [2], W = [3]
            int[] neighbourType = new int[4];


            for (int x = -1; x <= 1; x++)
            {
                if (x == 0) { continue; } //if the checking itself, or if checking outside of bounds skip
                else
                {
                    if (grid[i, j + x].type == "Obstacle" || j + x < 0 || j + x > grid.GetLength(1))
                    {
                        oCount += 1;
                        //Mark West neighbour as a obstacle
                        if (x == -1) { neighbourType[3] = 1; }
                        //Mark East neighbour as a obstacle
                        else if (x == 1)
                        { neighbourType[1] = 1; }
                    }
                    else
                    {
                        wCount += 1;
                        //Mark West neighbour as a walkable
                        if (x == -1) { neighbourType[3] = 0; }
                        //Mark East neighbour as a walkable
                        else if (x == 1)
                        { neighbourType[1] = 0; }
                    }
                }
            }
            for (int y = -1; y <= 1; y++)
            {
                if (y == 0) { continue; } //if the checking itself, or if checking outside of bounds skip
                else
                {
                    if (grid[i + y, j].type == "Obstacle" || i + y < 0 || i + y > grid.GetLength(0))
                    {
                        oCount += 1;
                        //Mark North neighbour as a obstacle
                        if (y == -1)
                        { neighbourType[0] = 1; }
                        //Mark South neighbour as a obstacle
                        else if (y == 1) { neighbourType[2] = 1;}
                    }
                    else
                    {
                        wCount += 1;
                        //Mark North neighbour as a walkable
                        if (y == -1)
                        { neighbourType[0] = 0; }
                        //Mark South neighbour as a walkable
                        else if (y == 1) { neighbourType[2] = 0; }
                    }
                }
            }

            return Combinations(oCount, wCount, neighbourType);
        }
        bool Combinations(int oCount, int wCount, int[] nTypes)
        {
            //If Dead end/end or start of Corridor place a node;
            if (oCount == 3 && wCount == 1) { return true; }

            //If at a junction/three way intersection place a node
            if (oCount == 1 && wCount == 3) { return true; }

            //If in the middle of a corridor return false as their a no new directions to go
            if (oCount == 2 && wCount == 2)
            {
                if (nTypes[1] == 1 && nTypes[3] == 1)
                {
                    return false;
                }
                else if (nTypes[0] == 1 && nTypes[2] == 1)
                {
                    return false;
                }
                else { return true; }
            }

            //If surrounded by only walkable tiles place node as the node can travel in any direction
            if (oCount == 0 && wCount == 4) { return true; }

            //If node is surrounded by only obstacles don't place node as it cannot be reached
            if (oCount == 4 && wCount == 0) { return false; }

            else { Console.WriteLine("New Combination" + oCount + " " + wCount); return true; }
        }
        public void RunConnections()
        { foreach(Node n in nodes) { GetConnection(n); }
        }
        public void GetConnection(Node n)
        {
            int iterator = 1;
            while (true)
            {
                if (n.neighbours[0] == null) //no North/above neighbour
                {
                    if (n.posI - iterator < 0) { break; }
                    else if (grid[n.posI - iterator, n.posJ].type != "Obstacle") //if the checked postion is within bounds and is not an obstacle
                    {
                        if (nodes.Find(x => x.posI == (n.posI - iterator) && x.posJ == n.posJ) != null) //if there is a node at the checked position
                        {
                            //Set current node above neighbour and set the neighbours below to current node
                            n.neighbours[0] = nodes.Find(x => x.posI == (n.posI - iterator) && x.posJ == n.posJ);
                            nodes.Find(x => x.posI == (n.posI - iterator) && x.posJ == n.posJ).neighbours[2] = n;


                        }
                        else
                        {
                            iterator++;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
                iterator = 1;
                while (true)
                {
                    if (n.neighbours[3] == null) //no west/left neighbour
                    {
                        if (n.posJ - iterator < 0) { break; }
                        else if (grid[n.posI, n.posJ - iterator].type != "Obstacle") //if the checked postion is within bounds and is not an obstacle
                        {
                            if (nodes.Find(x => x.posI == n.posI && x.posJ == (n.posJ - iterator)) != null) //if there is a node at the checked position
                            {
                            //Set current node Left neighbour to neighbour and set the neighbours right to current node
                            n.neighbours[3]= nodes.Find(x => x.posI == n.posI && x.posJ == (n.posJ) - iterator);
                            nodes.Find(x => x.posI == n.posI && x.posJ == (n.posJ) - iterator).neighbours[1] = n;
                            }
                            else
                            {
                                iterator++;
                            }  
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            
        }
        void _GetNeighboursType(int i, int j)
        {
            //0 = walkable, 1 = obstacle;
            //NESW aka N = [0], E = [1], S = [2], W = [3]
            int[] neighbourType = new int[3];

            for (int x = -1; x <= 1; x++)
            {
                if (x == 0 || j + x == 0 || j + x > grid.GetLength(1)) { continue; } //if the checking itself, or if checking outside of bounds skip
                else
                {
                    if (grid[i, j + x].type == "Obstacle")
                    {
                        if (x == -1)
                        {
                            //Mark West neighbour as a obstacle
                           neighbourType[3] = 1;
                        }
                        else if (x == 1)
                        {
                            //Mark East neighbour as a obstacle
                            neighbourType[1] = 1;
                        }
                    }
                    else
                    {
                        if (x == -1)
                        {
                            //Mark West neighbour as a walkable
                            neighbourType[3] = 0;
                        }
                        else if (x == 1)
                        {
                            //Mark East neighbour as a walkable
                            neighbourType[1] = 0;
                        }
                    }
                }
            }
            for (int y = -1; y <= 1; y++)
            {
                if (y == 0 || i + y == 0 || i + y > grid.GetLength(0)) { continue; } //if the checking itself, or if checking outside of bounds skip
                else
                {
                    if (grid[i + y, j].type == "Obstacle")
                    {
                        if (y == -1)
                        {
                            //Mark North neighbour as a obstacle
                            neighbourType[0] = 1;
                        }
                        else if (y == 1)
                        {
                            //Mark South neighbour as a obstacle
                            neighbourType[2] = 1;
                        }
                    }
                    else
                    {
                        if (y == -1)
                        {
                            //Mark North neighbour as a walkable
                            neighbourType[0] = 0;
                        }
                        else if (y == 1)
                        {
                            //Mark South neighbour as a walkable
                            neighbourType[2] = 0;
                        }
                    }
                }
            }

        }

    }
}
