namespace Interfaces.Conditions
{
    public interface IBaseResult: IBaseCondition
    {
        byte Percent { get; }
    }
}