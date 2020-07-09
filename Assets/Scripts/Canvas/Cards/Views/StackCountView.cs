using AbstractViews;
using TMPro;
using UnityEngine;

namespace Canvas.Cards.Views
{
    public class StackCountView : BaseView
    {
        [SerializeField] private TextMeshProUGUI countTxt;
        [SerializeField] private ushort currentCount;

        private void Start()
        {
            currentCount = 0;
            Hide();
        }

        public void AddStackCount()
        {
            Show();
            currentCount++;
            countTxt.text = currentCount.ToString();
        }
    }
}