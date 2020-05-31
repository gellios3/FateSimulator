using Enums;

namespace Canvas.Common
{
    public static class StatusHelper
    {
        public static bool IsUseableStatus(CardStatus status)
        {
            return status == CardStatus.Normal;
        }
    }
}