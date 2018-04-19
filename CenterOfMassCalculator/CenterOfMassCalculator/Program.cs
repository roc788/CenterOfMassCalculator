using System;
using System.Collections.Generic;

namespace IonicAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] arrayGrid = new int[6,6];
            arrayGrid[0, 0] = 0;
            arrayGrid[0, 1] = 115;
            arrayGrid[0, 2] = 5;
            arrayGrid[0, 3] = 15;
            arrayGrid[0, 4] = 0;
            arrayGrid[0, 5] = 5;
            arrayGrid[1, 0] = 80;
            arrayGrid[1, 1] = 210;
            arrayGrid[1, 2] = 0;
            arrayGrid[1, 3] = 5;
            arrayGrid[1, 4] = 5;
            arrayGrid[1, 5] = 0;
            arrayGrid[2, 0] = 45;
            arrayGrid[2, 1] = 60;
            arrayGrid[2, 2] = 145;
            arrayGrid[2, 3] = 175;
            arrayGrid[2, 4] = 95;
            arrayGrid[2, 5] = 25;
            arrayGrid[3, 0] = 95;
            arrayGrid[3, 1] = 5;
            arrayGrid[3, 2] = 250;
            arrayGrid[3, 3] = 250;
            arrayGrid[3, 4] = 115;
            arrayGrid[3, 5] = 5;
            arrayGrid[4, 0] = 170;
            arrayGrid[4, 1] = 230;
            arrayGrid[4, 2] = 245;
            arrayGrid[4, 3] = 185;
            arrayGrid[4, 4] = 165;
            arrayGrid[4, 5] = 145;
            arrayGrid[5, 0] = 145;
            arrayGrid[5, 1] = 220;
            arrayGrid[5, 2] = 140;
            arrayGrid[5, 3] = 160;
            arrayGrid[5, 4] = 250;
            arrayGrid[5, 5] = 250;

            int threshold = 200;

            List<double[]> centerOfMassList = ArrayGridHelper.GetCenterOfMassList(arrayGrid, threshold);
            int i = 1;
            foreach(var com in centerOfMassList)
            {
                Console.WriteLine("Coordinates for center of mass for region " + i + ": " + com[0] + ", " + com[1]);
                i++;
            }

            Console.ReadKey();
        }
    }
}
