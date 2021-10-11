using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rwa_projekt_katlija_2407.Models.ViewModels
{
    public class ReceiptVM
    {
        public Customer Customer { get; set; }
        public IEnumerable<Receipt> Receipts { get; set; }
    }
}