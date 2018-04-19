using System;
using System.Collections.Generic;

namespace IonicAssessment
{
    public static class ArrayGridHelper
    {
        public static List<double[]> GetCenterOfMassList(int[,] array, int threshold)
        {
            List<Region> regionsOfInterest = new List<Region>();
            List<Cell> cellsOfInterest = new List<Cell>();
            List<double[]> centerOfMassList = new List<double[]>();

            for(int x = 0; x < array.GetLength(1); x++)
            {
                for(int y = 0; y < array.GetLength(0); y++)
                {
                    if(array[x,y] > threshold)
                    {
                        Cell cell = new Cell();
                        cell.coordinates[0] = x;
                        cell.coordinates[1] = y;
                        cell.value = array[x,y];
                        cellsOfInterest.Add(cell);
                    }
                }
            }

            foreach(Cell cell in cellsOfInterest)
            {
                int x = cell.coordinates[0];
                int y = cell.coordinates[1];
                bool regionExists = false;

                if(regionsOfInterest.Count == 0)
                {
                    Region region = new Region();
                    region.cells = new List<Cell>();
                    region.cells.Add(cell);
                    regionsOfInterest.Add(region);
                    continue;
                }

                foreach (Region regionOfInterest in regionsOfInterest)
                {
                    if (regionOfInterest.cells.Exists(i =>
                            (i.coordinates[0] + 1 == x && i.coordinates[1] == y) ||
                            (i.coordinates[0] - 1 == x && i.coordinates[1] == y) ||
                            (i.coordinates[0] == x && i.coordinates[1] + 1 == y) ||
                            (i.coordinates[0] == x && i.coordinates[1] - 1 == y) ||
                            (i.coordinates[0] + 1 == x && i.coordinates[1] + 1 == y) ||
                            (i.coordinates[0] - 1 == x && i.coordinates[1] - 1 == y) ||
                            (i.coordinates[0] + 1 == x && i.coordinates[1] - 1 == y) ||
                            (i.coordinates[0] - 1 == x && i.coordinates[1] + 1 == y)) 
                        &&
                            !regionOfInterest.cells.Exists(i => 
                            (i.coordinates[0] == x && i.coordinates[1] == y))
                      )
                    {
                        regionOfInterest.cells.Add(cell);
                        regionExists = true;
                        break;
                    }
                }

                if(!regionExists)
                {
                    Region region = new Region();
                    region.cells = new List<Cell>();
                    region.cells.Add(cell);
                    regionsOfInterest.Add(region);
                }
            }

            foreach(Region regionOfInterest in regionsOfInterest)
            {
                double comX = 0;
                double comY = 0;
                double totalMass = 0;

                foreach(Cell cell in regionOfInterest.cells)
                {                    
                    comX += cell.coordinates[0] * cell.value;
                    comY += cell.coordinates[1] * cell.value;
                    totalMass += cell.value;
                }

                comX /= totalMass;
                comY /= totalMass;

                regionOfInterest.centerOfMass[0] = Math.Round(comX, 2);
                regionOfInterest.centerOfMass[1] = Math.Round(comY, 2);
                centerOfMassList.Add(regionOfInterest.centerOfMass);
            }

            return centerOfMassList;
        }
    }
}
