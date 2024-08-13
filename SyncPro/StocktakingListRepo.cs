using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncPro
{
    public class StocktakingListRepo
    {
        public int StocktakingListId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string CountedBy { get; set; }
        public string Auditor { get; set; }
        public bool CountFinish { get; set; }
    }
}
