using System.Collections.Generic;

namespace Mover
{
    public class Inventory
    {
        private List<Item> _items = new();

        public void AddItem(Item item)
            => _items.Add(item);

        public Item GetItem(string id)
        {
            var item = _items.Find(item => item.Id == id);
            if (item != null)
            {
                return item;
            }

            var newItem = new Item
            {
                Id = id
            };
            AddItem(newItem);

            return newItem;
        }

        public interface IItem
        {
            public string Id { get; }
            public int Value { get; }

            public event System.Action<int, int> ValueChanged;

            public void Add(int value);
            public void Take(int value);

            public void Use();
        }
    }
}
