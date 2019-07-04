using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Pathfinding_Altitudes
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadBitmap bitmap = new ReadBitmap(@"C:\Users\Noa_t\source\repos\AstarAlgorithm\BitmapAltitude.bmp");
            Node[,] nodeArray = bitmap.generateHeightMapFromImage();
            PathFinding pathfinder = new PathFinding(nodeArray);
            bitmap.VisualiseAndSave(pathfinder.CalculatePath(), nodeArray);

        }
    }
}
