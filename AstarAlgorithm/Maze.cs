﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstarAlgorithm
{
    class Maze
    {
        //Using node & grid class create arrays[]
        public Node[,] nodes;
        GridSquare[,] grid; 
        //called to set the size of the grid
        public void SetSize(int size)
        {
            nodes = new Node[size, size];
            grid = new GridSquare[size, size];

        }
        //GenerateMaze() called when there isn't a existing grid
        public void GenerateGrid()
        {
            Random random = new Random();
            int randomNum;

            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    randomNum = random.Next(1, 100);
                    if (randomNum > 75)//25 percent chance to spawn a obstacle
                    {
                        GridSquare temp = new GridSquare(ConsoleColor.Black, "Obstacle");
                        grid[x, y] = temp;
                    }
                    else
                    {
                        GridSquare temp = new GridSquare(ConsoleColor.Yellow, "Walkable");
                        grid[x, y] = temp;
                    }

                }
            }
        }
        //GenerateMaze(grid) overload used to update a grid after the user has inputed the start and end point
        public void GenerateGrid(GridSquare[,] grid)
        {
            Console.ResetColor();
            Console.Clear();
            int gCount = 0;
            foreach (GridSquare g in grid)
            {
                if (gCount == grid.GetLength(1))
                    {
                    Console.Write(Environment.NewLine);
                    gCount = 0;
                    }

                PrintSquare(g);

                gCount++;
            }
        }
        //GenerateMaze(nodeGrid) overload used to generate a node grid based on visual grid
        public void GenerateGrid(Node[,] nodeGrid, GridSquare[,] grid)
        {
            Console.ResetColor();
            Console.Clear();
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    GridSquare tempGrid = grid[x, y];
                    Node tempNode = new Node(tempGrid.type, x, y);
                    nodeGrid[x, y] = tempNode;
                }
            }
        }
        public void VisualisePath(List<Node> path)
        {
            foreach (Node n in path)
            {
                GridSquare temp = grid[n.posX, n.posY];
                temp.type = "path";
                temp.colour = ConsoleColor.DarkBlue;
                grid[n.posX, n.posY] = temp;
            }
            GenerateGrid(grid);

        }
        //Prints the grid squares
        void PrintSquare(GridSquare gridSquare)
        {
            Console.BackgroundColor = gridSquare.colour;
            Console.Write(" ");
            //Console.ResetColor();
        }

        //Allows the user to navigate the grid using arrow keys; the user then can place the start and goal point
        public void SetMazeElements()
        {
            int posLeft = 0;
            int posTop = 0;
            bool startSet = false, endSet = false;
            while (true)
            {
                Console.SetCursorPosition(posLeft, posTop);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    GenerateGrid(grid);//reloads the grid every time there is a change - implemted because in the console moving the cursor will erase colours
                    switch (key.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            {
                                if (posLeft != 0)
                                {
                                    posLeft--;
                                    Console.SetCursorPosition(posLeft, posTop);
                                }
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                if (posLeft < grid.GetLength(0) - 1)
                                {
                                    posLeft++;
                                    Console.SetCursorPosition(posLeft, posTop);
                                }
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                if (posTop < grid.GetLength(1) - 1)
                                {
                                    posTop++;
                                    Console.SetCursorPosition(posLeft, posTop);
                                }
                                break;
                            }
                        case ConsoleKey.UpArrow:
                            {
                                if (posTop != 0)
                                {
                                    posTop--;
                                    Console.SetCursorPosition(posLeft, posTop);
                                }
                                break;
                            }
                        case ConsoleKey.S:
                            {
                                if (grid[posTop, posLeft].type == "Walkable" && startSet == false)
                                {
                                    grid[posTop, posLeft].type = "Start";
                                    grid[posTop, posLeft].colour = ConsoleColor.Blue;
                                    startSet = true;
                                }
                                break;
                            }
                        case ConsoleKey.E:
                            {
                                if (grid[posTop, posLeft].type == "Walkable" && endSet == false)
                                {
                                    grid[posTop, posLeft].type = "Goal";
                                    grid[posTop, posLeft].colour = ConsoleColor.DarkRed;
                                    endSet = true;
                                }
                                break;
                            }
                        case ConsoleKey.Enter:
                            {
                                if (startSet == true && endSet == true)
                                {
                                    GenerateGrid(nodes, grid);
                                    return;
                                }
                                break;
                            }
                    }
                }
            }
        }


    }
}
