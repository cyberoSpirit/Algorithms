using System;
using System.Collections.Generic;

namespace T1_Union_Find.Engine
{
    public class Printer
    {

        private static string GetUnionString(List<int> list,string separator)
        {
            string unionString = "{";
            for (int i = 0; i < list.Count; ++i)
            {
                unionString += list[i];
                if (i < list.Count - 1)
                {
                    unionString += separator;
                }
            }
            unionString += "}";
            return unionString;
        }


        public static void PrintListOfKeyValuePairs(List<KeyValuePair<int, int>> list, string separator)
        {
            string printString = string.Empty;
            for (int i = 0; i < list.Count; ++i)
            {
                printString += $"{list[i].Key}-{list[i].Value}";
                if (i < list.Count - 1)
                {
                    printString += separator;
                }
            }
            Console.WriteLine(printString);
        }

        public static void PrintUnions(List<List<int>> list, string separator)
        {
            string unionsString = string.Empty;

            for (int i = 0; i < list.Count; ++i)
            {
                unionsString += GetUnionString(list[i], separator);
                if (i < list.Count - 1)
                {
                    unionsString += ",   ";
                }
            }
                        Console.WriteLine(unionsString);
        }
    }
}
