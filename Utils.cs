using Microsoft.VisualBasic.Logging;
using System.Text;

namespace DSPLinker
{
    internal class Utils
    {
        public static BlueprintData OpenFile(string fileName)
        {
            BlueprintData blueprintData = new BlueprintData();
            string base64Str = File.ReadAllText(fileName, Encoding.ASCII);
            blueprintData.FromBase64String(base64Str);
            return blueprintData;
        }
        public static void SaveFile(string fileName, BlueprintData blueprintData)
        {
            File.WriteAllText(fileName, blueprintData.ToBase64String());
        }
    }

    internal class LinkInfo
    {
        public Dictionary<int, List<int>> inputSorters;
        public Dictionary<int, List<int>> outputSorters;

        public Dictionary<int, List<int>> inputBelts;
        public Dictionary<int, List<int>> outputBelts;

        private Dictionary<int, List<List<int>>> tmpInBelts;
        private Dictionary<int, List<List<int>>> tmpOutBelts;

        public void AnalyzeLink(BlueprintData blueprint)
        {
            inputSorters = new Dictionary<int, List<int>>();
            outputSorters = new Dictionary<int, List<int>>();
            inputBelts = new Dictionary<int, List<int>>();
            outputBelts = new Dictionary<int, List<int>>();
            tmpInBelts = new Dictionary<int, List<List<int>>>();
            tmpOutBelts = new Dictionary<int, List<List<int>>>();
            for (int i = 0; i < blueprint.buildings.Length; i++)
            {
                BlueprintBuilding current = blueprint.buildings[i];
                if (IsSorter(current.itemId))
                {
                    int itemId = current.filterId;
                    if (itemId != 0)
                    {
                        if (current.outputObj == null || TooLong(current, blueprint.buildings[current.outputObj.index], false))
                        {
                            AddIfAbsent(outputSorters, itemId);
                            outputSorters[itemId].Add(current.index);
                        }
                        if (current.inputObj == null || TooLong(current, blueprint.buildings[current.inputObj.index], true))
                        {
                            AddIfAbsent(inputSorters, itemId);
                            inputSorters[itemId].Add(current.index);
                        }
                    }
                }
                if (IsBelt(current.itemId))
                {
                    if (current.parameters != null && current.parameters.Length >= 1)
                    {
                        int mark = current.parameters[0];
                        if (!(current.outputObj == null || current.outputObj.parameters == null || current.outputObj.parameters.Length == 0))
                        {
                            if (mark == (int)SIGN.ZERO)
                            {
                                int itemId = current.outputObj.parameters[0];
                                AddBelts(current, itemId, tmpInBelts);
                            }
                            if (mark == (int)SIGN.ONE)
                            {
                                int itemId = current.outputObj.parameters[0];
                                AddBelts(current, itemId, tmpOutBelts);
                            }
                        }
                    }
                }
            }
            Manipulate(tmpInBelts, inputBelts);
            Manipulate(tmpOutBelts, outputBelts);
        }


        private static bool TooLong(BlueprintBuilding sorter, BlueprintBuilding belt, bool input)
        {
            if (!IsBelt(belt.itemId))
            {
                return false;
            }
            if (sorter.areaIndex != belt.areaIndex)
            {
                return true;
            }
            float xs, ys, zs;
            if (input)
            {
                xs = sorter.localOffset_x;
                ys = sorter.localOffset_y;
                zs = sorter.localOffset_z;
            }
            else
            {
                xs = sorter.localOffset_x2;
                ys = sorter.localOffset_y2;
                zs = sorter.localOffset_z2;
            }
            xs -= belt.localOffset_x;
            ys -= belt.localOffset_y;
            zs -= belt.localOffset_z;
            float r2 = xs * xs + ys * ys + zs * zs; 
            if (r2 > 0.5)
            {
                return true;
            }
            return false;
        }
        public static bool IsSorter(int itemId)
        {
            return sorters.Contains(itemId);
        }

        public static bool IsBelt(int itemId)
        {
            return belts.Contains(itemId);
        }

        public string Link(BlueprintData blueprint)
        {
            StringBuilder stringBuilder= new StringBuilder();
            foreach (var entry in inputSorters)
            {
                int itemId = entry.Key;
                List<int> sorterIndexes = entry.Value;
                List<int> beltIndexes = inputBelts[itemId];
                int beltCount = beltIndexes.Count();
                if (beltCount * 8 < sorterIndexes.Count)
                {
                    stringBuilder.Append("too many sorters to be link for input item: " + (ITEM) itemId + ", sorter/belt: " + sorterIndexes.Count + "/" + beltCount + "\r\n");
                }
                else
                {
                    stringBuilder.Append("input item: " + (ITEM) itemId + ", sorter/belt: " + sorterIndexes.Count() + "/" + beltCount + "\r\n");
                }
                for (int i = 0; i < sorterIndexes.Count; i++)
                {
                    BlueprintBuilding sorter = blueprint.buildings[sorterIndexes[i]];
                    sorter.inputObj = blueprint.buildings[beltIndexes[i % beltCount]];
                    sorter.inputFromSlot = -1;
                    sorter.inputToSlot = 1;
                }
            }
            foreach (var entry in outputSorters)
            {
                int itemId = entry.Key;
                List<int> sorterIndexes = entry.Value;
                List<int> beltIndexes = outputBelts[itemId];
                int beltCount = beltIndexes.Count();
                if (beltCount * 8 < sorterIndexes.Count)
                {
                    stringBuilder.Append("too many sorters to be link for output item: " + (ITEM) itemId + ", sorter/belt: " + sorterIndexes.Count + "/" + beltCount + "\r\n");
                }
                else
                {
                    stringBuilder.Append("output item: " + (ITEM) itemId + ", sorter/belt: " + sorterIndexes.Count() + "/" + beltCount + "\r\n");
                }
                for (int i = 0; i < sorterIndexes.Count; i++)
                {
                    BlueprintBuilding sorter = blueprint.buildings[sorterIndexes[i]];
                    sorter.outputObj = blueprint.buildings[beltIndexes[i % beltCount]];
                    sorter.outputFromSlot = 0;
                    sorter.outputToSlot = -1;
                }
            }
            return stringBuilder.ToString();
        }
        private void AddIfAbsent(Dictionary<int, List<int>> dict, int itemId)
        {
            if (!dict.ContainsKey(itemId))
            {
                dict.Add(itemId, new List<int>());
            }
        }
        private void AddBelts(BlueprintBuilding building, int itemId, Dictionary<int, List<List<int>>> dict)
        {
            if (!dict.ContainsKey(itemId))
            {
                dict.Add(itemId, new List<List<int>>());
            }
            BlueprintBuilding p = building;
            List<int> tmp = new List<int>();
            dict[itemId].Add(tmp);
            tmp.Add(p.index);
            while (true)
            {
                p = p.outputObj;
                if (p == null || !IsBelt(p.itemId))
                {
                    break;
                } else if (p.parameters == null || p.parameters.Length == 0)
                {
                    tmp.Add(p.index);
                } else if (p.parameters[0] == (int) SIGN.STOP)
                {
                    continue;
                } else if (p.parameters[0] == (int) SIGN.ZERO)
                {
                    AddBelts(p, itemId, tmpInBelts);
                    break;
                } else if (p.parameters[0] == (int) SIGN.ONE)
                {
                    AddBelts(p, itemId, tmpOutBelts);
                    break;
                } else
                {
                    tmp.Add(p.index);
                }
            }
        }

        private void Manipulate(Dictionary<int, List<List<int>>> inDict, Dictionary<int, List<int>> outDict)
        {
            foreach(var entry in inDict)
            {
                int itemId = entry.Key;
                List<List<int>> value = entry.Value;
                List<int> tmp = new List<int>();
                outDict.Add(itemId, tmp);
                int totalCnt = 0;
                int maxCnt = 0;
                foreach (var list in value)
                {
                    totalCnt += list.Count;
                    maxCnt = maxCnt < list.Count ? list.Count : maxCnt;
                }
                for (int i = 0; i < maxCnt; i++)
                {
                    foreach (var list in value)
                    {
                        if (list.Count > i)
                        {
                            tmp.Add(list[i]);
                        }
                    }
                }
            }
        }
        private static HashSet<int> belts;
        private static HashSet<int> sorters;

        static LinkInfo()
        {
            belts = new HashSet<int>
            {
                (int) ITEM.BELT_1,
                (int) ITEM.BELT_2,
                (int) ITEM.BELT_3
            };

            sorters = new HashSet<int>
            {
                (int) ITEM.SORTER_1,
                (int) ITEM.SORTER_2,
                (int) ITEM.SORTER_3
            };
        }
    }
}
