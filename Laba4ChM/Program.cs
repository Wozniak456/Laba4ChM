using System;
using ClassLibrary4ChM;
namespace Laba4ChM
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] matrixA = { { 7.03, 1.14, 0.93, 1.135 }, { 1.14, 3.39, 1.3, 0.16 }, 
                { 0.93, 1.3, 6.21, 2.1 }, { 1.135, 0.16, 2.1, 5.33 } };
            int m = matrixA.GetLength(0); ;
            Console.WriteLine("\t\tПочаткова матриця");
            Class1.PrintMatrix(matrixA);
            for (int i = 0; i < m - 1; i++)
            {
                double[,] M1 = { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
                double[,] M2 = { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
                for (int j = 0; j < m; j++) //заповнення матриці М[і]
                {
                    if (j != 2 - i)
                    {
                        M1[2 - i,j] = -(matrixA[2 - i + 1,j]) / matrixA[2 - i + 1,2 - i];
                    }
                    else
                    {
                        M1[2 - i,j] = 1 / matrixA[2 - i + 1,2 - i];
                    }
                    M2[2 - i,j] = matrixA[3 - i,j];//Заповнення матриці М^(-1)
                }
                Console.WriteLine($"Curr num: {matrixA[2 - i + 1, 2 - i]:f2}");
                Console.WriteLine($"\t\tМатриця М1 на iтерацii № {i + 1}");
                Class1.PrintMatrix(M1);
                Console.WriteLine($"\t\tМатриця М2 на iтерацii № {i+1}");
                Class1.PrintMatrix(M2);

                double[,] D1 = new double[m, m]; //D1 = множення матриць M^(-1) i matrixA
                Class1.MatrixMultiplication(M2, matrixA, ref D1);

                double[,] D2 = new double[m, m]; //D2 = множення матриць D1 i M[i]
                Class1.MatrixMultiplication(D1, M1, ref D2);

                for (int q = 0; q < m; q++) //Запис матриці D2 в матрицю matrixA
                {
                    for (int j = 0; j < m; j++)
                    {
                        matrixA[q,j] = D2[q,j];
                    }
                }
                Console.WriteLine($"\t\tМатриця Р пiсля iтерацii № {i+1}");
                Class1.PrintMatrix(matrixA);
            }
            Console.Write($"Характеристичне рiвняння: x^4-");
            Class1.Equation(matrixA);
            Console.ReadKey();
        }
    }
}
