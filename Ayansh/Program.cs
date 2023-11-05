using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;

namespace Ayansh
{
    class CommandLineExample
    {
        static void Main()
        {
            double[][] factors = new double[8][];
            factors[0] = new double[] { 60, 22, 8, 22 };
            factors[1] = new double[] { 62, 25, 5, 32 };
            factors[2] = new double[] { 67, 24, 8, 45 };
            factors[3] = new double[] { 70, 20, 8, 44 };
            factors[4] = new double[] { 71, 15, 8, 34 };
            factors[5] = new double[] { 72, 14, 8, 42 };
            factors[6] = new double[] { 75, 14, 8, 84 };
            factors[7] = new double[] { 78, 11, 8, 23 };
            double[] predictor = new double[] { 140, 155, 159, 179, 192, 200, 212, 215 };

            var fact = Fit.MultiDim(factors, predictor, intercept: true);
            double[] coefficient = new double[fact.Length];
            int i = 0;
            foreach (double n in fact)
            {
                coefficient[i] = n;
                i++;
            }
            //var gof = GoodnessOfFit.RSquared(predictor, predicted);

            Console.ReadLine();
        }

        private static void MaxMinIntValFromAnArray()
        {
            int[] arr = { 1, 9, 2, 3, 12, 4 };
            int maxInt = 0;
            int minInt = arr[2];
            Console.WriteLine(minInt);
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > maxInt)
                {
                    maxInt = arr[i];
                }
                if (arr[i] < minInt)
                {
                    minInt = arr[i];
                }
            }
            Console.WriteLine($"Max int and min int are:  {maxInt} and {minInt}");
        }

        private static void PlusMinusRatio()
        {
            Console.WriteLine("Enter the length of list");
            int numberOfRow = Convert.ToInt32(Console.ReadLine());
            List<int> a = new List<int>();

            a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrArr => Convert.ToInt32(arrArr)).ToList();
            decimal plusCount = 0, minusCount = 0, zeroCount = 0;

            for(int i =0; i<numberOfRow; i++)
            {
                if (a[i] > 0)
                    plusCount += 1;
                if (a[i] < 0)
                    minusCount += 1;
                if (a[i] == 0)
                    zeroCount += 1;
            }
            Console.WriteLine("ratios are :" + decimal.Round(plusCount / numberOfRow, 5));
            Console.WriteLine("ratios are :" + decimal.Round(minusCount / numberOfRow, 5));
            Console.WriteLine("ratios are :" + decimal.Round(zeroCount / numberOfRow, 5));
        }

        private static int LonelyInt()
        {
            Console.WriteLine("Enter the number of row");
            int numberOfRow = Convert.ToInt32(Console.ReadLine());
            List<int> a = new List<int>();
            
            a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrArr => Convert.ToInt32(arrArr)).ToList();

            int len = a.Count;
            int uniq = 0;

            for (int i = 0; i < len; i++)
                uniq ^= a[i];

            return uniq;
        }

        private static int DimansionDifference()
        {
            Console.WriteLine("Enter the number of row");
            int numberOfRow = Convert.ToInt32(Console.ReadLine());

            List<List<int>> arr = new List<List<int>>();
            for(int i = 0; i< numberOfRow; i++)
            {
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrArr => Convert.ToInt32(arrArr)).ToList());
            }

            int result = 0;
            int rowCount = arr.Count;
            int leftSum = 0, rightSum = 0;
            int colCount = arr[0].Count;

            for (int i = 0; i <= rowCount - 1 ; i++)
            {
                leftSum += arr[i][i];
                rightSum += arr[colCount -i - 1][i];
            }
            return result= Math.Abs(leftSum - rightSum);
        }
    }

}