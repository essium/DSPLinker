namespace DSPLinker.Database
{
    internal class Factory
    {
        public int factoryId;
        public string name = "";
        public float efficiency;

        public Factory(Item item, float efficiency)
        {
            factoryId = item.itemId;
            name = item.name;
            this.efficiency = efficiency;
        }
    }
}
