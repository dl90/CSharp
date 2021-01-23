using System;
using System.Data;
using Inventory.DB;

namespace Inventory.Classes
{
    class Cash
    {
        private static int ID = 1;

        internal static bool Add(decimal amount)
        {
            if (!Util.CheckValidPrice(amount)) return false;

            decimal currentCashOnHand = CurrentCashOnHand();
            currentCashOnHand += amount;

            return Update(currentCashOnHand);
        }

        internal static bool Subtract(decimal amount)
        {
            if (!Util.CheckValidPrice(amount)) return false;

            decimal currentCashOnHand = CurrentCashOnHand();
            if (currentCashOnHand < amount) return false;
            currentCashOnHand -= amount;

            return Update(currentCashOnHand);
        }


        private static bool Update(decimal newBalance)
        {
            if (!Util.CheckValidPrice(newBalance)) return false;

            string update = "UPDATE Cash SET CashOnHand = @newBalance WHERE Id = @id";
            var updateArgs = new (string, dynamic)[] {
                ("@newBalance", newBalance),
                ("@id", ID)
            };

            return Query.InsertUpdateDeleteQuery(update, updateArgs) == 1;
        }

        internal static decimal CurrentCashOnHand()
        {
            string query = "SELECT * FROM Cash WHERE Id = @id";
            var queryArgs = new (string, dynamic)[] {
                ("@id", ID)
            };

            DataTable dt = Query.PopulateDataTable(query, queryArgs);
            return dt.Rows.Count > 0
                ? Convert.ToDecimal(dt.Rows[0]["CashOnHand"])
                : 0;
        }
    }
}
