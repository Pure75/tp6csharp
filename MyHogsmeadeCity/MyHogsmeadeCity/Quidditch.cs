using System.Collections.Generic;

namespace MyHogsmeadeCity
{
    public class Quidditch : Building
    {
        public Quidditch(int cost, int money, int beans, int population, int happiness)
        {
            this.cost = cost;
            this.money = money;
            this.beans = beans;
            this.population = population;
            this.happiness = happiness;
        }
        
        public override string[] toString()
        {
            List<string> list = new List<string>();
            list.Add("|>      |>       <|      <|");
            list.Add("|\\     |--|      |--|    /|");
            list.Add("| \\_ __|__|______|__|___/ |");
            list.Add("|------|--|------|--|-----|");
            list.Add("|------|--|------|--|-----|");
            list.Add("|------|--|------|--|-----|");
            list.Add("|______|__|______|__|_____|");
            return list.ToArray();
        }
    }
}