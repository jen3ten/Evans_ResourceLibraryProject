using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_ProjectWeek_ResourceCheckout
{
    class Program
    {
        static void Main(string[] args)
        {
            //Title
            Console.WriteLine("WELCOME TO THE WE CAN CODE IT RESOURCE LIBRARY");
            Console.WriteLine();

            //Print a menu of user options, including letter codes used to access the options
            Console.WriteLine("*****************************************");
            Console.WriteLine("*\t\tMENU\t\t\t*");
            Console.WriteLine("*\t\t\t\t\t*");
            Console.WriteLine("*\t\"S\"\tView Students\t\t*");
            Console.WriteLine("*\t\"I\"\tView Available Items\t*");
            Console.WriteLine("*\t\"A\"\tView Student Accounts\t*");
            Console.WriteLine("*\t\"C\"\tCheckout Item\t\t*");
            Console.WriteLine("*\t\"R\"\tReturn Item\t\t*");
            Console.WriteLine("*\t\"X\"\tExit\t\t\t*");
            Console.WriteLine("*\t\t\t\t\t*");
            Console.WriteLine("*****************************************");
            Console.WriteLine();
            Console.Write("How may I help you? (Please enter letter code) ");
            string menuOption = Console.ReadLine();

            //Test user input as valid menu option
            switch (menuOption.ToUpper())
            {
                case "S":       //View list of students
                    Console.WriteLine("View list of students");
                    break;
                case "I":       //View list of available items
                    Console.WriteLine("View list of available items");
                    break;
                case "A":       //View student account
                    Console.WriteLine("View student account");
                    break;
                case "C":       //Checkout item
                    Console.WriteLine("Checkout item");
                    break;
                case "R":       //Return item
                    Console.WriteLine("Return item");
                    break;
                case "X":       //Exit
                    Console.WriteLine("Exit");
                    break;
                default:        //Menu option was not found
                    Console.WriteLine("The code you entered was not found.  Please enter a valid code.");
                    //Run menu method
                    break;
            }

            Console.Write("Try again? ");
            char runAgain = char.Parse(Console.ReadLine());
            if (runAgain == 'Y' || runAgain == 'y' )
            {
                Main(args);
            }

        }
    }
}
