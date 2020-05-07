using Interfaces;
using UnityEngine.UI;

namespace AbstractViews
{
    public class CustomButton : Button, IBaseView
    {
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}