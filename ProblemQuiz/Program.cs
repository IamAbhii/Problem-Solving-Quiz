using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemQuiz
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = {{ 0, 1, 1, 1, 0 },
                            { 0, 0, 0, 0, 1 },
                            { 1, 0, 1, 1, 1 },
                            { 0, 0, 0, 0, 1 },
                            { 0, 1, 1, 0, 0 },};
            Console.WriteLine(FindTheLongestX(array));
            Console.ReadLine();
        }
        static bool CheckRelation(int a, int b, bool[,] array)
        {
            bool res = (array[a, b] == true) ? true : false;
            return res;
        }
        static int FindFamousPerson(int n, bool[,] array)
        {
            int pointerA = 0;
            int pointerB = n - 1;

            while (pointerA < pointerB)
            {
                if (CheckRelation(pointerA, pointerB, array))
                    pointerA++;
                else
                    pointerB--;

            }

            for (int i = 0; i < n; i++)
            {

                if (i != pointerA)
                {
                    if (CheckRelation(pointerA, i, array) || !CheckRelation(i, pointerA, array))
                    {
                        return -1;
                    }
                }


            }
            return pointerA + 1;
        }

        public static int FindTheLongestX(int[,] array)
        {
            var RowLength = array.GetLength(0);
            var ColummLength = array.GetLength(1);
            int increment = 1, decrement = -1, counter = 0;
            int LengthOfX = 0;
            //int incrementedIndexOfrow, decrementedIndexOfrow, incrementedIndexOfColumn, decrementedIndexOfColumn;
            for (int i = 0; i < RowLength; i++)
            {
                for (int j = 0; j < ColummLength; j++)
                {
                    if (array[i, j] == 0)
                    {

                        while ((i + increment) < RowLength && (j + increment) < ColummLength &&
                                (i + decrement) > -1 && (j + decrement) > -1 &&
                                array[i + decrement, j + decrement] == 0 &&
                                array[i + decrement, j + increment] == 0 &&
                                array[i + increment, j + decrement] == 0 &&
                                array[i + increment, j + increment] == 0)

                        {
                            counter++;
                            increment++;
                            decrement--;
                        }
                    }
                    if (LengthOfX < counter)
                    {
                        LengthOfX = counter;
                    }
                    counter = 0;
                    increment = 1;
                    decrement = -1;
                }

            }

            return LengthOfX * 2;
        }
    }
   
}
