using UnityEngine;

namespace Cards.Views
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private RectTransform mask;

        [SerializeField] private Vector3 defaultMask;
        [SerializeField] private Vector3 dragMask;

        private Vector2 defaultSizeDelta;

        private void Start()
        {
            defaultSizeDelta = mask.sizeDelta;
        }

        public void OnStartDragCard()
        {
            transform.SetAsLastSibling();
            mask.sizeDelta = defaultSizeDelta;
            mask.transform.localPosition = new Vector3(dragMask.x, dragMask.y, dragMask.z);
        }

        public void OnEndDrag()
        {
            mask.transform.localPosition = new Vector3(defaultMask.x, defaultMask.y, defaultMask.z);
        }

        public void OnDropDrag()
        {
            Debug.LogError("OnDropDrag");
            mask.sizeDelta = new Vector2(50, 90);
            // mask.sizeDelta = GetComponent<RectTransform>().sizeDelta;
        }
    }
}