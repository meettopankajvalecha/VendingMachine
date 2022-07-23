using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        internal static List<Coins> _Coins()
        {

            Coins _coin = new Coins()
            {
                id = 1,
                key = "nickels",
                value = 5,
            };

            Coins _coin2 = new Coins()
            {
                id = 2,
                key = "dimes",
                value = 10,
            };

            Coins _coin3 = new Coins()
            {
                id = 3,
                key = "quarters",
                value = 25,
            };

            List<Coins> lstCoins = new List<Coins>();
            lstCoins.Add(_coin);
            lstCoins.Add(_coin2);
            lstCoins.Add(_coin3);

            return lstCoins;
        }


        internal static List<Product> _Product()
        {

            Product _p1 = new Product()
            {
                id = 1,
                key = "cola",
                value = 1, // 1$ = 65
            };

            Product _p2 = new Product()
            {
                id = 2,
                key = "chips",
                value = 0.50, // 32.5
            };

            Product _p3 = new Product()
            {
                id = 3,
                key = "candy",
                value = 0.65, // 42.25
            };

            List<Product> lstProduct = new List<Product>();
            lstProduct.Add(_p1);
            lstProduct.Add(_p2);
            lstProduct.Add(_p3);

            return lstProduct;
        }

        public class Coins
        {
            public int id { get; set; }
            public string key { get; set; }
            public int value { get; set; }
        }

        public class Product
        {
            public int id { get; set; }
            public string key { get; set; }
            public double value { get; set; }
        }

        public static double dollarsToRuppes(double dollars)
        {
            double rupees = dollars * 65;
            return rupees;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Here, 1 doller = 65 Rs");

            var systemCoins = _Coins();
            var systemProducts = _Product();

            foreach (var item in systemCoins)
            {
                Console.WriteLine();
            }
            double totalMoney = 0;

        insertMoney:
            Console.WriteLine("Insert coin type from this list: nickels:1, dimes:2, quarters:3");

            int.TryParse(Console.ReadLine(), out int coinId);

            if (coinId > 0)
            {
                bool IsCoinExisst = systemCoins.Any(x => x.id == coinId);

                if (IsCoinExisst)
                {
                    var amount = systemCoins.Where(x => x.id == coinId).Select(x => x.value).FirstOrDefault();
                    totalMoney += amount;
                }
            }
            else
            {
                Console.WriteLine("Invalid coin inserted");
            }

        AgainAskForMoneyInsert:
            Console.WriteLine("Do you want to insert coin: Y/N");

            string needToinsertCoinAgain = Console.ReadLine();

            if (needToinsertCoinAgain.ToLower().Trim() == "y")
            {
                goto insertMoney;
            }
            else if (needToinsertCoinAgain.ToLower().Trim() != "n")
                goto AgainAskForMoneyInsert;


            Console.WriteLine("You have total money is:" + totalMoney);

        insertProduct:
            Console.WriteLine("Insert product type from this list: cola:1, chips:2, candy:3");
            int.TryParse(Console.ReadLine(), out int productId);

            if (productId > 0)
            {
                bool IsProductExisst = systemProducts.Any(x => x.id == productId);

                if (IsProductExisst)
                {
                    var amount = systemProducts.Where(x => x.id == productId).Select(x => x.value).FirstOrDefault();
                    var productName = systemProducts.Where(x => x.id == productId).Select(x => x.key).FirstOrDefault();
                    if (totalMoney < amount)
                    {
                        Console.WriteLine("Money is not enough. Please insert coin again");
                    }
                    else
                    {
                        Console.WriteLine("{0} is dispensed", productName);
                        Console.WriteLine("THANK YOU");

                        totalMoney -= amount;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid product inserted");
            }

            Console.WriteLine("Do you want to insert prduct: Y/N");

            string needToinsertProductAgain = Console.ReadLine();

            if (needToinsertProductAgain.ToLower() == "y")
            {
                goto insertProduct;
            }

        }
    }
}
