using System.Collections.Generic;

namespace Canvas.Inventory.Services
{
    public class OwnersService
    {
        /// <summary>
        /// Run Activity owner
        /// </summary>
        private List<ushort> RunOwners { get; } = new List<ushort>();

        public bool HasRunOwner(ushort ownerId)
        {
            return RunOwners.Exists(obj => obj == ownerId);
        }

        public void AddRunOwner(ushort ownerId)
        {
            if (!HasRunOwner(ownerId))
                RunOwners.Add(ownerId);
        }

        public void RemoveRunOwner(ushort ownerId)
        {
            RunOwners.Remove(ownerId);
        }
    }
}