using ScriptableObjects;

namespace Interfaces
{
    public interface IBaseObj
    {
        ushort Id { get; }
        AllItemsDataBase DataBase { get; }
    }
}