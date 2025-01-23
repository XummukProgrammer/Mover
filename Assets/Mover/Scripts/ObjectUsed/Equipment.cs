using UnityEngine;
using Zenject;

namespace Mover
{
    public class Equipment : ObjectUsed
    {
        private Inventory _inventory;

        [SerializeField]
        private string _itemId;

        [Inject]
        public void Construct(Inventory inventory)
        {
            _inventory = inventory;
        }

        public override void Use()
        {
            base.Use();

            var item = _inventory.GetItem(_itemId);
            if (item != null)
            {
                item.Add(1);
            }

            Destroy(gameObject);
        }
    }
}
