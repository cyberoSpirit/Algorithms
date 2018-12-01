using System;
using System.Collections.Generic;
using System.Linq;

namespace T1_Union_Find.Engine
{
    public class Union_Find
    {
        public List<KeyValuePair<int, int>> Input { get; set; }
        public List<List<int>> UnionList { get; private set; }

        public Union_Find()
        {
            Input = new List<KeyValuePair<int, int>>();
            UnionList = new List<List<int>>();
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

        public void SortByUnions()
        {
            KeyValuePair<int, int> buffer;
            List<int> union = new List<int>();

            UnionList.Clear();

            if (Input.Count > 0)
            {
                buffer = Input[0];
                union.Add(buffer.Key);
                union.Add(buffer.Value);
                UnionList.Add(union);

                for (int i = 1; i < Input.Count; ++i)
                {
                    buffer = Input[i];
                    bool unionProcessed = false;
                    for (int j = 0; j < UnionList.Count && unionProcessed == false; ++j)
                    {
                        int connectionValue = -1;
                        union = UnionList[j];

                        if (union.Contains(buffer.Key) && union.Contains(buffer.Value))
                        {
                            unionProcessed = true;
                        }
                        else if (union.Contains(buffer.Key))
                        {
                            if (!union.Contains(buffer.Value))
                            {
                                connectionValue = buffer.Value;
                                union.Add(connectionValue);
                            }
                            unionProcessed = true;
                        }
                        else if (union.Contains(buffer.Value))
                        {
                            if (!union.Contains(buffer.Key))
                            {
                                connectionValue = buffer.Key;
                                union.Add(connectionValue);
                            }
                            unionProcessed = true;
                        }

                        if (connectionValue >= 0)
                        {
                            for (int k = j + 1; k < UnionList.Count; ++k)
                            {
                                if (UnionList[k].Contains(connectionValue))
                                {
                                    union.AddRange(UnionList[k]);
                                    UnionList.RemoveAt(k);
                                }
                            }
                        }
                    }

                    if (unionProcessed == false)
                    {
                        union = new List<int>();
                        union.Add(buffer.Key);
                        union.Add(buffer.Value);
                        UnionList.Add(union);
                    }
                }

                for (int i = 1; i < UnionList.Count; ++i)
                {
                    UnionList[i] = UnionList[i].Distinct().ToList();
                }
            }
        }

        public void Printinput()
        {
            Console.WriteLine("Input:");
            Printer.PrintListOfKeyValuePairs(Input, ", ");
        }

        public void PrintUnions()
        {
            Console.WriteLine("Making unions...");
            SortByUnions();
            Printer.PrintUnions(UnionList, ", ");
        }
    }
}
