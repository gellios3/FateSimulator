using System.Collections.Generic;
using System.Linq;
using Enums;
using Serializable;

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
    }
}