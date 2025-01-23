using UnityEngine;

namespace Mover
{
    public class Remover : ObjectUsed
    {
        [SerializeField] private Transform[] _objects;
        [SerializeField] private bool _destroyAfterUse = true;

        public override void Use()
        {
            base.Use();

            foreach (var @object in _objects)
            {
                Destroy(@object.gameObject);
            }

            if (_destroyAfterUse)
            {
                Destroy(gameObject);
            }
        }
    }
}
