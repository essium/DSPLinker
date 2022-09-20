using System.Text.Json;
using System.Text.Json.Serialization;

namespace DSPLinker.Database
{
    internal class LDB
    {
        private static LDB? instance = null;
        public Item[] items { get; set; } = Array.Empty<Item>();
        public Recipe[] recipes { get; set; } = Array.Empty<Recipe>();
        public Signal[] signals { get; set; } = Array.Empty<Signal>();

        private Factory[] factories = Array.Empty<Factory>();

        private Belt[] belts = Array.Empty<Belt>();

        private Sorter[] sorters = Array.Empty<Sorter>();

        private Dictionary<string, int> itemName2Index = new();
        private Dictionary<int, int> itemId2Index = new();
        private Dictionary<string, int> signalName2Index = new();
        private Dictionary<int, int> signalId2Index = new();
        private Dictionary<string, int> recipeName2Index = new();
        private Dictionary<int, int> recipeId2Index = new();
        private Dictionary<int, int> factoryId2Index = new();
        private Dictionary<int, int> beltId2Index = new();
        private Dictionary<int, int> sorterId2Index = new();
        public LDB()
        {
        }

        private void InitHardcode()
        {
            List<Factory> tempFactories = new();
            tempFactories.Add(new Factory(GetItem("制造台 Mk.I"), 0.75f));
            tempFactories.Add(new Factory(GetItem("制造台 Mk.II"), 1f));
            tempFactories.Add(new Factory(GetItem("制造台 Mk.III"), 1.5f));
            tempFactories.Add(new Factory(GetItem("电弧熔炉"), 1f));
            tempFactories.Add(new Factory(GetItem("位面熔炉"), 2f));
            tempFactories.Add(new Factory(GetItem("原油精炼厂"), 1f));
            tempFactories.Add(new Factory(GetItem("化工厂"), 1f));
            tempFactories.Add(new Factory(GetItem("微型粒子对撞机"), 1f));
            factories = tempFactories.ToArray();
            List<Belt> tempBelts = new();
            tempBelts.Add(new Belt(GetItem("低速传送带"), 360));
            tempBelts.Add(new Belt(GetItem("高速传送带"), 720));
            tempBelts.Add(new Belt(GetItem("极速传送带"), 1800));
            belts = tempBelts.ToArray();
            List<Sorter> tempSorters = new();
            tempSorters.Add(new Sorter(GetItem("低速分拣器"), 40));
            tempSorters.Add(new Sorter(GetItem("高速分拣器"), 20));
            tempSorters.Add(new Sorter(GetItem("极速分拣器"), 10));
            sorters = tempSorters.ToArray();
        }

        private static void Create()
        {
            if (LDB.instance != null)
            {
                return;
            }
            string jsonString = Resources.ldb;
            LDB.instance = JsonSerializer.Deserialize<LDB>(jsonString);
            instance.InitIndex();
            instance.InitHardcode();
            instance.PostIndex();
        }
        private void InitIndex()
        {
            for (int i = 0; i < items.Length; i++)
            {
                itemName2Index.Add(items[i].name, i);
                itemId2Index.Add(items[i].itemId, i);
            }
            for (int i = 0; i < recipes.Length; i++)
            {
                recipeName2Index.Add(recipes[i].name, i);
                recipeId2Index.Add(recipes[i].recipeId, i);
            }
            for (int i = 0; i < signals.Length; i++)
            {
                signalName2Index.Add(signals[i].name, i);
                signalId2Index.Add(signals[i].signalId, i);
            }
        }

        private void PostIndex()
        {
            for (int i = 0; i < factories.Length; i++)
            {
                factoryId2Index.Add(factories[i].factoryId, i);
            }
            for (int i = 0; i < belts.Length; i++)
            {
                beltId2Index.Add(belts[i].beltId, i);
            }
            for (int i = 0; i < sorters.Length; i++)
            {
                sorterId2Index.Add(sorters[i].sorterId, i);
            }
        }

        public static Item? GetItem(int itemId)
        {
            Create();
            if (instance.itemId2Index.ContainsKey(itemId))
            {
                return instance.items[instance.itemId2Index[itemId]];
            }
            return null;
        }

        public static Item? GetItem(string name)
        {
            Create();
            if (instance.itemName2Index.ContainsKey(name))
            {
                return instance.items[instance.itemName2Index[name]];
            }
            return null;
        }

        public static Recipe? GetRecipe(int recipeId)
        {
            Create();
            if (instance.recipeId2Index.ContainsKey(recipeId))
            {
                return instance.recipes[instance.recipeId2Index[recipeId]];
            }
            return null;
        }

        public static Recipe? GetRecipe(string name)
        {
            Create();
            if (instance.recipeName2Index.ContainsKey(name))
            {
                return instance.recipes[instance.recipeName2Index[name]];
            }
            return null;
        }

        public static Signal? GetSignal(int signalId)
        {
            Create();
            if (instance.signalId2Index.ContainsKey(signalId))
            {
                return instance.signals[instance.signalId2Index[signalId]];
            }
            return null;
        }

        public static Signal? GetSignal(string name)
        {
            Create();
            if (instance.signalName2Index.ContainsKey(name))
            {
                return instance.signals[instance.signalName2Index[name]];
            }
            return null;
        }

        public static Factory? GetFactory(int itemId)
        {
            Create();
            if (instance.factoryId2Index.ContainsKey(itemId))
            {
                return instance.factories[instance.factoryId2Index[itemId]];
            }
            return null;
        }

        public static Belt? GetBelt(int itemId)
        {
            Create();
            if (instance.beltId2Index.ContainsKey(itemId))
            {
                return instance.belts[instance.beltId2Index[itemId]];
            }
            return null;
        }

        public static Sorter? GetSorter(int itemId)
        {
            Create();
            if (instance.sorterId2Index.ContainsKey(itemId))
            {
                return instance.sorters[instance.sorterId2Index[itemId]];
            }
            return null;
        }
    }
}
