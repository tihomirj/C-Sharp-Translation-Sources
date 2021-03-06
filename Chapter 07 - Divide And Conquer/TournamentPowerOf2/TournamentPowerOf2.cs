﻿namespace Tournament1
{
    using System;

    public class Program
    {
        private const int MaxMatrixSize = 100;

        internal static void Main()
        {
            int numberOfPlayers = 8;
            int[,] matrix = new int[MaxMatrixSize, MaxMatrixSize];
            FindSolution(matrix, numberOfPlayers);
            Print(matrix, numberOfPlayers);
        }

        private static void CopyMatrix(int[,] matrix, int stX, int stY, int cnt, int add)
        {
            for (int i = 0; i < cnt; i++)
            {
                for (int j = 0; j < cnt; j++)
                {
                    matrix[i + stX, j + stY] = matrix[i + 1, j + 1] + add;
                }
            }
        }

        /* Построява таблицата */
        private static void FindSolution(int[,] matrix, int n)
        {
            matrix[1, 1] = 0;
            for (int i = 1; i <= n; i <<= 1)
            {
                CopyMatrix(matrix, i + 1, 1, i, i);
                CopyMatrix(matrix, i + 1, i + 1, i, 0);
                CopyMatrix(matrix, 1, i + 1, i, i);
            }
        }

        /* Извежда резултата */
        private static void Print(int[,] matrix, int n)
        {
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    Console.Write("{0} ", matrix[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}