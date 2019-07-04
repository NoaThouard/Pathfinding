using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstarAlgorithm
{
    class ImportingBitmap
    {
        public GridSquare[,] generateMazeFromImage()
        {
            //Reference a bitmap image, @ + a string of it's location
            Bitmap img = new Bitmap(@"C:\Users\Noa_t\source\repos\AstarAlgorithm\MyMazeLarge.bmp");
            //Bitmap img = new Bitmap(@"C:\Users\Noa_t\source\repos\AstarAlgorithm\MyMaze.bmp");
            //Generate a grid to represent the maze in the console
            GridSquare[,] grid = new GridSquare[img.Height,img.Width];
            //Depending on the colours of a pixel do different things.
            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    Color pixel = img.GetPixel(j, i);
                    //If the pixel RGB = black, add it as a obstacle in the array
                    if (pixel.R == Color.Black.R && pixel.B == Color.Black.B && pixel.G == Color.Black.G)
                    {
                        GridSquare temp = new GridSquare(ConsoleColor.Black, "Obstacle");
                        grid[i, j] = temp;
                    }
                    //If the pixel RGB = blue, add it as a goal in the array
                    else if (pixel.R == Color.Blue.R && pixel.B == Color.Blue.B && pixel.G == Color.Blue.G)
                    {
                        GridSquare temp = new GridSquare(ConsoleColor.Blue, "Goal");
                        grid[i, j] = temp;
                    }
                    //If the pixel RGB = green, add it as a start in the array
                    else if (pixel.R == Color.Green.R && pixel.B == Color.Green.B && pixel.G == 255)
                    {
                        GridSquare temp = new GridSquare(ConsoleColor.DarkGreen, "Start");
                        grid[i, j] = temp;
                    }
                    //If the pixel RGB = yellow, add it as a walkable in the array
                    else
                    {
                        GridSquare temp = new GridSquare(ConsoleColor.White, "Walkable");
                        grid[i, j] = temp;
                    }
                }
            }
            return grid;
        }

        public GridSquare[,] generateHeightMapFromImage()
        {
            //Reference a bitmap image, @ + a string of it's location
            Bitmap img = new Bitmap(@"C:\Users\Noa_t\source\repos\AstarAlgorithm\BitmapAltitude.bmp");
            //Bitmap img = new Bitmap(@"C:\Users\Noa_t\source\repos\AstarAlgorithm\MyMaze.bmp");
            //Generate a grid to represent the maze in the console
            GridSquare[,] grid = new GridSquare[img.Height, img.Width];
            //Depending on the colours of a pixel do different things.
            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    Color pixel = img.GetPixel(j, i);
                    //If the pixel RGB = black, add it as a obstacle in the array
                    if (pixel.R == Color.Black.R && pixel.B == Color.Black.B && pixel.G == Color.Black.G)
                    {
                        GridSquare temp = new GridSquare(ConsoleColor.Black, "Obstacle");
                        grid[i, j] = temp;
                    }
                    //If the pixel RGB = blue, add it as a goal in the array
                    else if (pixel.R == Color.Blue.R && pixel.B == Color.Blue.B && pixel.G == Color.Blue.G)
                    {
                        GridSquare temp = new GridSquare(ConsoleColor.Blue, "Goal");
                        grid[i, j] = temp;
                    }
                    //If the pixel RGB = green, add it as a start in the array
                    else if (pixel.R == Color.Green.R && pixel.B == Color.Green.B && pixel.G == 255)
                    {
                        GridSquare temp = new GridSquare(ConsoleColor.DarkGreen, "Start");
                        grid[i, j] = temp;
                    }
                    //If the pixel RGB = yellow, add it as a walkable in the array
                    else
                    {
                        GridSquare temp = new GridSquare(ConsoleColor.White, "Walkable");
                        grid[i, j] = temp;
                    }
                }
            }
            return grid;
        }
    }
}
