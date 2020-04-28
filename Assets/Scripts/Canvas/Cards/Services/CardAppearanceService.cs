using System.Collections.Generic;
using System.Linq;
using Enums;
using Serializable;
using UnityEngine;

namespace Canvas.Cards.Services
{
    /// <summary>
    /// Card appearance service
    /// </summary>
    public class CardAppearanceService
    {
        private List<CardStatusPreset> Appearances { get; set; } = new List<CardStatusPreset>();

        public void Init(List<CardStatusPreset> appearances)
        {
            Appearances = appearances;
        }
        
        /// <summary>
        /// Get appearance
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public CardStatusPreset GetAppearance(CardStatus status)
        {
            return Appearances.FirstOrDefault(appearance => appearance.cardStatus == status);
        }
        
        /// <summary>
        /// Set appearance
        /// </summary>
        /// <param name="status"></param>
        /// <param name="color"></param>
        public void SetAppearance(CardStatus status, Color color)
        {
            var find = GetAppearance(status);
            if (find == null)
            {
                Appearances.Add(new CardStatusPreset
                {
                    cardStatus = status,
                    color = color
                });
            }
            else
            {
                find.color = color;
            }
        }
    }
}