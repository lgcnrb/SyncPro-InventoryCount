using System;

namespace SyncPro
{
    public class StockCountRepo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Location { get; set; }
        public string BatchCode { get; set; }
        public int CountedQuantity { get; set; }
        public int StocktakingListId { get; set; }
        public bool ProductCodeMatch { get; set; }
        public bool ProductNameMatch { get; set; }
        public bool LocationMatch { get; set; }
        public bool IsProductInSystem { get; set; } // Ürün sistemde var mı?
        public int QuantityDifference { get; set; } // Güncellenmiş özellik
    }
}
