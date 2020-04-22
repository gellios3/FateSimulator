﻿using AbstractViews;
using TMPro;
using UnityEngine;
using UnityEngine.UI.ProceduralImage;

namespace Canvas.Activities.Views
{
    public class ActivityTimerView : BaseView
    {
        [SerializeField] private ProceduralImage image;
        [SerializeField] private TextMeshProUGUI timeTxt;
        [SerializeField] private ushort time;

        private void Start()
        {
            timeTxt.text = "0";
            Hide();
        }

        public void Init(ushort duration)
        {
            time = duration;
        }

        // Update is called once per frame
        private void Update()
        {
            if (image.fillAmount < 1)
            {
                image.fillAmount += Time.deltaTime / time;
                timeTxt.text = (image.fillAmount * 10).ToString("F1");
            }
            else
            {
                image.fillAmount = 0;
                timeTxt.text = time.ToString("F1");
            }

            timeTxt.text += "s";
        }
    }
}