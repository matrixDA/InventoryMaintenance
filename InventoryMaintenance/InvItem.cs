using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMaintenance
{
    public class InvItem
    {
        public int ItemNo { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public InvItem()
        {

        }

        public InvItem(int itemNo, string description, decimal price)
        {
            this.ItemNo = itemNo;
            this.Description = description;
            this.Price = price;
        }

        public string GetDisplayedText(string sep)
        {
            return $"{ItemNo.ToString()} {sep} {Description} ({Price.ToString("c")})";
        }
    }
}
