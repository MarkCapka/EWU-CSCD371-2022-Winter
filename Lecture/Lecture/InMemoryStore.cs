namespace Lecture
{
    public class InMemoryStore : IStore
    {
        public void Save(ISavable item)
        {
            Item = item;
        }

        public ISavable? Item { get; set; }
    }
}