namespace DSPLinker.Database
{
    internal class Sorter
    {
        public int sorterId;
        public string name = "";
        public int timeSpend;

        public Sorter(Item item, int timeSpend)
        {
            sorterId = item.itemId;
            name = item.name;
            this.timeSpend = timeSpend;
        }
    }
}
