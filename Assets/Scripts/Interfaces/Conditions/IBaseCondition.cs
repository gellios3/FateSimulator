namespace Interfaces.Conditions
{
    public interface IBaseCondition : IBaseObj
    {
        string Title { get; }
        byte Level { get; }
    }
}