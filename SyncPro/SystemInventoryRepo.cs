using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPro
{
    public class SystemInventoryRepo
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Location { get; set; }
        public string BatchCode { get; set; }
        public int StockQuantity { get; set; }
    }
}
