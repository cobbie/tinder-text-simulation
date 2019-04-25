// Quintos, Jacob Uriel R. // 161613
// 11/14/2017
// I have not discussed the C# language
// code in my program with anyone other than my instructor or the
// teaching assistants assigned to this course.
// I have not used C# language code
// obtained from another person, or any other unauthorized source,
// either modified or unmodified.
// Any C# language code or documentation
// used in my program that was obtained from another source, such as
// a text book, a web page, or another person, have been clearly
// noted with proper citation in the comments of my program.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Project1Quintos161613
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Function func = new Function();
            int choice;
            do
            {
                Console.Write("\n=====WELCOME TO TINDER!=====" +
                                     "\n1 for Register" +
                                     "\n2 for Login" +
                                     "\n0 to QUIT" +
                                     "\nEnter choice: ");

              choice = int.Parse(Console.ReadLine());



                if (choice == 1)
                {

                    func.RegisterUser();
                }

                else if (choice == 2)
                {
                    func.LoginUser();
                }

            } while (choice != 0);
            Console.ReadLine();
        }
    }
}
