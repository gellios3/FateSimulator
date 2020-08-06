namespace Interfaces
{
    public interface IPartyMember
    {
        ushort Id { get; }
        string Name { get; }
        ushort Level { get; }
        ushort Hp { get; }
        ushort Xp { get; }
    }
}