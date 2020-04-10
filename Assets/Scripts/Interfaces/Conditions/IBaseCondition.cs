namespace Interfaces.Conditions
{
    public interface IBaseCondition
    {
        string Title { get; }
        
        byte Level { get; }
    }
}