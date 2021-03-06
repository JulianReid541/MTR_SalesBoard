﻿using System.Collections.Generic;
using System.Linq;

namespace MTRSalesBoard.Models.Repository
{
    public class FakeRepository : IRepository
    {
        // Fake repsository used for XUnit tests
        #region Properties
        private List<AppUser> usersList = new List<AppUser>();
        private List<Sale> salesList = new List<Sale>();
        public List<AppUser> Users { get { return usersList; } }
        public List<Sale> Sales { get { return salesList; } }
        #endregion

        #region Methods
        public void AddUser(AppUser u) {
            Users.Add(u);
        }

        public AppUser FindAppUserbyName(string Name) {
            AppUser u = Users.Find(u2 => u2.Name == Name);
            return u;
        }

        public void AddSale(Sale s) {
            Sales.Add(s);
        }

        public void AddSale(Sale s, AppUser u) { }

        public int EditSale(Sale s) { return 0; }
        public void DeleteSale(int id) { }

        public void DeleteUser(AppUser u) { }

        public int GetUserCount() {
            return Users.Count();
        }

        public int GetSalesCount() {
            return Sales.Count();
        }

        public decimal CalcTotalSales() {
            decimal amt = 0;
            foreach (Sale s in Sales) {
                amt += s.SaleAmount;
            }

            return amt;
        }

        public Sale FindSaleById(int id) {
            Sale s = Sales.First(s1 => s1.SaleID == id);
            return s;
        }

        public decimal CalcMonthYearSales(decimal month, decimal year) { return 0; }
        public decimal CalcMonthLastYearSales() { return 0; }
        public decimal CalcLastYearSales() { return 0; }
        public decimal CalcTodaySales() { return 0; }
        #endregion
    }
}
