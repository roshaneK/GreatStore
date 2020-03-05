using GreatStore.Data.Models;

namespace GreatStore.Contracts.DataContracts
{
    public interface IStockData
    {
        Item GetItemByCode(uint code);
        bool IsItemExists(Item item);
        void AddItem(Item item);
        void UpdateItem(Item item);
        void RemoveItem(Item item);
    }
}
