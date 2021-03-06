﻿namespace GraphComponents
{
    using System;

    public class GraphComponents
    {
        private const int VerticesCount = 6;

        private static readonly byte[,] Graph = new byte[VerticesCount, VerticesCount]
        {
            { 0, 1, 1, 0, 0, 0 },
            { 1, 0, 1, 0, 0, 0 },
            { 1, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 1 },
            { 0, 0, 0, 1, 0, 1 },
            { 0, 0, 0, 1, 1, 0 }
        };

        private static readonly bool[] Used = new bool[VerticesCount];

        internal static void Main()
        {
            Console.WriteLine("Ето всички компоненти на свързаност:");
            int components = 0;
            for (int i = 0; i < VerticesCount; i++)
            {
                if (!Used[i])
                {
                    components++;
                    Console.Write("{ ");
                    FindGraphComponents(i);
                    Console.WriteLine("}");
                }
            }

            if (components == 1)
            {
                Console.WriteLine("Графът е свързан!");
            }
            else
            {
                Console.WriteLine("Брой на свързаните компоненти в графа: {0}", components);
            }
        }

        private static void FindGraphComponents(int vertex)
        {
            Used[vertex] = true;
            Console.Write("{0} ", vertex + 1);
            for (int i = 0; i < VerticesCount; i++)
            {
                if (Graph[vertex, i] == 1 && !Used[i])
                {
                    FindGraphComponents(i);
                }
            }
        }
    }
}