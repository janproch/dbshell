using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.Utility
{
    public class TargetColumnMap
    {
        public class Item
        {
            public int Source;
            public int Target;

            public override string ToString()
            {
                return String.Format("{0}=>{1}", Source, Target);
            }
        }

        public readonly TableInfo Source;
        public readonly TableInfo Target;
        public readonly TargetColumnMapMode MapMode;
        public readonly List<Item> Items = new List<Item>();
        public Dictionary<int, int> SourceByTarget = new Dictionary<int, int>();
        public Dictionary<int, int> TargetBySource = new Dictionary<int, int>();

        public TargetColumnMap(TableInfo source, TableInfo target, TargetColumnMapMode mode)
        {
            Source = source;
            Target = target;
            MapMode = mode;
            Initialize();
        }

        private void Initialize()
        {
            switch (MapMode)
            {
                case TargetColumnMapMode.Ordinal:
                    for (int i = 0; i < Math.Min(Source.Columns.Count, Target.Columns.Count); i++)
                    {
                        Items.Add(new Item
                            {
                                Source = i,
                                Target = i,
                            });
                    }
                    break;
                case TargetColumnMapMode.OrdinalSkipIdentity:
                    {
                        int srcIndex = 0, dstIndex = 0;
                        while (srcIndex < Source.Columns.Count && dstIndex < Target.Columns.Count)
                        {
                            if (Target.Columns[dstIndex].AutoIncrement)
                            {
                                dstIndex++;
                                continue;
                            }
                            if (Target.Columns[dstIndex].ComputedExpression != null)
                            {
                                dstIndex++;
                                continue;
                            }
                            Items.Add(new Item
                                {
                                    Source = srcIndex,
                                    Target = dstIndex,
                                });
                            srcIndex++;
                            dstIndex++;
                        }
                    }
                    break;
                case TargetColumnMapMode.Name:
                case TargetColumnMapMode.NameExact:
                    {
                        for (int i = 0; i < Target.Columns.Count; i++)
                        {
                            string name = Target.Columns[i].Name;
                            int srcIndex = Source.Columns.IndexOfIf(col => String.Compare(col.Name, name, MapMode == TargetColumnMapMode.Name) == 0);
                            if (srcIndex < 0) continue;
                            Items.Add(new Item
                                {
                                    Source = srcIndex,
                                    Target = i,
                                });
                        }
                    }
                    break;
            }

            foreach(var item in Items)
            {
                TargetBySource[item.Source] = item.Target;
                SourceByTarget[item.Target] = item.Source;
            }
        }

        public ColumnInfo GetTargetColumnBySourceIndex(int sourceIndex)
        {
            if (TargetBySource.ContainsKey(sourceIndex)) return Target.Columns[TargetBySource[sourceIndex]];
            return null;
        }

        public ColumnInfo GetSourceColumnByTargetIndex(int targetIndex)
        {
            if (SourceByTarget.ContainsKey(targetIndex)) return Source.Columns[SourceByTarget[targetIndex]];
            return null;
        }
    }
}
