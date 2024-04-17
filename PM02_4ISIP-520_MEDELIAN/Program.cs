using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM02_4ISIP_520_MEDELIAN
{
    class Program
    {
        static (int[][], int) NorthwestCornerMethod(int[] supply, int[] demand, int[][] costs)
        {
            int[][] allocation = new int[supply.Length][];
            for (int i = 0; i < supply.Length; i++)
            {
                allocation[i] = new int[demand.Length];
            }

            int[] supplyCopy = supply.ToArray();
            int[] demandCopy = demand.ToArray();
            int totalCost = 0;

            int row = 0, col = 0;
            while (row < supply.Length && col < demand.Length)
            {
                int x = Math.Min(supplyCopy[row], demandCopy[col]);
                allocation[row][col] = x;
                supplyCopy[row] -= x;
                demandCopy[col] -= x;
                totalCost += x * costs[row][col];

                if (supplyCopy[row] == 0)
                {
                    row++;
                }
                else
                {
                    col++;
                }
            }

            return (allocation, totalCost);
        }


        static void Main()
        {
            // Исходные данные
            int[] supply = { 40, 22, 40 };
            int[] demand = { 20, 15, 35, 30 };
            int[][] costs = new int[][]
            {
            new int[] { 5, 5, 5, 5 },
            new int[] { 7, 7, 7, 7 },
            new int[] { 9, 9, 9, 9 }
            };

            // Опорный план северо-западного угла
            var (allocationNW, totalCostNW) = NorthwestCornerMethod(supply, demand, costs);

            foreach (var row in allocationNW)
            {
                Console.WriteLine(string.Join(", ", row));
            }
            Console.WriteLine("Total Cost: " + totalCostNW);


            Console.ReadKey();
        }
    }
}
