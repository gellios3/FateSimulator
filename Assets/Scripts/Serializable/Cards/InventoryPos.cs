using System;
using Interfaces.Cards;

namespace Serializable.Cards
{
    [Serializable]
    public class InventoryPos : IInventoryPos
    {
        public byte rowIndex;
        public byte RowIndex => rowIndex;
        
        public byte colIndex;
        public byte ColIndex => colIndex;
    }
}