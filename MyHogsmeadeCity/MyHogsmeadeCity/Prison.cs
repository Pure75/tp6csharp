using System.Collections.Generic;

namespace MyHogsmeadeCity
{
    public class Prison : Building, ITaxable
    {
        public Prison(int cost, int money, int beans, int population, int happiness)
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
            list.Add("     | |_| |    | |_| |    ");
            list.Add("     |__|__|____|__|__|    ");
            list.Add("     \\_|__|__|__|__|__/    ");
            list.Add("      |__|__|[]|__|__|     ");
            list.Add("      ||__|__|__|__|_|     ");
            list.Add("      |__|__|[]|__|__|     ");
            list.Add("      ||__|__|__|__|_|     ");
            list.Add("      |__|__|==|__|__|     ");
            list.Add("  ,;.;||__|_|  ||__|_|,;.  ");
            list.Add(",;.;.,|==|==|__|==|==|;,.,.");
            return list.ToArray();
        }
        
        public int LoseMoney()
        {
            return 1;
        }
    }
}