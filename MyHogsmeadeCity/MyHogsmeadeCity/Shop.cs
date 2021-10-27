using System.Collections.Generic;

namespace MyHogsmeadeCity
{
    public class Shop : Building
    {
        public Shop(int cost, int money, int beans, int population, int happiness)
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
            list.Add(" _________________________ ");
            list.Add("/| |  |   | / \\ |   |  | |\\");
            list.Add("_|_|__|___|/   \\|___|__|_|_");
            list.Add("-|  |-|-| |- n.-| |-| |  |-");
            list.Add(" |- |-|-| |  O/ | |-| | -| ");
            list.Add("-|  |_|_| |_/|__|  _  |  |-");
            list.Add(" |- |-|-| |-,|,-| |x| | -| ");
            list.Add("-|  |-|-| | | | | |_| |  |-");
            return list.ToArray();
        }
    }
}