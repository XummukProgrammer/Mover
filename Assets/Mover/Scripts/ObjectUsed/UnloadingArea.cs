using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Mover
{
    public class UnloadingArea : ObjectUsed
    {
        private Inventory _inventory;

        [SerializeField] private string[] _items;

        public bool IsWin
        {
            get; private set;
        }

        [Inject]
        public void Construct(Inventory inventory)
        {
            _inventory = inventory;
        }

        public override void Use()
        {
            base.Use();

            IsWin = false;

            foreach (var itemId in _items)
            {
                var item = _inventory.GetItem(itemId);
                if (item != null)
                {
                    if (item.Value < 0)
                    {
                        return;
                    }
                }    
            }

            IsWin = true;
        }
    }
}
