using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstarAlgorithm
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Maze maze = new Maze();
        //    maze.SetSize(10, 20);
        //    maze.GenerateGrid();
        //    Console.ResetColor();
        //    Console.WriteLine("Using arrow keys navigate and place a 's' and 'e' point then press enter");
        //    Console.BackgroundColor = ConsoleColor.Yellow;
        //    maze.SetMazeElements();
        //    PathFinding pathFinding = new PathFinding(maze.nodes);
        //    pathFinding.CalculatePath();
        //    maze.VisualisePath(pathFinding.path);
        //    Console.Read();
        //}
        static void Main(string[] args)
        {
            Maze maze = new Maze();
            OnePass onePass = new OnePass();
            maze.SetSize(10, 20);
            maze.GenerateGrid();
            Console.ResetColor();
            Console.WriteLine("Using arrow keys navigate and place a 's' and 'e' point then press enter");
            Console.BackgroundColor = ConsoleColor.Yellow;
            maze.SetMazeElements();
            onePass.generateNodeGraph(maze.grid);
            onePass.RunConnections();
            maze.GenerateGrid(onePass.grid);
            OnePassPathFinding pathFinding = new OnePassPathFinding(onePass.nodes);
            pathFinding.CalculatePath();
            maze.VisualisePath(pathFinding.path);
            Console.Read();
        }
    }
}
