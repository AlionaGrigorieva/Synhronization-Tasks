using System;
using System.Threading.Tasks;

namespace _0_0_The_Matrix
{
    class Program
    {
        private static double[,] enterFunc (int r, int c)
        {
            double[,] m = new double[r, c];
            Random random = new Random();
            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    m[i, j] = random.Next(100);
                }
            }
            return m;
        }
        private static void writeFunc(double[,] m, int r, int c)
        {
            Parallel.For(0, r, i =>
            {
                for (int j = 0; j < c; j++)
                {
                    Console.Write("{0:#.##}  ", m[i,j]);
                }
                Console.Write("\n");
            });
        }
        static double[,] withGodblessing(double[,] m1, double[,] m2)
        {
            double[,] result = new double[m1.GetLength(0), m2.GetLength(1)];
            Parallel.For(0, m1.GetLength(0), i =>
            {
                for (int j = 0; j < m2.GetLength(1); ++j)
                    for (int k = 0; k < m1.GetLength(1); ++k)
                        result[i,j] += m1[i,k] * m2[k,j];
            }
            );
            return result;
        }
        static void Main(string[] args)
        {
            int с1r2, c2, r1;
            Console.WriteLine("Введите, пожалуйста, колличество столбцов первого массива и строчек второго (одно число): ");
            с1r2 = Convert.ToInt32((Console.ReadLine()));
            Console.WriteLine("Введите, пожалуйста, колличество строчек первого массива: ");
            r1 = Convert.ToInt32((Console.ReadLine()));
            Console.WriteLine("Введите, пожалуйста, колличество столбцов второго массива: ");
            c2 = Convert.ToInt32((Console.ReadLine()));
            double[,] m1 = enterFunc(r1, с1r2);
            double[,] m2 = enterFunc(с1r2, c2);
            Console.WriteLine("\nПервый массив: ");
            writeFunc(m1, r1, с1r2);
            Console.WriteLine("\nВторой массив: ");
            writeFunc(m2, с1r2, c2);
            Console.WriteLine("\nРезультат: ");
            writeFunc(withGodblessing(m1, m2), r1, c2);
        }
    }
}
