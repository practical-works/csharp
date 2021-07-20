using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace LINQ_TP
{
    public partial class Exercises
    {
        public static void Ex21()
        {
            Console.Clear();
            Console.WriteLine("[Passing the start index and number of elements]");
            List<char> list = new List<char>() { 'm', 'n', 'o', 'p', 'q' };
            Console.WriteLine("Here is the list of items :");
            list.ForEach(item => Console.WriteLine(list.IndexOf(item) + " : " + item));
            int startIndex = 1, itemsNumber = 3;
            Console.WriteLine("Here is the list after removing the {0} items starting from the item index {1} from the list :", itemsNumber, startIndex);
            list.RemoveRange(startIndex, itemsNumber);
            list.ForEach(item => Console.WriteLine(list.IndexOf(item) + " : " + item));
        }
        public static void Ex22()
        {
            ArrayList words = new ArrayList() { "this", "is", "a", "string" };
            int minLength = 5;
            Console.WriteLine("Array of {0} strings :", words.Count);
            words.OfType<string>().ToList().ForEach(w => Console.WriteLine("\t" + words.IndexOf(w) + " : " + w));
            Console.WriteLine("The items of minimum {0} characters are :", minLength);
            //IEnumerable<string> query = from w in words.OfType<string>()
            //                            where w.Length >= minLength
            //                            select w;
            IEnumerable<string> query = words.OfType<string>().Where(w => w.Length >= minLength);
            query.ToList().ForEach(w => Console.WriteLine("\t" + words.IndexOf(w) + " : " + w));
        }
        public static void Ex23()
        {
            Console.WriteLine();
            List<char> letterList = new List<char>() { 'X', 'Y', 'Z' };
            List<int> numberList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine("List of Letters :");
            letterList.ForEach(l => Console.Write(" " + l + " "));
            Console.WriteLine();
            Console.WriteLine("List of Numbers :");
            numberList.ForEach(n => Console.Write(" " + n + " "));
            Console.WriteLine();
            Console.WriteLine("Cartesian Product of Lists :");
            //var query = from l in letterList
            //            from n in numberList
            //            select new { letterList = l, numberList = n };
            //----------------------------------------------------------------
            //var query = letterList.SelectMany(n => numberList, (l, n) => new { letterList = l, numberList = n });
            var query = letterList.SelectMany(l => numberList.Select(n => new { letterList = l, numberList = n }));
            query.ToList().ForEach(o => Console.WriteLine(o));
            Console.WriteLine();
        }
        public static void Ex24()
        {
            Console.WriteLine();
            List<char> letterList = new List<char>() { 'X', 'Y', 'Z' };
            List<int> numberList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            List<Color> colorList = new List<Color>() { Color.Red, Color.Green, Color.Blue };
            //======================================================
            Console.WriteLine("List of Letters :");
            letterList.ForEach(x => Console.Write("\t" + x + " "));
            Console.WriteLine();
            //======================================================
            Console.WriteLine("List of Numbers :");
            numberList.ForEach(x => Console.Write("\t" + x + " "));
            Console.WriteLine();
            //======================================================
            Console.WriteLine("List of Colors :");
            colorList.ForEach(x => Console.Write("\t" + x.Name + " "));
            Console.WriteLine();
            //======================================================
            Console.WriteLine("Cartesian Product of Lists :");
            //var query = from l in letterList
            //            from n in numberList
            //            from c in colorList
            //            select new { letter = l, number = n, colour = c.Name };
            var query = letterList.SelectMany (
                    l => numberList.Select(n => new { letter = l, number = n })
                ).SelectMany(
                    ln => colorList.Select(c => new { letter = ln.letter, number = ln.number, colour = c.Name })
                );
            query.ToList().ForEach(o => Console.WriteLine("\t" + o));
            //======================================================
        }
#region
        class Item
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        class Purchase
        {
            public int No { get; set; }
            public int Quantity { get; set; }
            public int ItemID { get; set; }
        }
        static List<Item> itemList = new List<Item>()
        {
            new Item() { ID = 1, Name = "Biscuit" },
            new Item() { ID = 2, Name = "Chocolate" },
            new Item() { ID = 3, Name = "Butter" },
            new Item() { ID = 4, Name = "Bread " },
            new Item() { ID = 5, Name = "Honey " },
            new Item() { ID = 6, Name = "X-PRO     " }
        };
        static List<Purchase> purchaseList = new List<Purchase>()
        {
            new Purchase() { No = 100, ItemID = 3, Quantity = 800 },
            new Purchase() { No = 101, ItemID = 2, Quantity = 650 },
            new Purchase() { No = 102, ItemID = 3, Quantity = 900 },
            new Purchase() { No = 103, ItemID = 4, Quantity = 700 },
            new Purchase() { No = 104, ItemID = 3, Quantity = 900 },
            new Purchase() { No = 105, ItemID = 4, Quantity = 650 },
            new Purchase() { No = 106, ItemID = 1, Quantity = 458 }
        };
        static void WriteItemList()
        {
            Console.WriteLine("\nItems list :");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Item ID \tItem Name");
            Console.WriteLine("--------------------------");
            itemList.ForEach(item => Console.WriteLine("  " + item.ID + "\t\t" + item.Name));
        }
        static void WritePurchaseList()
        {
            Console.WriteLine("\nPurchases list :");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Purchase No \tItem ID \tPurchase Quantity");
            Console.WriteLine("--------------------------------------------------");
            purchaseList.ForEach
                (
                    purchase => Console.WriteLine("  " + purchase.No + "\t\t  " + purchase.ItemID 
                        + "\t\t  " + purchase.Quantity)
                );
        }
#endregion
        public static void Ex25()
        {
            WriteItemList();
            WritePurchaseList();
            //var query = from item in itemList
            //            join purchase in purchaseList on item.ID equals purchase.ItemID
            //            select new 
            //            { 
            //                ItemID = item.ID, 
            //                ItemName = item.Name, 
            //                PurchaseQuantity = purchase.Quantity 
            //            };
            var query = itemList.Join(purchaseList,
                item => item.ID, purchase => purchase.ItemID,
                (item, purchase) => new
                        {
                            ItemID = item.ID,
                            ItemName = item.Name,
                            PurchaseQuantity = purchase.Quantity
                        });
            Console.WriteLine("\nPurchased Items list :");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Item ID \tItem Name \tPurchase Quantity");
            Console.WriteLine("--------------------------------------------------");
            foreach (var itemPurchase in query)
            {
                Console.WriteLine("  " +
                        itemPurchase.ItemID + "\t\t  " +
                        itemPurchase.ItemName + "\t " +
                        itemPurchase.PurchaseQuantity);
            }
        }
        public static void Ex26()
        {
            //var query = from item in itemList
            //            join purchase in purchaseList on item.ID equals purchase.ItemID
            //            into purchases
            //            select new 
            //            { 
            //                ItemID = item.ID,
            //                ItemName = item.Name,
            //                Purchases = purchases
            //            };
            var query = itemList.GroupJoin(purchaseList, 
                item => item.ID, purchase => purchase.ItemID,
                (item, purchases) => new
                        {
                            ItemID = item.ID,
                            ItemName = item.Name,
                            Purchases = purchases // Get full purchases objects list
                            // For onley quantities : Purchases = purchases.Select(p => p.Quantity)
                        });
            Console.WriteLine("\nPurchased Items list (All Items) :");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Item ID \tItem Name \tPurchase Quantity");
            Console.WriteLine("--------------------------------------------------");
            foreach (var itemPurchase in query)
            {
                foreach (Purchase purchase in itemPurchase.Purchases.DefaultIfEmpty(new Purchase()))
                {
                    Console.WriteLine("  " +
                        itemPurchase.ItemID + "\t\t  " +
                        itemPurchase.ItemName + "\t " +
                        purchase.Quantity);
                }
            }
        }
        public static void Ex27()
        {
            //var query = from purchase in purchaseList
            //            join item in itemList on purchase.ItemID equals item.ID
            //            into items
            //            from i in items.DefaultIfEmpty(new Item())
            //            select new
            //            {
            //                ItemID = i.ID,
            //                ItemName = i.Name,
            //                PurchaseQuantity = purchase.Quantity
            //            };
            var query = purchaseList.GroupJoin(itemList,
                purchase => purchase.ItemID, item => item.ID,
                (purchase, items) => items.Select(i => new
                    {
                        ItemID = i.ID,
                        ItemName = i.Name,
                        PurchaseQuantity = purchase.Quantity
                    }));
            Console.WriteLine("\nPurchased Items list (All Purchases) :");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Item ID \tItem Name \tPurchase Quantity");
            Console.WriteLine("--------------------------------------------------");
            foreach (var o in query)
            {
                foreach (var itemPurchase in o)
                {
                    Console.WriteLine("  " +
                        itemPurchase.ItemID + "\t\t  " +
                        itemPurchase.ItemName + "\t " +
                        itemPurchase.PurchaseQuantity);
                }
            }
        }
        #region
        static ArrayList cities = new ArrayList() 
        { 
            "ROME",
            "LONDON",
            "NAIROBI",
            "CALIFORNIA",
            "ZURICH",
            "NEW DELHI",
            "AMSTERDAM", 
            "ABU DHABI",
            "PARIS",
            "NEW YORK" 
        };
        static void WriteCities()
        {
            Console.WriteLine("List of cities :");
            foreach (object city in cities)
            {
                Console.WriteLine("   " + city);
            }
        }
        #endregion
        public static void Ex28()
        {
            WriteCities();
            //-----------------------------------------------------------
            // ♦ Using Sort() Method and delegate
            //-----------------------------------------------------------
            // ♦ Long syntax
            //List<string> citiesSorted = cities.OfType<string>().ToList();
            //citiesSorted.Sort(delegate(string a, string b)
            //{
            //    if (a.Length == b.Length)
            //    {
            //        if (a.Equals(b, StringComparison.Ordinal))
            //            return 0;
            //        else if (a.CompareTo(b) == 1)
            //            return 1;
            //        else
            //            return -1;
            //    }
            //    else if (a.Length > b.Length)
            //        return 1;
            //    else
            //        return -1;
            //});
            // ♦ Simplified syntax alternative
            //citiesSorted.Sort((a, b) =>
            //{
            //    if (a.Length == b.Length)
            //    {
            //        return a.CompareTo(b);
            //    }
            //    else
            //    {
            //        return a.Length.CompareTo(b.Length);
            //    }
            //});
            //-----------------------------------------------------------
            // ♦ Using LINQ query
            //-----------------------------------------------------------
            //IEnumerable<string> query = from city in cities.OfType<string>()
            //                            orderby city.Length, city
            //                            select city;
            IEnumerable<string> query = cities.OfType<string>().OrderBy(city => city.Length).ThenBy(city => city);
            Console.WriteLine("List of cities (Sorted) :");
            query.ToList().ForEach(city => Console.WriteLine("   " + city));
        }
        public static void Ex29()
        {
            Console.WriteLine("List of cities (grouped) :");
            //IEnumerable<IGrouping<int, object>> query = from i in Enumerable.Range(0, cities.Count)
            //                                            group cities[i] by i/3;
            //IEnumerable<IGrouping<int, object>> query = from city in cities.OfType<string>()
            //                                            group city by cities.IndexOf(city)/3;
            IEnumerable<IGrouping<int, object>> query = cities.OfType<string>().GroupBy(city => cities.IndexOf(city) / 3);
            query.ToList().ForEach(citiesGroup => 
                { 
                    Console.WriteLine(citiesGroup.Key);
                    citiesGroup.ToList().ForEach(city => Console.WriteLine("   " + city));
                });
        }
        public static void Ex30()
        {
            Console.WriteLine("=============================================");
            List<string> list = new List<string> { "Honey", "Biscuit", "Honey", "Butter", "Bread", "Biscuit" };
            list.ForEach(item => Console.WriteLine(item));
            //IEnumerable<string> query = (from item in list
            //                            orderby item
            //                            select item).Distinct();
            IEnumerable<string> query = list.OrderBy(item => item).Distinct();
            Console.WriteLine();
            query.ToList().ForEach(item => Console.WriteLine(item));
        }
    }
}
