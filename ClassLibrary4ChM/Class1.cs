using System;

namespace ClassLibrary4ChM
{
    public class Class1
    {
        public static void PrintMatrix(double[,] matrix)
        {
            int m = matrix.GetLength(0);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{matrix[i,j]:f2}\t\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void Equation(double[,] matrixA)
        {
            int m = matrixA.GetLength(0);
            int koef = 3;
            for (int i = 0; i < m; i++)
            {
                if (i != m - 1)
                {
                    Console.Write($"({matrixA[0, i]:f5})*x^{koef}-");
                }
                else
                {
                    Console.Write($"({matrixA[0, 3]:f5});");
                }
                koef--;
            }
        }
        public static void MatrixMultiplication(double[,] matrix1, double[,] matrix2, ref double[,] matrix3)
        {
            int m = matrix1.GetLength(0);
            for (int q = 0; q < m; q++) 
            {
                for (int j = 0; j < m; j++)
                {
                    for (int l = 0; l < m; l++)
                    {
                        matrix3[q, j] += matrix1[q, l] * matrix2[l, j];
                    }
                }
            }
        }
    }
}
