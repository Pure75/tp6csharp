using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace MyHogsmeadeCity
{
    class House : Building, ITaxable
    {
        public House(int cost, int money, int beans, int population, int happiness)
        {
            this.cost = cost;
            this.money = money;
            this.beans = beans;
            this.population = population;
            this.happiness = happiness;
        }



        public override string[] toString()
        {
            string[] arr =
            {
                ("  _______________________  "),
                (" / , , , , , , , , , , , \\ "),
                ("/_________________________\\"),
                ("|| _____ ____            ||"),
                ("|| | | | ||||            ||"),
                ("|| | | | ||||            ||"),
                ("|| ----- ||||            ||"),
                ("||       ----            ||")
            };
            return arr;
        }

        public int LoseMoney()
        {
            return 2;
        }
    }
}