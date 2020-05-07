using Interfaces;
using UnityEngine;

namespace AbstractViews
{
    public abstract class BaseView : MonoBehaviour, IBaseView
    {
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
    }
}