using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPro
{
    public interface ISystemInventoryRepository
    {
        Task<bool> Insert(SystemInventoryRepository inventory);
        Task<bool> Update(SystemInventoryRepository inventory);
    }
}
