namespace DSPLinker.Database
{
    internal class Belt
    {
        public int beltId;
        public string name = "";
        public int capacity;

        public Belt(Item item, int capacity)
        {
            beltId = item.itemId;
            name = item.name;
            this.capacity = capacity;
        }
    }
}
