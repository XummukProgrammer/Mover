using UnityEngine;
using UnityEngine.EventSystems;

namespace Mover
{
    public class JostikButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event System.Action Clicking;

        private bool _isClick = false;

        public void OnPointerUp(PointerEventData eventData)
        {
            _isClick = false;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _isClick = true;
        }

        private void Update()
        {
            if (_isClick)
            {
                Clicking?.Invoke();
            }
        }
    }
}
