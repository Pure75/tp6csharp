using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Channels;

namespace MyHogsmeadeCity
{
    class Game
    {
        private List<Building> buildingList;
       
        private int TotalBeans;
        private int TotalMoney;
        private int TotalPopulation;
        private int TotalHappiness;
       
        private int IncreaseBeans;
        private int IncreaseMoney;
        
        public Game(int money, int beans)
        {
            TotalBeans = beans;
            TotalMoney = money;
            TotalPopulation = 0;
            TotalHappiness = 0;
            IncreaseBeans = 0;
            IncreaseMoney = 0;
            buildingList = new List<Building>();
        }

        public void AddTotal(Building building)
        {
            IncreaseBeans = IncreaseBeans + building.GetBeans();
            IncreaseMoney = IncreaseMoney + building.GetMoney();
            TotalPopulation = TotalPopulation + building.GetPopulation();
            TotalHappiness = TotalHappiness + building.GetHappiness();
        }

        public void AddBuilding(Building building)
        {
            AddTotal(building);
            buildingList.Add(building); 
        }

        public void RemoveBuilding(int index)
        {
            if (index < 0)
            {
                Console.Error.Write("Index should be > 0");
            }
            else if (index > buildingList.Count - 1)
            {
                Console.Error.Write("Index should be < lenght");
            }
            else
            {
                buildingList.RemoveAt(index);
            }
        }

        public void PrintInfo()
        {
            int x = TotalMoney;
            int xg = x / 567;
            x = x - (xg * 567);
            int xs = x / 27;
            int xk = x - (xs * 27);
            int i = IncreaseMoney;
            int ig = i / 567;
            i = i - (ig * 567);
            int ic = i / 27;
            int ik = i - (ic * 567);
            
            Console.WriteLine("You have " + xg + " Galleons , " + xs + " Sickles and " + xk + " Knuts");
            Console.WriteLine("You gain " + ig + " Galleons , " + ic + " Sickles and " + ik + " Knuts per round");
            Console.WriteLine("You have " + TotalBeans + " beans");
            Console.WriteLine("You gain " + IncreaseBeans + " beans per round");
            Console.WriteLine("The rate of happinessis : " + TotalHappiness);
            Console.WriteLine("There are " +  TotalPopulation + " people in your town");
        }

        public void Printcity()
        {
            Console.Clear();
            int y = 0;
            int x = 0;
            int z;
            int cpt = 0;
            foreach (Building building in buildingList)
            {
                if (cpt%3 == 0 && cpt != 0)
                {
                    y = y + 11;
                    x = 0;
                }
                string[] arr = building.toString();
                z = 0;
                if (arr.Length != 10)
                {
                    z += 10 - arr.Length;
                }
                foreach (string ligne in arr)
                { 
                    Console.SetCursorPosition(x, y+z); 
                    Console.WriteLine(ligne); 
                    z++;
                }
                x = x + 28; 
                cpt++;
            }
        }

        public Action GetNextAction()
        {
            Console.WriteLine("What do you want to do ? ...");
            Console.WriteLine("Add | Remove | Print | Nothing | Quit");
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "Add":
                    return Action.ADD;
                case "Remove":
                    return Action.REMOVE;
                case "Print":
                    return Action.PRINT;
                case "Nothing":
                    return Action.NOTHING;
                case "Quit":
                    return Action.QUIT;
                default:
                    return Action.FAIL;
            }
        }
        public Building Construct()
        {
            Console.WriteLine("Which building do you want to construct ? ");
            Console.WriteLine("quidditch | house | prison | shop");
            string bat = Console.ReadLine();
            while (bat != "quidditch" && bat != "house" && bat != "prison" && bat != "shop")
            {
                Console.WriteLine("The building is not available, try again ");
                bat = Console.ReadLine();
            }
            switch (bat)
            {
                case "quidditch":
                    TotalBeans = TotalBeans - 5;
                    return (new Quidditch(5,5,5,5,5));
                case "house":
                    TotalBeans = TotalBeans - 2;
                    return new House(2,2,2,2,2);
                case "prison":
                    TotalBeans = TotalBeans - 3;
                    return new Prison(3,3,3,3,3);
                default: // Shop
                    TotalBeans = TotalBeans - 4;
                    return new Shop(4,4,4,4,4);
            }
        }
        
        public void Destroy()
        {
            int res;
            int t = buildingList.Count - 1;
            string index;
            do
            {
                Console.WriteLine("Which building do you want to destroy ?");
                Console.WriteLine("Write a number from 0 to {0}", t);
                index = Console.ReadLine();
            } while (!Int32.TryParse(index, out res) || res < 0 || res > t);
            RemoveBuilding(res);
        }
        public void DestroyRandomBuilding()
        { 
            int x = buildingList.Count - 1;
            if(TotalMoney < 0 || TotalBeans < 0)
            {
                if (x >= 0)
                {
                    Random random = new Random();
                    int i = random.Next(x);
                    RemoveBuilding(i);
                }
            }
        }
        
        public bool Update()
        {
            int count = buildingList.Count - 1;
            while (TotalBeans >= 0 || TotalMoney >= 0 || count >= 0)
            {
                switch (GetNextAction())
                {
                    case Action.ADD:
                        Building x = Construct();
                        AddBuilding(x);
                        TotalMoney += IncreaseMoney;
                        TotalBeans += IncreaseBeans;
                        break;
                    case Action.REMOVE:
                        if (buildingList.Count == 0)
                        {
                            Console.WriteLine("You don't have any buildings");
                            break;
                        }
                        Destroy();
                        TotalMoney += IncreaseMoney;
                        TotalBeans += IncreaseBeans;
                        break;
                    case Action.QUIT:
                        return true;
                    case Action.PRINT:
                        Printcity();
                        PrintInfo();
                        break;
                    default:
                        TotalMoney += IncreaseMoney;
                        TotalBeans += IncreaseBeans;
                        break;
                }
                DestroyRandomBuilding();
                Random montant = new Random();
                foreach (var building in buildingList) 
                {
                        if ((building) is House && montant.Next(5) == 3)
                        {
                            TotalMoney = TotalMoney - ((House) building).LoseMoney();
                        }
                        else if ((building) is Prison && montant.Next(5) == 3)
                        {
                           TotalMoney = TotalMoney - ((Prison) building).LoseMoney();
                        }
                }
            }
            return true;
        }
    }

    public enum Action
    {
        ADD,
        REMOVE,
        PRINT,
        QUIT,
        NOTHING,
        FAIL
    }
    
}