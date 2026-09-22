using System.Threading;
using System.Threading.Tasks;

namespace Warehouse
{
    public static class CompanyMaker
    {
        public static Company CreateKFCCompany()
        {
         
            Company KFC = new Company("KFC", 100000, "Fast food serving food based on fried chicken");
            Console.WriteLine(KFC);

            Dictionary<string, Blueprint> blueprints = new Dictionary<string, Blueprint>();

            //Raw materials
            Blueprint BPHamburgerBun = new Blueprint("hamburger bun", 7, false);
            blueprints.Add("hamburger bun", BPHamburgerBun);

            Blueprint BPLettuce = new Blueprint("lettuce", 5, false);
            blueprints.Add("lettuce", BPLettuce);

            Blueprint BPMayonnaise = new Blueprint("mayonnaise", 3, false);
            blueprints.Add("mayonnaise", BPMayonnaise);

            Blueprint BPBacon = new Blueprint("bacon", 8, false);
            blueprints.Add("bacon", BPBacon);

            Blueprint BPCucumber = new Blueprint("cucumber", 4, false);
            blueprints.Add("cucumber", BPCucumber);

            Blueprint BPChedar = new Blueprint("cheddar", 5, false);
            blueprints.Add("cheddar", BPChedar);

            Blueprint BPOnionRings = new Blueprint("onion rings", 6, false);
            blueprints.Add("onion rings", BPOnionRings);

            Blueprint BPOnion = new Blueprint("onion", 2, false);
            blueprints.Add("onion", BPOnion);

            Blueprint BPNachosSauce = new Blueprint("nachos sauce", 3, false);
            blueprints.Add("nachos sauce", BPNachosSauce);

            Blueprint BPKentuckyGoldSauce = new Blueprint("kentucky gold sauce", 3, false);
            blueprints.Add("kentucky gold sauce", BPKentuckyGoldSauce);

            Blueprint BPBBQSauce = new Blueprint("BBQ sauce", 3, false);
            blueprints.Add("bbq sauce", BPBBQSauce);

            Blueprint BPKetchup = new Blueprint("ketchup", 2, false);
            blueprints.Add("ketchup", BPKetchup);

            Blueprint BPMustard = new Blueprint("mustard", 2, false);
            blueprints.Add("mustard", BPMustard);

            Blueprint BPChickenStrips = new Blueprint("chicken strips", 8, false);
            blueprints.Add("chicken strips", BPChickenStrips);

            Blueprint BPHotWings = new Blueprint("hot wings", 8, false);
            blueprints.Add("hot wings", BPHotWings);

            Blueprint BPFries = new Blueprint("fries", 7, false);
            blueprints.Add("fries", BPFries);

            //Products
            Blueprint BPZinger = new Blueprint("zinger", 125, true);
            blueprints.Add("zinger", BPZinger);

            Blueprint BPDoubleZinger = new Blueprint("double zinger", 159, true);
            blueprints.Add("double zinger", BPDoubleZinger);

            Blueprint BPKentuckyGoldGrander = new Blueprint("kentucky gold grander", 157, true);
            blueprints.Add("kentucky gold grander", BPDoubleZinger);

            Blueprint BPTexasGrander = new Blueprint("texas grander", 137, true);
            blueprints.Add("texas grander", BPTexasGrander);

            Blueprint BPCheeseburger = new Blueprint("cheeseburger", 45, true);
            blueprints.Add("cheeseburger", BPCheeseburger);
           
            Blueprint BPHotWings3 = new Blueprint("hot wings 3", 67, true);
            blueprints.Add("hot wings 3", BPHotWings3);

            Blueprint BPHotWings5 = new Blueprint("hot wings 5", 97, true);
            blueprints.Add("hot wings 5", BPHotWings5);

            Blueprint BPHotWings8 = new Blueprint("hot wings 8", 141, true);
            blueprints.Add("hot wings 8", BPHotWings8);

            Blueprint BPChickenStrips3 = new Blueprint("chicken strips 3", 81, true);
            blueprints.Add("chicken strips 3", BPChickenStrips3);

            Blueprint BPChickenStrips5 = new Blueprint("chicken strips 5", 117, true);
            blueprints.Add("chicken strips 5", BPChickenStrips5);

            Blueprint BPChickenStrips8 = new Blueprint("chicken strips 8", 171, true);
            blueprints.Add("chicken strips 8", BPChickenStrips8);

            Blueprint BPFriesSmallPortion = new Blueprint("fries small portion", 40, true);
            blueprints.Add("fries small portion", BPFriesSmallPortion);

            Blueprint BPFriesNormalPortion = new Blueprint("fries normal portion", 50, true);
            blueprints.Add("fries normal portion", BPFriesNormalPortion);

            Blueprint BPFriesBigPortion = new Blueprint("fries big portion", 60, true);
            blueprints.Add("fries big portion", BPFriesBigPortion);

            Blueprint BPZingerMenu = new Blueprint("zinger menu", 210, true);
            blueprints.Add("zinger menu", BPZingerMenu);

            Dictionary<Blueprint, int> zingerComponents = new Dictionary<Blueprint, int>()
            {
                { BPHamburgerBun, 1 },
                { BPChickenStrips, 1 },
                { BPLettuce, 1 },
                { BPMayonnaise, 1 }
            };

            Dictionary<Blueprint, int> doubleZingerComponents = new Dictionary<Blueprint, int>()
            {
                { BPHamburgerBun, 1 },
                { BPChickenStrips, 2 },
                { BPLettuce, 1 },
                { BPMayonnaise, 1 }
            };

            Dictionary<Blueprint, int> KentuckyGoldGranderComponents = new Dictionary<Blueprint, int>()
            {
                { BPHamburgerBun, 1},
                { BPChickenStrips, 1 },
                { BPBacon, 1 },
                { BPCucumber, 1 },
                { BPChedar, 1 },
                { BPLettuce, 1},
                { BPOnionRings, 1},
                { BPNachosSauce, 1},
                { BPKentuckyGoldSauce, 1}
            };

            Dictionary<Blueprint, int> TexasGranderComponents = new Dictionary<Blueprint, int>()
            {
                { BPHamburgerBun, 1},
                { BPChickenStrips, 1},
                { BPBacon, 1},
                { BPMayonnaise, 1},
                { BPBBQSauce, 1},
                { BPLettuce, 1}
            };

            Dictionary<Blueprint, int> CheeseburgerComponents = new Dictionary<Blueprint, int>()
            {
                { BPHamburgerBun, 1},
                { BPChickenStrips, 1},
                { BPChedar, 1},
                { BPCucumber, 1},
                { BPKetchup, 1},
                { BPMustard, 1}    
            };

            Dictionary<Blueprint, int> HotWings3Components = new Dictionary<Blueprint, int>()
            {
                {BPHotWings, 3}
            };

            Dictionary<Blueprint, int> HotWings5Components = new Dictionary<Blueprint, int>()
            {
                {BPHotWings, 5}
            };

            Dictionary<Blueprint, int> HotWings8Components = new Dictionary<Blueprint, int>()
            {
                {BPHotWings, 8}
            };

            Dictionary<Blueprint, int> ChickenStrips3Components = new Dictionary<Blueprint, int>()
            {
                {BPChickenStrips, 3}
            };

            Dictionary<Blueprint, int> ChickenStrips5Components = new Dictionary<Blueprint, int>()
            {
                {BPChickenStrips, 5}
            };

            Dictionary<Blueprint, int> ChickenStrips8Components = new Dictionary<Blueprint, int>()
            {
                {BPChickenStrips, 8}
            };

            Dictionary<Blueprint, int> FriesSmallPortionComponents = new Dictionary<Blueprint, int>()
            {
                {BPFries, 1}
            };

            Dictionary<Blueprint, int> FriesNormalPortionComponents = new Dictionary<Blueprint, int>()
            {
                {BPFries, 2}
            };

            Dictionary<Blueprint, int> FriesBigPortionComponents = new Dictionary<Blueprint, int>()
            {
                {BPFries, 3}
            };

            Dictionary<Blueprint, int> ZingerMenuComponents = new Dictionary<Blueprint, int>()
            {
                {BPZinger, 1},
                {BPFriesNormalPortion, 1},
            };

            BPZinger.AddComponents(zingerComponents);
            BPDoubleZinger.AddComponents(doubleZingerComponents);
            BPKentuckyGoldGrander.AddComponents(KentuckyGoldGranderComponents);
            BPTexasGrander.AddComponents(TexasGranderComponents);
            BPCheeseburger.AddComponents(CheeseburgerComponents);
            BPHotWings3.AddComponents(HotWings3Components);
            BPHotWings5.AddComponents(HotWings5Components);
            BPHotWings8.AddComponents(HotWings8Components);
            BPChickenStrips3.AddComponents(ChickenStrips3Components);
            BPChickenStrips5.AddComponents(ChickenStrips5Components);
            BPChickenStrips8.AddComponents(ChickenStrips8Components);
            BPFriesSmallPortion.AddComponents(FriesSmallPortionComponents);
            BPFriesNormalPortion.AddComponents(FriesNormalPortionComponents);
            BPFriesBigPortion.AddComponents(FriesBigPortionComponents);
            BPZingerMenu.AddComponents(ZingerMenuComponents);
            
            KFC.SetBlueprints(blueprints);
            return KFC;
        }
    }
}