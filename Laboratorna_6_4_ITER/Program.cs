using System;

namespace Laboratorna_6_4_ITER
{
    public class Program
    {
        static void FillArray(int[] arr, int n)
        {
            Console.WriteLine($"Enter {n} elements for the array:");
            for (int i = 0; i < n; ++i)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
        }

        static void PrintArray(int[] arr, int n)
        {
            Console.Write("Array: ");
            for (int i = 0; i < n; ++i)
            {
                Console.Write($"{arr[i]} ");
            }
            Console.WriteLine();
        }

        public static int FindMaxIndex(int[] arr, int n)
        {
            int maxIndex = 0;

            for (int i = 1; i < n; ++i)
            {
                if (arr[i] > arr[maxIndex])
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public static int CalculateProductBetweenZeros(int[] arr, int n)
        {
            int firstZeroIndex = -1;
            int secondZeroIndex = -1;

            for (int i = 0; i < n; ++i)
            {
                if (arr[i] == 0)
                {
                    if (firstZeroIndex == -1)
                    {
                        firstZeroIndex = i;
                    }
                    else
                    {
                        secondZeroIndex = i;
                        break;
                    }
                }
            }

            if (firstZeroIndex == -1 || secondZeroIndex == -1)
            {
                return -1;
            }

            int product = 1;
            for (int i = firstZeroIndex + 1; i < secondZeroIndex; ++i)
            {
                product *= arr[i];
            }

            return product;
        }

        public static void TransformArray(int[] arr, int n)
        {
            int[] tempArray = new int[n];
            int tempIndex = 0;

            for (int i = 1; i < n; i += 2)
            {
                tempArray[tempIndex++] = arr[i];
            }

            for (int i = 0; i < n; i += 2)
            {
                tempArray[tempIndex++] = arr[i];
            }

            Array.Copy(tempArray, arr, n);
        }

        static void Main()
        {
            Console.Write("Enter the size of the array: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.Error.WriteLine("Invalid array size");
                return;
            }

            int[] arr = new int[n];

            FillArray(arr, n);
            PrintArray(arr, n);

            int maxIndex = FindMaxIndex(arr, n);
            Console.WriteLine($"Index of the maximum element: {maxIndex}");

            int productBetweenZeros = CalculateProductBetweenZeros(arr, n);
            if (productBetweenZeros == -1)
            {
                Console.WriteLine("Error: Two zeros are not found in the array.");
            }
            else
            {
                Console.WriteLine($"Product between elements with two zeros: {productBetweenZeros}");
            }

            TransformArray(arr, n);
            Console.WriteLine("Transformed Array:");
            PrintArray(arr, n);
        }
    }
}