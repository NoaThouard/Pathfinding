using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinding_Altitudes
{
    class ReadBitmap
    {
        public ReadBitmap(string _imgLocation)
        {
            imgLocation = _imgLocation;
        }
        private string imgLocation;
        public Node[,] generateHeightMapFromImage()
        {
            //Reference a bitmap image, @ + a string of it's location
            Bitmap img = new Bitmap(@imgLocation);
            //Bitmap img = new Bitmap(@"C:\Users\Noa_t\source\repos\AstarAlgorithm\MyMaze.bmp");
            //Generate a grid to represent the maze in the console
            //Depending on the colours of a pixel do different things.
            Node[,] nodeArray = new Node[img.Height, img.Width];
            Color pixel;
            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    pixel = img.GetPixel(j, i);
                    //If the pixel RGB = blue, add it as a goal in the array
                    if (pixel.R == Color.Blue.R && pixel.B == Color.Blue.B && pixel.G == Color.Blue.G)
                    {
                        nodeArray[i, j] = new Node("Start", i, j, 0);
                    }
                    //If the pixel RGB = green, add it as a start in the array
                    else if (pixel.R == Color.Green.R && pixel.B == Color.Green.B && pixel.G == 255)
                    {
                        nodeArray[i, j] = new Node("Goal", i, j, 0);
                    }
                    else
                    {
                        //For each node store its altitude (its pixel colour and position)
                        nodeArray[i, j] = new Node("Walkable", i, j, Math.Abs(pixel.R));
                    }
                }
            }
            return nodeArray;
        }
        
        public void VisualiseAndSave(List<Node> path, Node[,] nArray)
        {
            Bitmap img = new Bitmap(@imgLocation);
            Color pixel;
            Bitmap bmp = new Bitmap(img.Width,img.Height);


            //for (int i = 0; i < img.Height; i++)
            //{
            //    for (int j = 0; j < img.Width; j++)
            //    {
            //        pixel = img.GetPixel(j, i);
            //        bmp.SetPixel(i, j, pixel);
            //    }
            //}
            foreach (Node n in nArray)
            {
                pixel = img.GetPixel(n.posI, n.posJ);
                bmp.SetPixel(n.posI, n.posJ, pixel);
            }
            foreach (Node n in path)
            {
                bmp.SetPixel(n.posJ, n.posI, Color.Yellow);
            }



            bmp.Save("C:\\Users\\Noa_t\\source\\repos\\AstarAlgorithm\\Pathfinding_Altitudes\\Results\\ResultsPath.bmp");
        }
    }
}
