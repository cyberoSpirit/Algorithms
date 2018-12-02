using System;
using System.Collections.Generic;
using System.Linq;

namespace T1_Union_Find.Engine
{
    public class Quick_Union
    {
        public List<KeyValuePair<int, int>> Input { get; set; }
        public List<List<int>> TreesList { get { return CreateTreesListByIds(); } }
        private int[] elementsIds;
        private int elementsCount = 10;

        public Quick_Union()
        {
            Input = new List<KeyValuePair<int, int>>();
            elementsCount = 10;
        }

        public void FillInput()
        {
            Input.Add(new KeyValuePair<int, int>(9, 2));
            Input.Add(new KeyValuePair<int, int>(9, 4));
            Input.Add(new KeyValuePair<int, int>(4, 3));
            Input.Add(new KeyValuePair<int, int>(6, 5));
        }

        private void QuickUnion()
        {
            elementsIds = new int[elementsCount];
            for (int i = 0; i < elementsCount; ++i)
            {
                elementsIds[i] = i;
            }

            foreach (var elem in Input)
            {
                AddLeaf(elem.Key, elem.Value);
            }
        }

        private void AddLeaf(int root, int leaf)
        {
            elementsIds[leaf] = root;
        }

        private List<List<int>> CreateTreesListByIds()
        {
            var woodList = new List<List<int>>();
            List<int> treeList;

            for (int i = 0; i < elementsCount; ++i)
            {
                if (elementsIds[i] == i)
                {
                    treeList = new List<int>();
                    treeList.Add(i);
                    treeList.AddRange(GetLeaves(i));
                    woodList.Add(treeList);
                }
            }
            return woodList;
        }

        private List<int> GetLeaves(int root)
        {
            var list = new List<int>();
            for (int i = 0; i < elementsCount;++i)
            {
                if(elementsIds[i] == root && i!=root)
                {
                    list.Add(i);
                    list.AddRange(GetLeaves(i));
                }
            }

            return list;
        }

        public void PrintInput()
        {
            Console.WriteLine("Input:");
            Printer.PrintListOfKeyValuePairs(Input, ", ");
        }

        public void PrintUnions()
        {
            Console.WriteLine("Making unions...");
            QuickUnion();
            Printer.PrintUnions(TreesList, ", ");
        }
    }
}
