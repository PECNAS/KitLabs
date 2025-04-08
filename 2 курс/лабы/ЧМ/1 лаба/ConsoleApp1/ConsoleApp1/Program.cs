using System.ComponentModel.DataAnnotations;

namespace HelloWorld
{
    class Program
    {
        static void PrintVector(double[] vector)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                Console.WriteLine(vector[i]);
            }
        }

        static double CalculateError(double[] x, double[] prevX)
        {
            double max = 0;
            for (int i = 0; i < 3; i++)
            {
                if (max == 0)
                {
                    max = Math.Abs(prevX[i] - x[i]);
                } else if (max < Math.Abs(prevX[i] - x[i]))
                {
                    max = Math.Abs(prevX[i] - x[i]);
                }
            }

            return max;
        }
        static void SolveSeidel(double[,] coefficients, double[] constants, int maxIterations, double tolerance)
        {
            int n = constants.Length;
            double[] x = new double[n];
            double[] prevX = new double[n];

            int iteration = 0;
            double error = 0;

            do
            {
                Array.Copy(x, prevX, n);
                for (int i = 0; i < n; i++)
                {
                    double sigma = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (j != 1)
                        {
                            sigma += coefficients[i, j] * x[j];
                        }
                    }
                    x[i] = (constants[i] - sigma) / coefficients[i, i];
                }
                iteration++;

                error = CalculateError(x, prevX);

                Console.Write("Iteration {0}: ", iteration);
                PrintVector(x);
                Console.WriteLine("Error {0}", error);
            } while (iteration < maxIterations && error > tolerance);
        }

        static void Main(string[] args)
        {
            double[,] coefficients =
{
                {5, -1, 3 },
                {1, -4, 2 },
                {2, -1, 5 }
            };
            double[] constants = { 5, 20, 10 };

            int maxIterations = 100;
            double tolerance = 1e-6;

            SolveSeidel(coefficients, constants, maxIterations, tolerance);

            Console.ReadLine();
        }
    }

}

