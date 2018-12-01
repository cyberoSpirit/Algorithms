using System;
using System.Collections.Generic;
using System.Linq;

namespace T1_Union_Find.Engine
{
    public class Union_Find_Algorithm
    {
        public List<KeyValuePair<int, int>> Input { get; set; }
        public List<List<int>> UnionList { get { return CreateUnionsListByIds(); } }
        private int[] elementsIds;
        private int elementsCount;

        public Union_Find_Algorithm()
        {
            Input = new List<KeyValuePair<int, int>>();
        }

        public void FillInput()
        {
            Input.Add(new KeyValuePair<int, int>(1, 2));
            Input.Add(new KeyValuePair<int, int>(3, 4));
            Input.Add(new KeyValuePair<int, int>(5, 6));
            Input.Add(new KeyValuePair<int, int>(7, 8));
            Input.Add(new KeyValuePair<int, int>(7, 9));
            Input.Add(new KeyValuePair<int, int>(2, 8));
            Input.Add(new KeyValuePair<int, int>(0, 5));
            Input.Add(new KeyValuePair<int, int>(1, 9));
        }

        public int GetUnionsCount()
        {
            return elementsIds.Distinct().Count();
        }

        public void PrintInput()
        {
            Console.WriteLine("Input:");
            Printer.PrintListOfKeyValuePairs(Input, ", ");
        }

        public void PrintUnions()
        {
            Console.WriteLine("Making unions...");
            QuickFind();
            Printer.PrintUnions(UnionList, ", ");
        }

        private void QuickFind()
        {
            elementsCount = FindMaxElement(Input) + 1;
            elementsIds = new int[elementsCount];
            for (int i = 0; i < elementsCount; ++i)
            {
                elementsIds[i] = i;
            }

            foreach (var elem in Input)
            {
                if(!AreConnected(elem.Key, elem.Value))
                {
                    ConnectElements(elem.Key, elem.Value);
                }
            }
        }

        private List<List<int>> CreateUnionsListByIds()
        {
            var unions = elementsIds.Distinct().ToList();
            var list = new List<List<int>>();

            for (int i = 0; i < unions.Count; ++i)
            {
                list.Add(new List<int>());

                for (int j = 0; j < elementsCount; ++j)
                {
                    if (elementsIds[j] == unions[i])
                    {
                        list[i].Add(j);
                    }
                }
            }
            return list;
        }

        private void ConnectElements(int element1, int element2)
        {
            int oldId = elementsIds[element1];
            int newId = elementsIds[element2];

            for (int i = 0; i < elementsCount; ++i)
            {
                if (elementsIds[i] == oldId)
                {
                    elementsIds[i] = newId;
                }
            }
        }

        private bool AreConnected(int element1, int element2)
        {
            return elementsIds[element1] == elementsIds[element2];
        }

        private int FindMaxElement(List<KeyValuePair<int, int>> pairList)
        {
            int max = pairList.First().Key;
            
            foreach(var elem in pairList)
            {
                max = (max < elem.Key) ? elem.Key : max;
                max = (max < elem.Value) ? elem.Value : max;
            }
            
            return max;
        }
    }
}
