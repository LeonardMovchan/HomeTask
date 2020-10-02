using System;
using System.Linq;

namespace LinkedList
{
    class Program
    {
        
        static void Main(string[] args)
        {          
            LinkedList<int> list = new LinkedList<int>();

            LinkedList<int> deletedItems = new LinkedList<int>();

            for (int i = 0; i <= 100; i++)
            {
                list.Add(i);
            }
            list.ItemWasRemoved += ItemWasRemoved;

            list.ItemWasRemoved += delegate (int data)
            {                
                deletedItems.Add(data);
            };

            list.RegisterOnMyFilter(EvenNumber);
            //list.RegisterOnMyFilter(NotMoreThan50);
            LinkedList<int> newList = list.FilterMyList(list);
            
            Console.WriteLine();
                     
            foreach (var item in newList)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            foreach (var item in deletedItems)
            {
                Console.Write($"{item} ");
            }
          
            Console.WriteLine();

            Console.ReadKey();           
        }                
        
        public static LinkedList<int> EvenNumber(LinkedList<int> list)
        {
            
            LinkedList<int> newFilteredList = list;

            foreach (var item in newFilteredList)
            {
                if((int)item % 2 == 0)
                {
                   
                    list.Remove((int)item);
                }
            }
            return newFilteredList;

        }
        public static LinkedList<int> NotMoreThan50(LinkedList<int> list)
        {
            LinkedList<int> newFilteredList = list;

            foreach (var item in newFilteredList)
            {
                if ((int)item >= 50)
                {
                    
                    list.Remove((int)item);
                }
            }
            return newFilteredList;
        }
        public static void ItemWasRemoved<T>(T data)
        {
            Console.WriteLine($"Item {data} was removed from the list");
        }

       
    }
}

