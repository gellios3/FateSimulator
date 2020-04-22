using System.Collections.Generic;
using System.Linq;
using AbstractViews;
using DG.Tweening;
using Enums;
using Serializable.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Canvas
{
    /// <summary>
    /// Color preset Image 
    /// </summary>
    public class ColorsPresetImage : BaseView
    {
        [SerializeField] private Image sourceImg;
        [SerializeField] private List<ColorPreset> presets;

        private void Start()
        {
            SetStatus(Status.Normal);
        }

        public void SetStatus(Status status)
        {
            var normalColor = GetPreset(status);
            if (normalColor.HasValue)
                sourceImg.color = normalColor.Value.color;
        }

        private ColorPreset? GetPreset(Status status)
        {
            return presets.FirstOrDefault(preset => preset.status == status);
        }

        public void PlayHighlightAnim(float duration)
        {
            var highlight = GetPreset(Status.Highlighted);
            var normal = GetPreset(Status.Normal);
            if (highlight.HasValue && normal.HasValue)
            {
                sourceImg.DOColor(highlight.Value.color, duration).onComplete += () =>
                {
                    sourceImg.DOColor(normal.Value.color, duration);
                };
            }
        }
    }
}