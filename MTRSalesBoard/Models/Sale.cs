﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTRSalesBoard.Models
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }
        public decimal SaleAmount { get; set; }
        public DateTime SaleDate { get; set; }
        public AppUser Name { get; set; }
    }
}
