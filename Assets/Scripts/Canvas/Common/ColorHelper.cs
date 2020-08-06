using UnityEngine;
using UnityEngine.UI;

namespace Canvas.Common
{
    public static class ColorHelper
    {
        private static Color DefaultColor { get; } = new Color(0, 0, 0, 0);

        public static void SetImgColor(Image sourceImg, Color color)
        {
            if (color != DefaultColor)
                sourceImg.color = color;
        }
    }
}