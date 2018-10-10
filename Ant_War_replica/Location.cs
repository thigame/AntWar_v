using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ant_War_replica
{
    public abstract class Location
    {
        public static String[] LocationName = { "House Yard", "House Garden", "House Kitchen" };
        public Location()
        {

        }

        public virtual Int64 ModifiedFood(Int64 change_food)
        {
            return change_food;
        }

        public virtual Int64 ModifiedAnt(Int64 change_ant)
        {
            return change_ant;
        }

        public virtual Int64 ModifiedNest(Int64 change_nest)
        {
            return change_nest;
        }
    }

    public class HouseYard: Location
    {

    }

    public class HouseGarden: Location
    {
        public override Int64 ModifiedNest(Int64 change_nest)
        {
            return (Int64) (1.1 * change_nest);
        }
    }

    public class HouseKitchen: Location
    {
        public override long ModifiedFood(Int64 change_food)
        {
            return (Int64)(1.1 * change_food);
        }
    }
}
