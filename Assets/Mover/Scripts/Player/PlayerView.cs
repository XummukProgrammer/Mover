using UnityEngine;

namespace Mover
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Transform _head;

        public Rigidbody Rigidbody => _rigidbody;
        public Transform Head => _head;

        public void AddForce(Vector2 vec)
        {
            Vector3 forwardVector = Head.transform.forward * vec.y;
            Vector3 horizontalVector = Head.transform.right * vec.x;
            Vector3 movement = forwardVector + horizontalVector;
            Rigidbody.AddForce(movement * 0.4f, ForceMode.Impulse);

            // TODO: Limit the speed!
        }

        public void Rotate(Vector2 vec)
        {
            Head.Rotate(-vec.y * 150f * Time.deltaTime * Vector3.right);
            Head.Rotate(vec.x * 150f * Time.deltaTime * Vector3.up, Space.World);
        }
    }
}
