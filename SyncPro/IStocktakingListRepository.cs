using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPro
{
    public interface IStocktakingListRepository
    {
        Task<int> InsertAndGetId(StocktakingListRepo list);
        Task<int> UpdateFinishDate(int stocktakingListId, DateTime finishDate);
        Task<bool> Insert(StocktakingListRepo list);
        Task<bool> InventoryHasItems();
        Task<bool> DeleteStocktakingList(int stocktakingListId);
        Task<bool> UpdateFinishStatus(int stocktakingListId, bool countFinish);
    }
}
