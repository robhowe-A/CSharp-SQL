using System;
namespace ConsoleStairs{
    class Stairs
    {
        public static void WriteStairs()
        {
            double row = 0;
            double j;
            while (row < 10)
            {
                j = Math.Pow(row, 2);
                for (int i=0; i <= j;i++){
                    Console.Write("{0}", '*');
                }
                    Console.WriteLine();
                row++;
            }
        }

        static void Main()
        {
            WriteStairs();
        }
    }
}
