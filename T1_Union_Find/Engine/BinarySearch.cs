using System;
using System.Linq;

namespace T1_Union_Find.Engine
{
    public class BinarySearch
    {
        public static int Search(int[] array, int element)
        {
            int lowIndex = 0;
            int highIndex = array.Count() - 1;
            int middle;

            while (lowIndex<=highIndex)
            {
                middle = lowIndex + (highIndex - lowIndex) / 2;
                if (element < array[middle])
                {
                    highIndex = middle - 1;
                }
                else if (element > array[middle])
                {
                    lowIndex = middle + 1;
                }
                else
                {
                    return middle;
                }
            }
            return -1;
        }
    }
}
