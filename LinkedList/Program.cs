using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<object> list = new LinkedList<object>();

            for (int i = 0; i <= 10; i++)
            {
                list.Add(i);
            }

            list.Add("Partial");
            list.Add("Tormund");
            Console.WriteLine();
                 
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }

            var exceptLIst = new LinkedList<object>();

            exceptLIst.Add(2);
            exceptLIst.Add(6);
            exceptLIst.Add(8);
            exceptLIst.Add(10);  
            exceptLIst.Add("Tormund");  
            
            Console.WriteLine();

            list.Except(list, exceptLIst);

            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }


            Console.WriteLine($"{list[5]}");

            Console.ReadKey();
        }
        
    }


}

