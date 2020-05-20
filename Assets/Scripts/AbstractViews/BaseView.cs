using Interfaces;
using UnityEngine;

namespace AbstractViews
{
    public abstract class BaseView : MonoBehaviour, IBaseView
    {
        public bool HasShow { get; private set; } = true;

        public virtual void Hide()
        {
            HasShow = false;
            gameObject.SetActive(false);
        }

        public virtual void Show()
        {
            HasShow = true;
            gameObject.SetActive(true);
        }
    }
}