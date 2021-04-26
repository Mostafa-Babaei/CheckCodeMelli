using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMelli
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Check Exist And Correct CodeMelli ...");
            Console.WriteLine("For Exit Press X ");
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("******************** ");
                Console.WriteLine("Please Enter Your Code ...");
                Console.WriteLine("******************** ");
                Console.WriteLine("");


                string temp = Console.ReadLine();
                if (temp.ToUpper() == "X")
                    Environment.Exit(0);

                //بررسی 10 رقمی بودن رشته دریافتی
                if (temp.Length == 10)
                {
                    int n;
                    bool isNumeric = int.TryParse(temp, out n);
                    //بررسی عدد بودن رشته دریافتی
                    if (isNumeric)
                    {
                        //بررسی صحت کد ملی
                        if (CheckCodeMelli(temp))
                            Console.WriteLine("Success \n" + temp + "\n Correct Code");
                        else
                            Console.WriteLine("Failed \n" + temp + "\n InCorrect Code");
                    }
                    else
                        Console.WriteLine("Your Code just Digit , Please enter Correct Number  ...");
                }
                else
                    Console.WriteLine("Your Code Must 10 Digit , Please enter Correct Number  ...");



            }


        }

        /// <summary>
        /// تابع بررسی صحت کد ملی
        /// </summary>
        /// <param name="codemelli"></param>
        /// <returns></returns>
        public static bool CheckCodeMelli(string codemelli)
        {
            int[] ints = codemelli.Select(n => Convert.ToInt32(n - '0')).ToArray();
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (ints[i] * (10-i));
            int checksum = sum % 11;
            if (checksum < 2)
                return (ints[9] == checksum ? true : false);
            else
                return ((11-ints[9]) == checksum ? true : false);
        }
    }
}
