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
            FoodStoreEntities ctx = new FoodStoreEntities();

            //building building = new building() { building_name = "test", unit_num = 123, capacity = 123, stores = { new store() { branch = "abc", region = "abc"} } };
            //ctx.buildings.add(building);
            //ctx.savechanges();

            //var building = ctx.Buildings.Where(b => b.building_name == "test").FirstOrDefault();
            //if (building != null)
            //{
            //    building.capacity += 100;
            //    ctx.SaveChanges();
            //}

            try
            {
                var building = ctx.Buildings.Where(b => b.building_name == "test").FirstOrDefault();
                ctx.Buildings.Remove(building);
                ctx.SaveChanges();
            }
             catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (var b in ctx.Buildings)
                Console.WriteLine($"{b.building_name} {b.unit_num} {b.capacity}");

            Console.ReadKey();
        }
    }
}
