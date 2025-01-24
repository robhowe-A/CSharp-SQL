/*
 * Description: This program utilizes looping to display steps in the console
 * as a programming exercise.
 * Date: 1-23-2025
 * Author: Robert Howell
 */

namespace ConsoleStairs
{
    class Stairs
    {
        private static void WriteSquares(int rowCount = 8, bool showRowNum = true, bool showStarsCount = false)
        {
            double row = 0;
            double j;
            while (row < rowCount)
            {
                j = Math.Pow(row, 2);
                for (int i = 0; i <= j ;i++)
                {
                    if(showRowNum & i == 0)
                        Console.Write($"{row}: ");
                    Console.Write("{0}", '*');
                }
                    if (showStarsCount)
                        Console.Write($" {j}");
                    Console.WriteLine();
                row++;
            }
        }

        static void Main()
        {
            WriteSquares(10, true, false);
        }
    };
}
