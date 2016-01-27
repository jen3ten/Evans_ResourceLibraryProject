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
            //Create Student array which holds student names and resources checked out
            string[,] students = new string[2, 4];      //array for 2 students, change to 5 later
            students[0, 0] = "Joe";
            students[1, 0] = "Mary";
            for (int row = 0; row < 2; row++)
            {
                for (int col = 1; col <= 3; col ++)
                {
                    students[row, col] = " ";        //initialize to 0 resources checked out
                }
            }
            students[0, 1] = "Book";                //assign three resources to Joe for testing
            students[0, 2] = "Book";
            students[0, 3] = "Book";

            //Create Resource array which holds resource names and who it is checked out by
            string[,] resources = new string[3, 2];     //array for 3 resources, change to 10 later
            resources[0, 0] = "Book";
            resources[1, 0] = "CD";
            resources[2, 0] = "Notes";

            for (int row = 0; row < 3; row++)
            {
                for (int col = 1; col <= 1; col++)
                {
                    resources[row, col] = "in";        //initialize to "in" (not checked out)
                }
            }

            //Check elements of student array
            Console.WriteLine("students");
            Console.WriteLine(students[0, 0] + "\t|" + students[0, 1] + "\t|" + students[0, 2] + "\t|" + students[0, 3]+ "\t|");
            Console.WriteLine(students[1, 0] + "\t|" + students[1, 1] + "\t|" + students[1, 2] + "\t|" + students[1, 3] + "\t|");
            Console.WriteLine();

            //Check elements of resource array
            Console.WriteLine("resources");
            Console.WriteLine(resources[0, 0] + "\t|" + resources[0, 1] + "\t|");
            Console.WriteLine(resources[1, 0] + "\t|" + resources[1, 1] + "\t|");
            Console.WriteLine(resources[2, 0] + "\t|" + resources[2, 1] + "\t|");
            Console.WriteLine();

            //Title
            Console.WriteLine("WELCOME TO THE WE CAN CODE IT RESOURCE LIBRARY");
            Console.WriteLine();

            //Print a menu of user options, including letter codes used to access the options
            Console.WriteLine("*****************************************");
            Console.WriteLine("*\tMENU\t\t\t\t*");
            Console.WriteLine("*\t\t\t\t\t*");
            Console.WriteLine("*\t\"S\"\tView Student List\t*");
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
            Console.WriteLine();

            //Switch statement runs code based on option chosen from menu
            int studentRow = 0;
            switch (menuOption.ToUpper())
            {
                case "S":       //View list of students
                    Console.WriteLine("*****************************************");
                    Console.WriteLine("*\tSTUDENT LIST\t\t\t*");
                    Console.WriteLine("*\t\t\t\t\t*");
                    for (int row = 0; row < students.GetLength(0); row++)
                    {
                        Console.WriteLine("*\t"+students[row, 0]+"\t\t\t\t*");
                    }
                    Console.WriteLine("*\t\t\t\t\t*");
                    Console.WriteLine("*****************************************");
                    break;

                case "I":       //View list of available items
                    Console.WriteLine("*****************************************");
                    Console.WriteLine("*\tRESOURCES LIST\t\t\t*");
                    Console.WriteLine("*\t\t\t\t\t*");
                    for (int row = 0; row < resources.GetLength(0); row++)
                    {
                        Console.WriteLine("*\t" + resources[row, 0] + "\t\t\t\t*");
                    }
                    Console.WriteLine("*\t\t\t\t\t*");
                    Console.WriteLine("*****************************************");
                    break;
                case "A":       //View student account
                    Console.Write("Please enter the student's name: ");
                    string studentName = Console.ReadLine().ToUpper();
                    bool noResources = true;
                    bool noStudent = true;
                    for (int row = 0; row < students.GetLength(0); row++)
                    {
                        if (students[row, 0].Equals(studentName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            noStudent = false;
                            Console.WriteLine("*****************************************");
                            Console.WriteLine($"*\t{studentName}'S ACCOUNT\t\t\t*");
                            Console.WriteLine("*\t\t\t\t\t*");
                            for (int col = 1; col < students.GetLength(1); col++)
                            {
                                if (students[row,col] != " ")
                                {
                                    noResources = false;
                                    Console.WriteLine($"*\t{students[row, col]}\t\t\t\t*");
                                }
                            }
                            if (!noResources)
                            {
                                Console.WriteLine("*\t\t\t\t\t*");
                                Console.WriteLine("*****************************************");
                            }
                            break;
                        }
                    }
                    if (noStudent)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Student's name was not found.");
                        noResources = false;
                    }
                    if (noResources)
                    {
                        Console.WriteLine("*\t(no resources checked out)\t*");
                        Console.WriteLine("*\t\t\t\t\t*");
                        Console.WriteLine("*****************************************");
                    }
                    Console.WriteLine();
                    break;
                case "C":       //Checkout item
                    noStudent = true;
                    bool maxItems = true;
                    Console.Write("Please enter the student's name: ");
                    while (noStudent)
                    {
                        studentName = Console.ReadLine().ToUpper();
                        for (int row = 0; row < students.GetLength(0); row++)
                        {
                            if (students[row, 0].Equals(studentName, StringComparison.CurrentCultureIgnoreCase))
                            {
                                noStudent = false;
                                studentRow = row;
                                for (int col = 1; col < students.GetLength(1); col++)
                                {
                                    if(students[row,col] == " ")
                                    {
                                        maxItems = false;
                                        //Move checkout resources to here????
                                    }
                                }
                                if (maxItems)
                                {
                                    Console.WriteLine("The student has checked out a maximum of 3 items.");
                                }
                                break;
                            }
                        }
                        if (noStudent)
                        {
                            Console.Write("The name was not found. Please enter the student's name: ");
                        }
                    }

                    noResources = true;
                    Console.Write("Please enter the resource to be checked out: ");
                    while (noResources)
                    {
                        string resourceOut = Console.ReadLine().ToUpper();
                        for (int row = 0; row < resources.GetLength(0); row++)
                        {
                            if (resources[row, 0].Equals(resourceOut,StringComparison.CurrentCultureIgnoreCase))
                            {
                                noResources = false;
                                if (resources[row,1] == "out")
                                {
                                    Console.WriteLine("The resource is unavailable.");
                                }
                                else
                                {
                                    resources[row, 1] = "out";
                                    students[studentRow, 1] = resources[row, 0];
                                }
                            }
                        }
                        if (noResources)
                        {
                            Console.Write("The item was not found. Please enter the resource name: ");
                        }
                    }
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
