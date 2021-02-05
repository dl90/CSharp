using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_02
{
    class Program
    {
        static void Main(string[] args)
        {
            //FoodStoreEntities ctx = new FoodStoreEntities();

            // adding
            //building building = new building() { building_name = "test", unit_num = 123, capacity = 123, stores = { new store() { branch = "abc", region = "abc"} } };
            //ctx.buildings.add(building);
            //ctx.savechanges();

            // modifying
            //var building = ctx.Buildings.Where(b => b.building_name == "test").FirstOrDefault();
            //if (building != null)
            //{
            //    building.capacity += 100;
            //    ctx.SaveChanges();
            //}

            // deleting
            //try {
            //    var building = ctx.Buildings.Where(b => b.building_name == "test").FirstOrDefault();
            //    ctx.Buildings.Remove(building);
            //    ctx.SaveChanges();
            //} catch (Exception e) {
            //    Console.WriteLine(e.Message);
            //}

            // inner join
            //FoodStoreEntities db = new FoodStoreEntities();

            //var query = from s in db.Stores
            //            from b in db.Buildings
            //            where
            //                s.building_name == b.building_name
            //                && s.unit_num == b.unit_num
            //            select new
            //            {             
            //                Branch = s.branch,
            //                Region = s.region,
            //                BuildingName = b.building_name,
            //                UnitNum = b.unit_num,
            //                Capacity = b.capacity
            //            };

            //var query2 = from q1 in query
            //             from e in db.Employees
            //             where e.branch == q1.Branch 
            //             orderby e.last_name, e.first_name
            //             select new
            //             {
            //                 Name = e.first_name + " " + e.last_name,
            //                 q1.Branch,
            //                 q1.Region,
            //                 q1.BuildingName,
            //                 q1.UnitNum,
            //                 q1.Capacity
            //             };


            //foreach (var row in query2)
            //{
            //    Console.WriteLine( row.Name +  " Branch: " + row.Branch
            //                    + ", " + row.Region);
            //    Console.WriteLine("Building: " + row.BuildingName
            //                    + ", unit #" + row.UnitNum
            //                    + ", capacity: " + row.Capacity);
            //    Console.WriteLine();
            //}

            // outer join

            // Reference the database.
            FoodStoreEntities db = new FoodStoreEntities();

            //var query = from s in db.Stores        // Left table.
            //            from i in db.Invoices      // Right table.
            //                .Where(inv => inv.branch == s.branch)    // Join columns.
            //                .DefaultIfEmpty()
            //            select new
            //            {
            //                Branch = s.branch,
            //                Region = s.region,
            //                InvoiceNum = (i.invoiceNum != null) ? i.invoiceNum : 0
            //            };

            //foreach (var item in query)
            //{
            //    Console.Write(item.Branch + " - ");
            //    Console.Write(item.Region + " - ");
            //    Console.WriteLine(item.InvoiceNum);
            //}

            var query = from p in db.Products
                        from m in db.Manufacturers
                            .Where(manufactuere => manufactuere.mfg == p.mfg)
                            .DefaultIfEmpty()
                        select new
                        {
                            ProductName = p.name,
                            Mfg = m.mfg,
                            Discount = m.mfgDiscount
                        };

            foreach (var i in query)
                Console.WriteLine($"{i.ProductName} \t {i.Mfg} \t {i.Discount}");

            Console.ReadKey();
        }
    }
}
