using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ant_War_replica
{
    public class GameState
    {
        public Int64 num_ant;
        public Int64 num_nest;
        public Int64 num_food;

        public int[] ratio = new int[4]; // 0: gatherer, 1: breeder, 2: builder, 3: solder
        
        private Location location = null;

            

        public GameState(Int64 num_ant = 200, Int64 num_nest = 200, Int64 num_food = 300,
            int ratio_gatherer = 25, int ratio_breeder = 25, int ratio_builder = 25, int ratio_solder = 25,
            int index_location = 0)
        {
            this.num_ant = num_ant;
            this.num_nest = num_nest;
            this.num_food = num_food;

            
            this.ratio[0] = ratio_gatherer;
            this.ratio[1] = ratio_breeder;
            this.ratio[2] = ratio_builder;
            this.ratio[3] = ratio_solder;

            ChangeToNewLocation(index_location);
            
        }

        public void ChangeToNewLocation(int index_location)
        {
            switch (index_location)
            {
                case 1:
                    this.location = new HouseGarden();
                    break;
                case 2:
                    this.location = new HouseKitchen();
                    break;
                default:
                    this.location = new HouseYard();
                    break;
            }
        }

        public void next_state()
        {
            Int64 food_change = this.num_ant * this.ratio[0] * 30 / 10000 - this.num_ant / 6;
            Int64 ant_change = this.num_ant * this.ratio[1] * 2 / 10000;// - this.num_ant / 10;
            Int64 nest_change = this.num_ant * this.ratio[2] * 4 / 10000;



            this.num_food += food_change;
            this.num_ant += ant_change;
            this.num_nest += nest_change;
        }
        
    }


}
