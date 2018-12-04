using System;
using System.Collections.Generic;
using System.Linq;

namespace T1_Union_Find.Engine
{
    public class Quick_Union_Improved
    {
        public List<KeyValuePair<int, int>> Input { get; set; }
        public List<List<int>> TreesList { get { return CreateTreesListByIds(); } }
        private int[] elementsIds;
        private int[] treeSize;
        private int elementsCount;

        public Quick_Union_Improved(int n)
        {
            Input = new List<KeyValuePair<int, int>>();
            elementsCount = n;
            elementsIds = new int[elementsCount];
            treeSize = new int[elementsCount];
            FillIds();
            FillTreesSizes();
        }

        public void FillInput()
        {
            Input.Add(new KeyValuePair<int, int>(4, 3));
            Input.Add(new KeyValuePair<int, int>(3, 8));
            Input.Add(new KeyValuePair<int, int>(6, 5));
            Input.Add(new KeyValuePair<int, int>(9, 4));
            Input.Add(new KeyValuePair<int, int>(2, 1));
            Input.Add(new KeyValuePair<int, int>(5, 0));
            Input.Add(new KeyValuePair<int, int>(7, 2));
            Input.Add(new KeyValuePair<int, int>(6, 1));
            Input.Add(new KeyValuePair<int, int>(7, 3));
        }

       /* private void QuickUnion()
        {
            foreach (var elem in Input)
            {
                AddLeaf(elem.Key, elem.Value);
            }
        }*/

        private void FillIds()
        {
            for (int i = 0; i < elementsCount; ++i)
            {
                elementsIds[i] = i;
            }
        }

        private void FillTreesSizes()
        {
            for (int i = 0; i < elementsCount; ++i)
            {
                treeSize[i] = 1;
            }
        }

        public void AddLeaf(int startElem, int newAddElem)
        {
            if (startElem == newAddElem) return;

            int rootOfElem1 = GetRoot(startElem);
            int rootOfElem2 = GetRoot(newAddElem);
            int firstTreeSize = treeSize[rootOfElem1];
            int secondTreeSize = treeSize[rootOfElem2];

            if (firstTreeSize >= secondTreeSize)
            {
                elementsIds[rootOfElem2] = rootOfElem1;
                treeSize[rootOfElem1] += treeSize[rootOfElem2];
            }
            else
            {
                elementsIds[rootOfElem1] = rootOfElem2;
                treeSize[rootOfElem2] += treeSize[rootOfElem1];
            }
        }

        private int GetRoot(int elem)
        {
            int buffer = elem;
            while(elementsIds[buffer] != buffer)
            {
                buffer = elementsIds[buffer];
            }
            return elementsIds[buffer];
        }

        private List<int> GetLeaves(int root)
        {
            var list = new List<int>();
            for (int i = 0; i < elementsCount; ++i)
            {
                if (elementsIds[i] == root && i != root)
                {
                    list.Add(i);
                    list.AddRange(GetLeaves(i));
                }
            }

            return list;
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

        public void PrintInput()
        {
            Console.WriteLine("Input:");
            Printer.PrintListOfKeyValuePairs(Input, ", ");
        }

        public void PrintUnions()
        {
            Console.WriteLine("Making unions...");
           //QuickUnion();
            Printer.PrintUnions(TreesList, ", ");
        }
    }
}
