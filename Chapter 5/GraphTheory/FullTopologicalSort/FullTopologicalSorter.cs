﻿namespace FullTopologicalSort
{
    using System;

    internal class FullTopologicalSorter
    {
        private const int VerticesCount = 8;

        private static readonly int[,] Graph = new int[VerticesCount, VerticesCount]
                                               {
                                                   { 0, 1, 0, 0, 0, 0, 0, 0 },
                                                   { 0, 0, 1, 0, 0, 0, 1, 0 },
                                                   { 0, 0, 0, 1, 0, 0, 0, 0 },
                                                   { 0, 0, 0, 0, 0, 0, 0, 0 },
                                                   { 0, 0, 0, 0, 0, 0, 0, 1 },
                                                   { 0, 0, 0, 0, 1, 0, 0, 0 },
                                                   { 0, 0, 1, 0, 0, 0, 0, 0 },
                                                   { 0, 0, 0, 0, 0, 0, 0, 0 }
                                               };

        private static readonly bool[] Used = new bool[VerticesCount];
        private static readonly int[] TopologicalSort = new int[VerticesCount];
        private static int totalSorts = 0;

        private static void FullTopologicalSort(int count)
        {
            int[] saved = new int[VerticesCount];
            if (count == VerticesCount)
            {
                PrintSort();
                return;
            }

            // Намира всички върхове без предшественик
            for (int i = 0; i < VerticesCount; i++)
            {
                if (!Used[i])
                {
                    int j = 0;
                    for (; j < VerticesCount; j++)
                    {
                        if (Graph[j, i] != 0)
                        {
                            break;
                        }
                    }

                    if (j == VerticesCount)
                    {
                        for (int k = 0; k < VerticesCount; k++)
                        {
                            saved[k] = Graph[i, k];
                            Graph[i, k] = 0;
                        }

                        Used[i] = true;
                        TopologicalSort[count] = i;
                        FullTopologicalSort(count + 1); // Рекурсия
                        Used[i] = false;
                        for (int k = 0; k < VerticesCount; k++)
                        {
                            Graph[i, k] = saved[k];
                        }
                    }
                }
            }
        }

        private static void PrintSort()
        {
            Console.Write("Топологично сортиране номер {0}: ", ++totalSorts);
            for (int i = 0; i < VerticesCount; i++)
            {
                Console.Write("{0} ", TopologicalSort[i] + 1);
            }

            Console.WriteLine();
        }

        private static void Main()
        {
            FullTopologicalSort(0);
        }
    }
}