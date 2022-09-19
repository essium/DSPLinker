using System.Text;
using UnityEngine;

namespace DSPLinker
{
    internal class Auxiliary
    {
        public static string SorterStatus(BlueprintData blueprint)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var building in blueprint.buildings)
            {
                if (LinkInfo.IsSorter(building.itemId))
                {
                    stringBuilder.Append("sorter " + building.index + ":\r\n");
                    if (building.inputObj == null)
                    {
                        stringBuilder.Append("\tno input\r\n");
                    } else
                    {
                        stringBuilder.Append("\tinput item id: " + building.inputObj.itemId + "\r\n");
                    }
                    stringBuilder.Append("\tinputFromSlot: " + building.inputFromSlot + ", inputToSlot: " + building.inputToSlot + "\r\n");
                    if (building.outputObj == null)
                    {
                        stringBuilder.Append("\tno output\r\n");
                    }
                    else
                    {
                        stringBuilder.Append("\toutput item id: " + building.outputObj.itemId + "\r\n");
                    }
                    stringBuilder.Append("\toutputFromSlot: " + building.outputFromSlot + ", outputToSlot: " + building.outputToSlot + "\r\n");
                }
            }
            return stringBuilder.ToString();
        }

        public static string BeltMarker(BlueprintData blueprint)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var building in blueprint.buildings)
            {
                if (LinkInfo.IsBelt(building.itemId))
                {
                    if (building.parameters != null && building.parameters.Length > 0)
                    {
                        stringBuilder.Append("belt: " + building.index + ", mark: " + building.parameters[0] + "\r\n");
                    }
                }
            }
            return stringBuilder.ToString();
        }

        public static string Belts(LinkInfo linkInfo)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var kv in linkInfo.inputBelts)
            {
                stringBuilder.Append("input belt sequence with item " + kv.Key + ":\r\n\tsrc");
                foreach (var belt in kv.Value)
                {
                    stringBuilder.Append("->" + belt); 
                }
                stringBuilder.Append("->snk\r\n");
            }
            foreach (var kv in linkInfo.outputBelts)
            {
                stringBuilder.Append("output belt sequence with item " + kv.Key + ":\r\n\tsrc");
                foreach (var belt in kv.Value)
                {
                    stringBuilder.Append("->" + belt);
                }
                stringBuilder.Append("->snk\r\n");
            }
            return stringBuilder.ToString();
        }
    }
}
