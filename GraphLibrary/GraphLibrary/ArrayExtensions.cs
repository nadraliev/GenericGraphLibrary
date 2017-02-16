using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraphLibrary
{
    public static class ArraysUtils
    {
        public static T[,] ResizeArray<T>(T[,] original, int rows, int columns)
        {
            var newArray = new T[rows, columns];
            int minRows = rows;
            int minColumns = columns;
            if (original != null)
            {
                minRows = Math.Min(rows, original.GetLength(0));
                minColumns = Math.Min(columns, original.GetLength(1));
            }
            for (int i = 0; i < minRows; i++)
                for (int j = 0; j < minColumns; j++)
                    if (original != null)
                        newArray[i, j] = original[i, j];
                    else newArray[i, j] = default(T);
            return newArray;
        }

        public static T[,] TrimArray<T>(int rowToRemove, int columnToRemove, T[,] originalArray)
        {
            T[,] result = new T[originalArray.GetLength(0) - 1, originalArray.GetLength(1) - 1];

            for (int i = 0, j = 0; i < originalArray.GetLength(0); i++)
            {
                if (i == rowToRemove)
                    continue;

                for (int k = 0, u = 0; k < originalArray.GetLength(1); k++)
                {
                    if (k == columnToRemove)
                        continue;

                    result[j, u] = originalArray[i, k];
                    u++;
                }
                j++;
            }

            return result;
        }
    }
}
