using System;
using System.Collections.Generic;
using System.Linq;
using Enums;
using Serializable.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Canvas
{
    public class ColorsPresetImage : MonoBehaviour
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
    }
}