using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPro
{
    public interface IStockCountRepository
    {
        Task<bool> Insert(StockCountRepo count);
        Task<bool> Update(StockCountRepo count);
        Task<bool> IsBatchCodeUniqueAsync(string batchCode, int stocktakingListId);
    }
}
