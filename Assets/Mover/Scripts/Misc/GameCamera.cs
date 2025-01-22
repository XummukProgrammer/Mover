using UnityEngine;

namespace Mover
{
    public class GameCamera : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _speed;

        private GameObject _container; // Container for our camera

        public Transform Target
        {
            get; set;
        }

        void Start()
        {
            _container = new GameObject("Camera Container");
            transform.parent = _container.transform;
        }

        void LateUpdate()
        {
            //Check if target is selected
            if (Target == null)
            {
                return;
            }

            _container.transform.position = Target.position;
            _container.transform.rotation = Target.rotation;

            transform.localPosition = _offset;
            transform.LookAt(Target);
        }
    }
}
