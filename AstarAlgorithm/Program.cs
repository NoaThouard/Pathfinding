using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AstarAlgorithm
{
    class Program
    {

        ////Uncomment to run grid based pathfinding and grid node generation
        //static void Main(string[] args)
        //{
        //    VisualiseMaze maze = new VisualiseMaze();
        //    OnePass onePass = new OnePass();
        //    ImportingBitmap mazeImage = new ImportingBitmap();
        //    GridSquare[,] grid = mazeImage.generateMazeFromImage();
        //    maze.SetSize(grid);
        //    //maze.GenerateGrid(grid);
        //    onePass.generateNodeGraph(grid);
        //    onePass.RunConnections();
        //    OnePassPathFinding pathFinding = new OnePassPathFinding(onePass.nodes);
        //    pathFinding.CalculatePath();
        //    maze.VisualisePath(pathFinding.path);
        //    Console.Read();
        //}
        //Uncomment to run grid based pathfinding and grid node generation
        static void Main(string[] args)
        {
            VisualiseMaze maze = new VisualiseMaze();
            OnePass onePass = new OnePass();
            ImportingBitmap mazeImage = new ImportingBitmap();
            GridSquare[,] grid = mazeImage.generateMazeFromImage();
            maze.SetSize(grid);
            //maze.GenerateGrid(grid);
            onePass.generateNodeGraph(grid);
            onePass.RunConnections();
            OnePassPathFinding pathFinding = new OnePassPathFinding(onePass.nodes);
            pathFinding.CalculatePath();
            maze.VisualisePath(pathFinding.path);
            Console.Read();
        }
        //Uncomment to run pathfinding
        //static void Main(string[] args)
        //{

        //    Stopwatch s = new Stopwatch();
        //    VisualiseMaze maze = new VisualiseMaze();
        //    ImportingBitmap mazeImage = new ImportingBitmap();
        //    GridSquare[,] grid = mazeImage.generateMazeFromImage();
        //    maze.SetSize(grid.GetLength(0), grid.GetLength(1));
        //    maze.GenerateGrid(maze.nodes, grid);
        //    s.Start();

        //    PathFinding pathFinding = new PathFinding(maze.nodes);
        //    pathFinding.CalculatePath();

        //    s.Stop();

        //    maze.VisualisePath(pathFinding.path);
        //    Console.Read();
        //}

        ////Uncomment to run OnePass pathfinding and generating a node graph based on bitmap
        ////static void Main(string[] args)
        ////{
        ////    VisualiseMaze maze = new VisualiseMaze();
        ////    OnePass onePass = new OnePass();
        ////    ImportingBitmap mazeImage = new ImportingBitmap();
        ////    GridSquare[,] grid = mazeImage.generateMazeFromImage();
        ////    maze.GenerateGrid(grid);
        ////    onePass.generateNodeGraph(grid);
        ////    onePass.RunConnections();
        ////    OnePassPathFinding pathFinding = new OnePassPathFinding(onePass.nodes);
        ////    pathFinding.CalculatePath();
        ////    maze.VisualisePath(pathFinding.path);
        ////    Console.Read();
        ////}

    }
}
