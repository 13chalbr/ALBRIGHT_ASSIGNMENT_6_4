using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ALBRIGHT_ASSIGNMENT_6_4
{
    internal class Program
    {
        // MSSA CCAD16 - 10DEC2024
        // CHRIS ALBRIGHT
        // ASSIGNMENT 6.3
        static void Main(string[] args)
        {
            // Assignment 6.4 ---------------------------------------------------------------------------------------------

            // You are given an n x n 2D matrix representing an image, rotate the image by 90 degrees (clockwise). You have
            // to rotate the image in-place, which means you have to modify the input 2D matrix directly. DO NOT allocate another 2D matrix and do the rotation.

            Console.WriteLine("Assignment 6.4 ---------------------------------------------------------------------");
            Console.WriteLine("CLOCKWISE 2D ARRAY ROTATOR:");
            char hold1 = 'y';
            do
            {
                Console.WriteLine("\n\nStart with a stock or custom array? type 'stock'/'custom':");
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "stock":
                        int[,] array = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
                        Console.WriteLine("\nYour original array:\n");
                        DisplayArray(array);
                        Console.WriteLine("\nYour 90deg CW rotated array with transpose and y axis reflect:\n");
                        DisplayArray(NinetyDegCWMatrixRotate(array));
                        Console.WriteLine("\nRotated another 90deg with concentric rings:\n");
                        DisplayArray(RotateConcentricRings(array));
                        break;
                    case "custom":
                        int[,] arrayCustom = CustomArray();
                        Console.WriteLine("\nYour original custom array:\n");
                        DisplayArray(arrayCustom);
                        Console.WriteLine("\nYour 90deg CW rotated array with transpose and y axis reflect:\n");
                        DisplayArray(NinetyDegCWMatrixRotate(arrayCustom));
                        Console.WriteLine("\nRotated another 90deg with concentric rings:\n");
                        DisplayArray(RotateConcentricRings(arrayCustom));
                        break;
                    default:
                        Console.WriteLine("\nUnkown command...");
                        break;
                }
                Console.WriteLine($"\nWant to run assignment 6.4 again? type y/n");
                hold1 = Console.ReadKey().KeyChar;
                hold1 = Char.ToLower(hold1);
            }
            while (hold1 == 'y');
            Console.WriteLine("\nGoodbye!");
        }
        //------------------------------------------------------METHODS---------------------------------------------------
        public static int[,] NinetyDegCWMatrixRotate(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            //Transpose across UpperLeft to LowerRight diagonal:
            for (int i = 0; i < n; i++) // rows
            {
                for ( int j = i; j < n; j++) // columns
                {
                    int temp = matrix[i, j];
                    matrix[i, j] = matrix[j,i];
                    matrix[j,i] = temp;
                }
            }

            //Reflect across "y" axis:
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n/2; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i,j] = matrix[i,n-1-j];
                    matrix[i, n - 1 - j] = temp;
                }
            }
            return matrix;
        }
        public static int[,] RotateConcentricRings(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            for (int i = 0; i < n /2; i++)
            {
                for (int j=i; j<n-i-1; j++)
                {
                    int temp = matrix[i, j];
                    matrix[i,j] = matrix[n-1-j,i];
                    matrix[n-1-j,i] = matrix[n-1-i,n-1-j];
                    matrix[n-1-i,n-1-j] = matrix[j, n-1-i];
                    matrix[j,n-1-i]=temp;
                }
            }
            return matrix;
        }
        public static int [,] CustomArray()
        {
            Console.WriteLine("\nEnter the 'n' dimensioning of your desired n x n array:");
            int arraySize = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[arraySize, arraySize];
            Console.WriteLine("\nEnter the elements of the 2D Array:");
            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++)
                {
                    Console.Write($"Element [{i},{j}]: ");
                    array[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            return array;
        }
        public static void DisplayArray(in int[,] array)
        {
            int n = array.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{array[i,j]}, ");
                }
                Console.WriteLine();
            }

        }
    }
}
