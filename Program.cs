using System;

namespace TestArray
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            var myArr = new MartixArr(9, 4);
            myArr.ArrayFillRandom(true);

            myArr.PrintArray();

            int step = 0;
            while (myArr.CheckDuplicates() || step < 100)
            {
                myArr.ArrayFillRandom();
                step++;
                Console.WriteLine("fill {0}", step);
            }

            myArr.PrintArray();

            Console.WriteLine("done");

            Console.ReadLine();

         
        }
    }
}
