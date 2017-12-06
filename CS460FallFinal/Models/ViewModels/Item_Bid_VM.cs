using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS460FallFinal.Models.ViewModels
{
    public class Item_Bid_VM
    {
        public IEnumerable<BID> CurrentBids { get; set; }
        public IEnumerable<ITEM> Items { get; set; }
    }
}