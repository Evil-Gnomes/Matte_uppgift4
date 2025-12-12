namespace Mate_uppgift4
{
    using System.Diagnostics;
    using System.Drawing;
    using System.Numerics;
    using System.Runtime.CompilerServices;

        internal class Program
        {
            public static double DegToRad(int degree)
            {
                return degree * Math.PI / 180;
            }

            private static double[,] rectangleCorners = { { 1, 1, -1, -1 }, { 1, -1, 1, -1 } };
            private static double rotation;

            public static double[,] CalculateRotation(double[,] array, int degree)
            {
                rotation = DegToRad(degree);
                //MonoGames  angle is clockwise, hence the negative values in the rotation matrix
                double[,] rotMatrix = { { -Math.Cos(rotation), Math.Sin(rotation) }, { -Math.Sin(rotation), -Math.Cos(rotation) } };
                double[,] newMatrix = new double[2, 4];

                //Utför multiplikation av 2 matriser
                for (int i = 0; i < 2; i++)
                {
                    Debug.WriteLine(i + "i");
                    for (int j = 0; j < 4; j++)
                    {
                        Debug.WriteLine(j + "j");
                        for (int z = 0; z < 2; z++)
                        {

                            Debug.WriteLine(z + "z");
                            newMatrix[i, j] += rotMatrix[i, z] * array[z, j];

                        }
                    }
                }

                return newMatrix;

            }

            public static string WriteArray(double[,] array)
            {
                string line = "";
                int row = 0;
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    Debug.WriteLine(i);
                    for (int z = 0; z < array.GetLength(0); z++)
                    {
                        Debug.WriteLine(z);
                        line += "{" + array[z, i] + "}";
                    }
                    line += "\n";
                }
                return line;
            }

            public static void Main(string[] args)
            {

                Console.WriteLine("Rectangle Corners: \n" + WriteArray(rectangleCorners));
                Console.WriteLine("");
                Console.WriteLine("After rotating rectangle by 30 degrees: \n" + WriteArray(CalculateRotation(rectangleCorners, 30)));




                Console.WriteLine();
            }


        }
    }