using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesPracticeFilter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 5, 6, 11, 12, 13, 14, 22, 23, 33, 44, 55 };
            int[] evenArray = GetFiltered(array, x => x % 2 == 0);
            int[] notEvenArray = GetFiltered(array, x => !(x % 2 == 0));
            int[] has3Array = GetFiltered(array, x => x.ToString().Contains("3")); 
            int[] hasSameNumberArray = GetFiltered(array, x =>  
            {
                if (x <10)
                    return true;
                else
                    for (int i = 0; i < x.ToString().Length -1; i++)
                    {
                        if (x.ToString()[i] == x.ToString()[i + 1])
                            return true;
                    }
                return false;
            });
            //
            System.Console.WriteLine("Original array items:");
            Print(array);
            System.Console.WriteLine("\n********************");
            System.Console.WriteLine("Even array items:");
            Print(evenArray);
            System.Console.WriteLine("\n********************");
            System.Console.WriteLine("Not even array items:");
            Print(notEvenArray);
            System.Console.WriteLine("\n********************");
            System.Console.WriteLine("Has 3 array items:");
            Print(has3Array);
            System.Console.WriteLine("\n********************");
            System.Console.WriteLine("Has same number array items:");
            Print(hasSameNumberArray);
            System.Console.WriteLine("\n********************");
        }

        public delegate bool filterCondition(int item);

        public static void Print(int[] arr)
        {
            arr.ToList().ForEach(x => Console.WriteLine($"{x.ToString()}, "));
        }

        public static int[] GetFiltered(int[] array, filterCondition filter)
        {
            List<int> result = new List<int>();
            foreach (int x in array)
            {
                if (filter(x))
                {
                    result.Add(x);
                }
            }
            return result.ToArray();
        }
    }
}
