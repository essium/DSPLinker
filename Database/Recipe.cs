namespace DSPLinker.Database
{
    internal class Recipe
    {
        public int recipeId { get; set; }
        public int[] items { get; set; } = Array.Empty<int>();
        public int[] itemCounts { get; set; } = Array.Empty<int>();
        public int[] results { get; set; } = Array.Empty<int>();
        public int[] resultCounts { get; set; } = Array.Empty<int>();
        public int timeSpend { get; set; }

        public string name { get; set; } = "";
        public int InputQuantity(int itemId)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == itemId)
                {
                    return itemCounts[i];
                }
            }
            return 0;
        }

        public int OutputQuantity(int itemId)
        {
            for(int i=0; i < results.Length; i++)
            {
                if (results[i] == itemId)
                {
                    return resultCounts[i];
                }
            }
            return 0;
        }
    }
}
