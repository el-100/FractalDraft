using System;
using System.Collections.Generic;

namespace FractalDraft
{
    public class Letter
    {
        public List<Triangle> Triangles { get; }
        public double Width { get; }

        public Letter(double width, List<Triangle> triangles)
        {
            Triangles = triangles;
            Width = width;
        }

        public Letter(double width, List<List<double>> vertexes)
        {
            Triangles = new List<Triangle>();
            Width = width;

            foreach (var vertex in vertexes)
            {

                if (vertex.Count != 6)
                    throw new Exception("vertex.Count != 6");
                Triangles.Add(new Triangle(vertex[0], vertex[1], vertex[2], vertex[3], vertex[4], vertex[5]));
            }
        }
    }

    public class Triangle
    {
        public double Ax { get; }
        public double Ay { get; }
        public double Bx { get; }
        public double By { get; }
        public double Cx { get; }
        public double Cy { get; }

        public Triangle(double ax, double ay, double bx, double by, double cx, double cy)
        {
            Ax = ax;
            Ay = ay;
            Bx = bx;
            By = by;
            Cx = cx;
            Cy = cy;
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return Ax;
                    case 1:
                        return Ay;
                    case 2:
                        return Bx;
                    case 3:
                        return By;
                    case 4:
                        return Cx;
                    case 5:
                        return Cy;
                }

                throw new Exception("Vertex not found");
            }
        }
    }

    public static class Letters
    {
        public static Letter Get(char c)
        {
            return Dict.ContainsKey(c) ? Dict[c] : null;
        }

        private static Dictionary<char, Letter> Dict { get; } = new Dictionary<char, Letter>();

        static Letters()
        {
            Dict.Add(' ', new Letter(0.4, new List<Triangle>()));
            Dict.Add('!', new Letter(0.2, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.2, 0.0},
                    new List<double> {0.0, 0.4, 0.2, 0.4, 0.2, 1.0}}));
            Dict.Add('"', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.6, 0.2, 0.6, 0.2, 1.0},
                    new List<double> {0.4, 0.6, 0.6, 0.6, 0.6, 1.0}}));
            Dict.Add('#', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.2, 0.0, 0.4, 0.0, 0.4, 1.0},
                    new List<double> {0.6, 0.0, 0.8, 0.0, 0.8, 1.0},
                    new List<double> {0.0, 0.8, 0.0, 0.6, 1.0, 0.6},
                    new List<double> {0.0, 0.4, 0.0, 0.2, 1.0, 0.2}}));
            Dict.Add('$', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.1, 0.9, 0.1, 0.8, 0.6, 0.8},
                    new List<double> {0.1, 0.6, 0.1, 0.4, 0.5, 0.4},
                    new List<double> {0.0, 0.2, 0.0, 0.1, 0.5, 0.1},
                    new List<double> {0.0, 0.6, 0.2, 0.6, 0.2, 0.8},
                    new List<double> {0.4, 0.2, 0.6, 0.2, 0.6, 0.4},
                    new List<double> {0.2, 1.0, 0.2, 0.9, 0.4, 0.9},
                    new List<double> {0.2, 0.1, 0.2, 0.0, 0.4, 0.0}}));
            Dict.Add('%', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.2, 0.8},
                    new List<double> {0.6, 0.2, 0.6, 0.0, 0.8, 0.0},
                    new List<double> {0.2, 0.0, 0.0, 0.0, 0.6, 1.0}}));
            Dict.Add('\'', new Letter(0.4, new List<List<double>> {
                    new List<double> {0.2, 0.6, 0.0, 0.6, 0.2, 1.0}}));
            Dict.Add('(', new Letter(0.3, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 0.8},
                    new List<double> {0.1, 0.2, 0.1, 0.0, 0.3, 0.0},
                    new List<double> {0.1, 1.0, 0.1, 0.8, 0.3, 0.8}}));
            Dict.Add(')', new Letter(0.3, new List<List<double>> {
                    new List<double> {0.1, 0.2, 0.3, 0.2, 0.3, 0.8},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.2, 0.0},
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.2, 0.8}}));
            Dict.Add('*', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.0, 0.6, 0.0, 0.4, 1.0, 0.4},
                    new List<double> {0.4, 1.0, 0.2, 1.0, 0.7, 0.0},
                    new List<double> {0.6, 1.0, 0.8, 1.0, 0.4, 0.0}}));
            Dict.Add('+', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.0, 0.6, 0.0, 0.4, 1.0, 0.4},
                    new List<double> {0.4, 0.0, 0.6, 0.0, 0.6, 1.0}}));
            Dict.Add(',', new Letter(0.4, new List<List<double>> {
                    new List<double> {0.2, 0.0, 0.0, 0.0, 0.2, 0.4}}));
            Dict.Add('-', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.0, 0.6, 0.0, 0.4, 1.0, 0.4}}));
            Dict.Add('.', new Letter(0.2, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.2, 0.0}}));
            Dict.Add('/', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.4, 1.0, 0.6, 1.0, 0.2, 0.0}}));
            Dict.Add('0', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 0.8},
                    new List<double> {0.6, 0.2, 0.8, 0.2, 0.8, 0.8},
                    new List<double> {0.1, 0.2, 0.1, 0.0, 0.7, 0.0},
                    new List<double> {0.1, 1.0, 0.1, 0.8, 0.7, 0.8}}));
            Dict.Add('1', new Letter(0.4, new List<List<double>> {
                    new List<double> {0.2, 0.0, 0.4, 0.0, 0.4, 1.0},
                    new List<double> {0.0, 0.8, 0.0, 0.6, 0.2, 0.8}}));
            Dict.Add('2', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.5, 0.8},
                    new List<double> {0.4, 0.6, 0.6, 0.6, 0.6, 0.8},
                    new List<double> {0.2, 0.2, 0.0, 0.2, 0.4, 0.6},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.6, 0.0}}));
            Dict.Add('3', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.4, 0.8},
                    new List<double> {0.0, 0.6, 0.0, 0.4, 0.4, 0.4},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.4, 0.0},
                    new List<double> {0.4, 0.6, 0.6, 0.6, 0.6, 0.9},
                    new List<double> {0.4, 0.1, 0.6, 0.1, 0.6, 0.4}}));
            Dict.Add('4', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.4, 0.2, 0.4, 0.4, 1.0},
                    new List<double> {0.4, 0.0, 0.6, 0.0, 0.6, 1.0},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.4, 0.4}}));
            Dict.Add('5', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.6, 0.8},
                    new List<double> {0.0, 0.6, 0.0, 0.4, 0.5, 0.4},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.5, 0.0},
                    new List<double> {0.0, 0.6, 0.2, 0.6, 0.2, 0.8},
                    new List<double> {0.4, 0.2, 0.6, 0.2, 0.6, 0.4}}));
            Dict.Add('6', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.6, 0.0, 0.4, 0.5, 0.4},
                    new List<double> {0.1, 0.2, 0.1, 0.0, 0.5, 0.0},
                    new List<double> {0.0, 0.6, 0.2, 0.6, 0.6, 1.0},
                    new List<double> {0.4, 0.2, 0.6, 0.2, 0.6, 0.4},
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 0.4}}));
            Dict.Add('7', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.6, 0.8},
                    new List<double> {0.2, 0.0, 0.0, 0.0, 0.4, 0.8}}));
            Dict.Add('8', new Letter(0.5, new List<List<double>> {
                    new List<double> {0.1, 1.0, 0.1, 0.8, 0.5, 0.8},
                    new List<double> {0.1, 0.6, 0.1, 0.4, 0.5, 0.4},
                    new List<double> {0.1, 0.2, 0.1, 0.0, 0.5, 0.0},
                    new List<double> {0.4, 0.6, 0.6, 0.6, 0.6, 0.8},
                    new List<double> {0.4, 0.2, 0.6, 0.2, 0.6, 0.4},
                    new List<double> {0.0, 0.6, 0.2, 0.6, 0.2, 0.8},
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 0.4}}));
            Dict.Add('9', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.1, 1.0, 0.1, 0.8, 0.5, 0.8},
                    new List<double> {0.1, 0.6, 0.1, 0.4, 0.6, 0.4},
                    new List<double> {0.4, 0.6, 0.6, 0.6, 0.6, 0.8},
                    new List<double> {0.0, 0.6, 0.2, 0.6, 0.2, 0.8},
                    new List<double> {0.2, 0.0, 0.0, 0.0, 0.4, 0.4}}));
            Dict.Add(':', new Letter(0.2, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.2, 0.0},
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.2, 0.8}}));
            Dict.Add(';', new Letter(0.4, new List<List<double>> {
                    new List<double> {0.2, 0.4, 0.0, 0.0, 0.2, 0.0},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.4, 0.8}}));
            Dict.Add('<', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.2, 0.5, 0.0, 0.5, 0.4, 1.0},
                    new List<double> {0.2, 0.5, 0.0, 0.5, 0.4, 0.0}}));
            Dict.Add('=', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.0, 0.8, 0.0, 0.6, 1.0, 0.6},
                    new List<double> {0.0, 0.4, 0.0, 0.2, 1.0, 0.2}}));
            Dict.Add('>', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.4, 0.5, 0.6, 0.5, 0.2, 1.0},
                    new List<double> {0.4, 0.5, 0.6, 0.5, 0.2, 0.0}}));
            Dict.Add('?', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.1, 1.0, 0.1, 0.8, 0.5, 0.8},
                    new List<double> {0.0, 0.6, 0.2, 0.6, 0.2, 0.8},
                    new List<double> {0.4, 0.6, 0.6, 0.6, 0.6, 0.8},
                    new List<double> {0.2, 0.3, 0.4, 0.3, 0.6, 0.6},
                    new List<double> {0.2, 0.2, 0.2, 0.0, 0.4, 0.0}}));
            Dict.Add('@', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.4, 0.7, 0.4, 0.3, 1.0, 0.3},
                    new List<double> {0.8, 0.7, 1.0, 0.7, 1.0, 0.9},
                    new List<double> {0.1, 1.0, 0.1, 0.8, 0.8, 0.8},
                    new List<double> {0.0, 0.1, 0.2, 0.1, 0.2, 0.8},
                    new List<double> {0.2, 0.2, 0.2, 0.0, 0.9, 0.0}}));
            Dict.Add('A', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.5, 1.0},
                    new List<double> {0.5, 1.0, 0.3, 1.0, 0.6, 0.0},
                    new List<double> {0.2, 0.3, 0.2, 0.1, 0.6, 0.1}}));
            Dict.Add('B', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.4, 0.0, 0.6, 0.0, 0.6, 0.8},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.5, 0.8},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.4, 0.4},
                    new List<double> {0.2, 0.2, 0.2, 0.0, 0.4, 0.0}}));
            Dict.Add('C', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 0.8},
                    new List<double> {0.1, 0.2, 0.1, 0.0, 0.6, 0.0},
                    new List<double> {0.1, 1.0, 0.1, 0.8, 0.6, 0.8}}));
            Dict.Add('D', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.6, 0.2, 0.8, 0.2, 0.8, 0.8},
                    new List<double> {0.2, 0.2, 0.2, 0.0, 0.7, 0.0},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.7, 0.8}}));
            Dict.Add('E', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.6, 0.8},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.6, 0.4},
                    new List<double> {0.2, 0.2, 0.2, 0.0, 0.6, 0.0}}));
            Dict.Add('F', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.6, 0.8},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.6, 0.4}}));
            Dict.Add('G', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 0.8},
                    new List<double> {0.1, 0.2, 0.1, 0.0, 0.6, 0.0},
                    new List<double> {0.1, 1.0, 0.1, 0.8, 0.6, 0.8},
                    new List<double> {0.4, 0.2, 0.6, 0.2, 0.6, 0.4}}));
            Dict.Add('H', new Letter(0.7, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.5, 0.0, 0.7, 0.0, 0.7, 1.0},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.5, 0.4}}));
            Dict.Add('I', new Letter(0.2, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0}}));
            Dict.Add('J', new Letter(0.4, new List<List<double>> {
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.4, 0.8},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.3, 0.0},
                    new List<double> {0.2, 0.2, 0.4, 0.2, 0.4, 0.8}}));
            Dict.Add('K', new Letter(0.7, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.2, 0.5, 0.4, 0.5, 0.7, 1.0},
                    new List<double> {0.5, 0.0, 0.7, 0.0, 0.4, 0.5}}));
            Dict.Add('L', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.2, 0.2, 0.2, 0.0, 0.6, 0.0}}));
            Dict.Add('M', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.2, 0.0, 0.0, 0.0, 0.2, 1.0},
                    new List<double> {0.4, 1.0, 0.2, 1.0, 0.4, 0.0},
                    new List<double> {0.6, 0.0, 0.4, 0.0, 0.6, 1.0},
                    new List<double> {0.8, 1.0, 0.6, 1.0, 0.8, 0.0}}));
            Dict.Add('N', new Letter(0.7, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.5, 0.0, 0.7, 0.0, 0.7, 1.0},
                    new List<double> {0.2, 0.6, 0.2, 0.9, 0.5, 0.4}}));
            Dict.Add('O', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 0.8},
                    new List<double> {0.6, 0.2, 0.8, 0.2, 0.8, 0.8},
                    new List<double> {0.1, 0.2, 0.1, 0.0, 0.7, 0.0},
                    new List<double> {0.1, 1.0, 0.1, 0.8, 0.7, 0.8}}));
            Dict.Add('P', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.6, 0.8},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.6, 0.4},
                    new List<double> {0.4, 0.8, 0.4, 0.6, 0.6, 0.6}}));
            Dict.Add('Q', new Letter(0.9, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 0.8},
                    new List<double> {0.6, 0.2, 0.8, 0.2, 0.8, 0.8},
                    new List<double> {0.1, 0.2, 0.1, 0.0, 0.7, 0.0},
                    new List<double> {0.1, 1.0, 0.1, 0.8, 0.7, 0.8},
                    new List<double> {0.5, 0.2, 0.5, 0.4, 0.9, 0.2}}));
            Dict.Add('R', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.6, 0.8},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.6, 0.4},
                    new List<double> {0.4, 0.8, 0.4, 0.6, 0.6, 0.6},
                    new List<double> {0.4, 0.4, 0.2, 0.4, 0.4, 0.0}}));
            Dict.Add('S', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.1, 1.0, 0.1, 0.8, 0.6, 0.8},
                    new List<double> {0.1, 0.6, 0.1, 0.4, 0.5, 0.4},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.5, 0.0},
                    new List<double> {0.0, 0.6, 0.2, 0.6, 0.2, 0.8},
                    new List<double> {0.4, 0.2, 0.6, 0.2, 0.6, 0.4}}));
            Dict.Add('T', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.8, 0.8},
                    new List<double> {0.3, 0.0, 0.5, 0.0, 0.5, 0.8}}));
            Dict.Add('U', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 1.0},
                    new List<double> {0.6, 0.2, 0.8, 0.2, 0.8, 1.0},
                    new List<double> {0.1, 0.2, 0.1, 0.0, 0.7, 0.0}}));
            Dict.Add('V', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.2, 1.0, 0.0, 1.0, 0.3, 0.0},
                    new List<double> {0.3, 0.0, 0.5, 0.0, 0.8, 1.0}}));
            Dict.Add('W', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.2, 1.0, 0.0, 1.0, 0.2, 0.0},
                    new List<double> {0.2, 0.0, 0.4, 0.0, 0.6, 1.0},
                    new List<double> {0.6, 1.0, 0.4, 1.0, 0.6, 0.0},
                    new List<double> {0.8, 0.0, 0.6, 0.0, 0.8, 1.0}}));
            Dict.Add('X', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.2, 0.0, 0.0, 0.0, 0.6, 1.0},
                    new List<double> {0.6, 0.0, 0.8, 0.0, 0.2, 1.0}}));
            Dict.Add('Y', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.2, 1.0, 0.0, 1.0, 0.3, 0.4},
                    new List<double> {0.5, 0.4, 0.3, 0.4, 0.6, 1.0},
                    new List<double> {0.5, 0.0, 0.3, 0.0, 0.3, 0.4}}));
            Dict.Add('Z', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.8, 0.8},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.8, 0.0},
                    new List<double> {0.2, 0.2, 0.0, 0.2, 0.6, 0.8}}));
            Dict.Add('[', new Letter(0.3, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 0.8},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.3, 0.0},
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.3, 0.8}}));
            Dict.Add('\\', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.2, 1.0, 0.0, 1.0, 0.4, 0.0}}));
            Dict.Add(']', new Letter(0.3, new List<List<double>> {
                    new List<double> {0.1, 0.2, 0.3, 0.2, 0.3, 0.8},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.3, 0.0},
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.3, 0.8}}));
            Dict.Add('^', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.8, 0.0, 0.6, 0.3, 0.8},
                    new List<double> {0.3, 1.0, 0.3, 0.8, 0.6, 0.6}}));
            Dict.Add('_', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.0, 0.0, 1.0, 0.0}}));
            Dict.Add('`', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.2, 1.0, 0.0, 1.0, 0.2, 0.8}}));
            Dict.Add('{', new Letter(0.4, new List<List<double>> {
                    new List<double> {0.1, 0.2, 0.3, 0.2, 0.3, 0.8},
                    new List<double> {0.2, 0.2, 0.2, 0.0, 0.4, 0.0},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.4, 0.8},
                    new List<double> {0.0, 0.4, 0.1, 0.4, 0.1, 0.6}}));
            Dict.Add('|', new Letter(0.2, new List<List<double>> {
                    new List<double> {0.2, 0.0, 0.0, 0.0, 0.0, 1.0}}));
            Dict.Add('}', new Letter(0.4, new List<List<double>> {
                    new List<double> {0.1, 0.2, 0.3, 0.2, 0.3, 0.8},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.2, 0.0},
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.2, 0.8},
                    new List<double> {0.3, 0.4, 0.4, 0.4, 0.4, 0.6}}));
            Dict.Add('~', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.0, 0.8, 0.0, 0.6, 0.3, 0.8},
                    new List<double> {0.3, 1.0, 0.3, 0.8, 0.7, 0.6},
                    new List<double> {0.7, 0.8, 0.7, 0.6, 1.0, 0.8}}));
            Dict.Add('А', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.5, 1.0},
                    new List<double> {0.5, 1.0, 0.3, 1.0, 0.6, 0.0},
                    new List<double> {0.2, 0.3, 0.2, 0.1, 0.6, 0.1}}));
            Dict.Add('Б', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.4, 0.0, 0.6, 0.0, 0.6, 0.6},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.6, 0.8},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.4, 0.4},
                    new List<double> {0.2, 0.2, 0.2, 0.0, 0.4, 0.0}}));
            Dict.Add('В', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.4, 0.0, 0.6, 0.0, 0.6, 0.8},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.5, 0.8},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.4, 0.4},
                    new List<double> {0.2, 0.2, 0.2, 0.0, 0.4, 0.0}}));
            Dict.Add('Г', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.6, 0.8}}));
            Dict.Add('Д', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.5, 0.8},
                    new List<double> {0.1, 0.2, 0.3, 0.2, 0.3, 0.8},
                    new List<double> {0.5, 0.2, 0.7, 0.2, 0.7, 1.0},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.8, 0.0}}));
            Dict.Add('Е', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.6, 0.8},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.6, 0.4},
                    new List<double> {0.2, 0.2, 0.2, 0.0, 0.6, 0.0}}));
            Dict.Add('Ж', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.2, 1.0, 0.0, 1.0, 0.2, 0.5},
                    new List<double> {0.2, 0.0, 0.0, 0.0, 0.2, 0.5},
                    new List<double> {0.4, 0.0, 0.6, 0.0, 0.6, 1.0},
                    new List<double> {0.8, 0.0, 1.0, 0.0, 0.8, 0.5},
                    new List<double> {0.8, 1.0, 1.0, 1.0, 0.8, 0.5}}));
            Dict.Add('З', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.4, 0.8},
                    new List<double> {0.0, 0.6, 0.0, 0.4, 0.4, 0.4},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.4, 0.0},
                    new List<double> {0.4, 0.6, 0.6, 0.6, 0.6, 0.9},
                    new List<double> {0.4, 0.1, 0.6, 0.1, 0.6, 0.4}}));
            Dict.Add('И', new Letter(0.7, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.5, 0.0, 0.7, 0.0, 0.7, 1.0},
                    new List<double> {0.2, 0.4, 0.2, 0.1, 0.5, 0.6}}));
            Dict.Add('Й', new Letter(0.7, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 0.8},
                    new List<double> {0.5, 0.0, 0.7, 0.0, 0.7, 0.8},
                    new List<double> {0.2, 0.4, 0.2, 0.1, 0.5, 0.4},
                    new List<double> {0.1, 1.0, 0.1, 0.9, 0.6, 0.9}}));
            Dict.Add('К', new Letter(0.7, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.2, 0.5, 0.4, 0.5, 0.7, 1.0},
                    new List<double> {0.5, 0.0, 0.7, 0.0, 0.4, 0.5}}));
            Dict.Add('Л', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 0.8},
                    new List<double> {0.4, 0.0, 0.6, 0.0, 0.6, 1.0},
                    new List<double> {0.1, 1.0, 0.1, 0.8, 0.4, 0.8}}));
            Dict.Add('М', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.2, 0.0, 0.0, 0.0, 0.2, 1.0},
                    new List<double> {0.4, 1.0, 0.2, 1.0, 0.4, 0.0},
                    new List<double> {0.6, 0.0, 0.4, 0.0, 0.6, 1.0},
                    new List<double> {0.8, 1.0, 0.6, 1.0, 0.8, 0.0}}));
            Dict.Add('Н', new Letter(0.7, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.5, 0.0, 0.7, 0.0, 0.7, 1.0},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.5, 0.4}}));
            Dict.Add('О', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 0.8},
                    new List<double> {0.6, 0.2, 0.8, 0.2, 0.8, 0.8},
                    new List<double> {0.1, 0.2, 0.1, 0.0, 0.7, 0.0},
                    new List<double> {0.1, 1.0, 0.1, 0.8, 0.7, 0.8}}));
            Dict.Add('П', new Letter(0.7, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.5, 0.0, 0.7, 0.0, 0.7, 1.0},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.5, 0.8}}));
            Dict.Add('Р', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.6, 0.8},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.6, 0.4},
                    new List<double> {0.4, 0.8, 0.4, 0.6, 0.6, 0.6}}));
            Dict.Add('С', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 0.8},
                    new List<double> {0.1, 0.2, 0.1, 0.0, 0.6, 0.0},
                    new List<double> {0.1, 1.0, 0.1, 0.8, 0.6, 0.8}}));
            Dict.Add('Т', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.8, 0.8},
                    new List<double> {0.3, 0.0, 0.5, 0.0, 0.5, 0.8}}));
            Dict.Add('У', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.4, 0.2, 0.4, 0.2, 1.0},
                    new List<double> {0.4, 0.0, 0.6, 0.0, 0.6, 1.0},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.4, 0.4},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.4, 0.0}}));
            Dict.Add('Ф', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.0, 0.4, 0.2, 0.4, 0.2, 1.0},
                    new List<double> {0.4, 0.0, 0.6, 0.0, 0.6, 1.0},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.4, 0.4},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.4, 0.8},
                    new List<double> {0.6, 0.6, 0.6, 0.4, 0.8, 0.4},
                    new List<double> {0.6, 1.0, 0.6, 0.8, 0.8, 0.8},
                    new List<double> {0.8, 0.4, 1.0, 0.4, 1.0, 1.0}}));
            Dict.Add('Х', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.2, 0.0, 0.0, 0.0, 0.6, 1.0},
                    new List<double> {0.6, 0.0, 0.8, 0.0, 0.2, 1.0}}));
            Dict.Add('Ц', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 1.0},
                    new List<double> {0.5, 0.2, 0.7, 0.2, 0.7, 1.0},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.8, 0.0}}));
            Dict.Add('Ч', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.4, 0.2, 0.4, 0.2, 1.0},
                    new List<double> {0.4, 0.0, 0.6, 0.0, 0.6, 1.0},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.4, 0.4}}));
            Dict.Add('Ш', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 1.0},
                    new List<double> {0.4, 0.2, 0.6, 0.2, 0.6, 1.0},
                    new List<double> {0.8, 0.2, 1.0, 0.2, 1.0, 1.0},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 1.0, 0.0}}));
            Dict.Add('Щ', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.0, 0.2, 0.2, 0.2, 0.2, 1.0},
                    new List<double> {0.3, 0.2, 0.5, 0.2, 0.5, 1.0},
                    new List<double> {0.6, 0.2, 0.8, 0.2, 0.8, 1.0},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 1.0, 0.0}}));
            Dict.Add('Ъ', new Letter(0.8, new List<List<double>> {
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.2, 0.8},
                    new List<double> {0.2, 0.0, 0.4, 0.0, 0.4, 1.0},
                    new List<double> {0.4, 0.6, 0.4, 0.4, 0.8, 0.4},
                    new List<double> {0.4, 0.2, 0.4, 0.0, 0.8, 0.0},
                    new List<double> {0.6, 0.2, 0.8, 0.2, 0.8, 0.4}}));
            Dict.Add('Ы', new Letter(0.9, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.6, 0.4},
                    new List<double> {0.2, 0.2, 0.2, 0.0, 0.6, 0.0},
                    new List<double> {0.4, 0.2, 0.6, 0.2, 0.6, 0.4},
                    new List<double> {0.7, 0.0, 0.9, 0.0, 0.9, 1.0}}));
            Dict.Add('Ь', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.6, 0.4},
                    new List<double> {0.2, 0.2, 0.2, 0.0, 0.6, 0.0},
                    new List<double> {0.4, 0.2, 0.6, 0.2, 0.6, 0.4}}));
            Dict.Add('Э', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 1.0, 0.0, 0.8, 0.4, 0.8},
                    new List<double> {0.0, 0.6, 0.0, 0.4, 0.4, 0.4},
                    new List<double> {0.0, 0.2, 0.0, 0.0, 0.4, 0.0},
                    new List<double> {0.4, 0.1, 0.6, 0.1, 0.6, 0.9}}));
            Dict.Add('Ю', new Letter(1.0, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 1.0},
                    new List<double> {0.4, 0.0, 0.6, 0.0, 0.6, 1.0},
                    new List<double> {0.8, 0.0, 1.0, 0.0, 1.0, 1.0},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.4, 0.4},
                    new List<double> {0.6, 1.0, 0.6, 0.8, 0.8, 0.8},
                    new List<double> {0.6, 0.2, 0.6, 0.0, 0.8, 0.0}}));
            Dict.Add('Я', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.4, 0.2, 0.4, 0.2, 1.0},
                    new List<double> {0.4, 0.0, 0.6, 0.0, 0.6, 1.0},
                    new List<double> {0.2, 0.6, 0.2, 0.4, 0.4, 0.4},
                    new List<double> {0.2, 0.0, 0.0, 0.0, 0.2, 0.4},
                    new List<double> {0.2, 1.0, 0.2, 0.8, 0.4, 0.8}}));
            Dict.Add('Ё', new Letter(0.6, new List<List<double>> {
                    new List<double> {0.0, 0.0, 0.2, 0.0, 0.2, 0.8},
                    new List<double> {0.2, 0.8, 0.2, 0.6, 0.6, 0.6},
                    new List<double> {0.2, 0.5, 0.2, 0.3, 0.6, 0.3},
                    new List<double> {0.2, 0.2, 0.2, 0.0, 0.6, 0.0},
                    new List<double> {0.0, 1.0, 0.0, 0.9, 0.2, 0.9},
                    new List<double> {0.4, 1.0, 0.4, 0.9, 0.6, 0.9}}));
        }

    }
}