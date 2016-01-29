using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4_ProjectWeek_ResourceCheckout
{
    class Program
    {
        static void mainMenu()
        {
            //Turn the menu section below into a method???
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
        }

        static void Main(string[] args)
        {
            //Create Students array which holds student names
            string[] students = { "Abbey", "Brian", "Charlie", "Delaney", "Erin" };
            Array.Sort(students);

            //Create Accounts arrays for each student which holds checked out items
            //Set initial value to empty string
            string[] account0 = { "", "", "" };  
            string[] account1 = { "", "", "" };
            string[] account2 = { "", "", "" };
            string[] account3 = { "", "", "" };
            string[] account4 = { "", "", "" };
            string[] studentAccount = new string[3];

            //Create Resource array which holds resource names
            //string[] resources = { "Database Design", "SQL Queries", "JavaScript", "C# for Dummies", "C# Player's Guide", "HTML & CSS", "Agile Methodology", "Scrum 101", "Hooray for Arrays!", "Getting Along with Git" };
            string[] resources = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };
            Array.Sort(resources);

            //Create Checkout array which holds flag showing whether resource is checked "out" or "in".
            //if checkedOut = true then book is checked out
            //if checkedOut = false then book has not been checked out
            bool[] checkedOut = {false, false, false, false, false, false, false, false, false, false};

            bool exitPressed = false;       //Set flag to monitor when exit button is pressed

            //Title
            Console.WriteLine("WELCOME TO THE WE CAN CODE IT RESOURCE LIBRARY");
            Console.WriteLine();

            //While loop to run code as long as exit is not pressed?
            do
            {
            mainMenu(); //call main menu method
            string menuOption = Console.ReadLine();
            Console.WriteLine();

            //Switch statement runs code based on option chosen from menu
            int studentRow = 0;
            switch (menuOption.ToUpper())
            {
                case "S":       //View list of studentsAcct
                    Console.WriteLine("*****************************************");
                    Console.WriteLine("*\tSTUDENT LIST\t\t\t*");
                    Console.WriteLine("*\t\t\t\t\t*");
                    foreach (string student in students)
                    {
                        Console.WriteLine("*\t" + student + "\t\t\t\t*");
                    }
                    Console.WriteLine("*\t\t\t\t\t*");
                    Console.WriteLine("*****************************************");
                    break;

                case "I":       //View list of available items
                    Console.WriteLine("*****************************************");
                    Console.WriteLine("*\tRESOURCES LIST\t\t\t*");
                    Console.WriteLine("*\t\t\t\t\t*");
                        //int bookIndex = -1;
                    int bookIndex = Array.IndexOf(checkedOut, false);
                    while (bookIndex != -1)
                    {
                        bookIndex = Array.IndexOf(checkedOut, false, bookIndex + 1);
                        if (bookIndex > -1)
                            Console.WriteLine("*\t" + resources[bookIndex] + "\t\t\t\t*");
                    }
                        bookIndex = -1;//for test
                    if (bookIndex == -1)
                    {
                        Console.WriteLine("*\t(All resources checked out)\t*");
                        //break;
                    }
                    Console.WriteLine("*\t\t\t\t\t*");
                    Console.WriteLine("*****************************************");
                    break;

                case "A":       //View student account
                    Console.Write("Please enter the student's name: ");
                    string studentName = Console.ReadLine().ToUpper();
                    int index = 0;            //counts which index I am on
                    //int index = -1;             //index saves the index value of the 
                    foreach (string name in students)
                    {
                        //Console.WriteLine(name);
                        if (name.Equals(studentName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            //Console.WriteLine($"{name} is a match. Index is {index}");
                            //index number will be used to reference student
                            break;      //break out of loop when student name is found
                        }
                        index++;
                    }
                    switch (index)
                    {
                        case 0:
                            studentAccount = account0;
                            break;
                        case 1:
                            studentAccount = account1;
                            break;
                        case 2:
                            studentAccount = account2;
                            break;
                        case 3:
                            studentAccount = account3;
                            break;
                        case 4:
                            studentAccount = account4;
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Student's name was not found.");
                            break;
                    }
                    if (index <= 4)         //If the user name is found, search for their resources
                    {
                        bool noResources = true;
                        Console.WriteLine("*****************************************");
                        Console.WriteLine($"*\t{studentName}'S ACCOUNT\t\t\t*");
                        Console.WriteLine("*\t\t\t\t\t*");

                        foreach (string item in studentAccount)
                        {
                            if (item != "")
                            {
                                Console.WriteLine($"*\t{item}\t\t\t\t*");
                                noResources = false;
                            }
                        }
                        if (noResources)
                            Console.WriteLine("*\t(No resources checked out)\t*");

                        Console.WriteLine("*\t\t\t\t\t*");
                        Console.WriteLine("*****************************************");
                    }
                    break;

                case "C":       //Checkout item
                    Console.Write("Please enter the student's name: ");
                    studentName = Console.ReadLine().ToUpper();
                    int nameIndex = 0;
                    foreach (string name in students)
                    {
                        //Console.WriteLine(name);
                        if (name.Equals(studentName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            //index number will be used to reference student
                            break;      //break out of loop when student name is found
                        }
                        nameIndex++;
                    }
                    switch (nameIndex)
                    {
                        case 0:
                            studentAccount = account0;
                            break;
                        case 1:
                            studentAccount = account1;
                            break;
                        case 2:
                            studentAccount = account2;
                            break;
                        case 3:
                            studentAccount = account3;
                            break;
                        case 4:
                            studentAccount = account4;
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Student's name was not found.");
                            break;
                    }
                    int checkNumItems = 0;
                    if (nameIndex <= 4)   //If the user name is found, see if they checked out 3 items
                    {
                        checkNumItems = Array.IndexOf(studentAccount, "");
                        if (checkNumItems == -1)
                        {
                            Console.WriteLine("The student has checked out a maximum of 3 items.");
                        }
                        else
                        {
                            int resIndex = 0;
                            Console.Write("Please enter the resource to be checked out: ");
                            string resourceOut = Console.ReadLine();
                            //Console.WriteLine(resourceOut);
                            foreach (string item in resources)
                            {
                                //Console.WriteLine(item);
                                if (item.Equals(resourceOut, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    //Console.WriteLine($"I found {item}");

                                    //index number will be used to reference resource
                                    break;      //break out of loop when resource name is found
                                }
                                resIndex++;
                            }
                            if (resIndex == 10)
                            {
                                Console.WriteLine("Resource name has not been found.");
                            }
                            else if (checkedOut[resIndex])
                            {
                                Console.WriteLine($"I'm sorry, {resourceOut} has already been checked out.");
                            }
                            else if (!checkedOut[resIndex])
                            {
                                Console.WriteLine($"{students[nameIndex]} checked out {resourceOut}.");
                                checkedOut[resIndex] = true;                //Set the value of the checkedOut array to true to designate item has been checked out
                                //Console.WriteLine($"{resIndex} is the resource index.");
                                switch (nameIndex)
                                {
                                    case 0:
                                        //studentAccount = account0;
                                        account0[checkNumItems] = resourceOut;
                                        //Console.WriteLine($"0 student Abbey checked out {resourceOut}");
                                        break;
                                    case 1:
                                        //studentAccount = account1;
                                        account1[checkNumItems] = resourceOut;
                                        break;
                                    case 2:
                                        // studentAccount = account2;
                                        account2[checkNumItems] = resourceOut;
                                        break;
                                    case 3:
                                        //studentAccount = account3;
                                        account3[checkNumItems] = resourceOut;
                                        break;
                                    case 4:
                                        //studentAccount = account4;
                                        account4[checkNumItems] = resourceOut;
                                        break;
                                    default:
                                        //Console.WriteLine();
                                        //Console.WriteLine("Student's name was not found.");
                                        break;
                                }
                            }
                        }    
                    }
                    Console.WriteLine();
                    break;

                case "R":       //Return item
                    //Console.WriteLine("Return item");
                    Console.Write("Please enter the student's name: ");
                    studentName = Console.ReadLine().ToUpper();
                    nameIndex = 0;
                    foreach (string name in students)
                    {
                        //Console.WriteLine(name);
                        if (name.Equals(studentName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            //index number will be used to reference student
                            break;      //break out of loop when student name is found
                        }
                        nameIndex++;
                    }
                    switch (nameIndex)
                    {
                        case 0:
                            studentAccount = account0;
                            break;
                        case 1:
                            studentAccount = account1;
                            break;
                        case 2:
                            studentAccount = account2;
                            break;
                        case 3:
                            studentAccount = account3;
                            break;
                        case 4:
                            studentAccount = account4;
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Student's name was not found.");
                            break;
                    }
                    checkNumItems = 0;
                    Array.Sort(studentAccount);
                    if (nameIndex <= 4)   //If the user name is found, see if they checked out any items
                    {
                        checkNumItems = Array.LastIndexOf(studentAccount, "");
                        if (checkNumItems == studentAccount.Length - 1)
                        {
                            Console.WriteLine("The student has not checked out any items.");
                        }
                        else
                        {
                            int resIndex = 0;
                            Console.Write("Please enter the resource to be returned: ");
                            string resourceIn = Console.ReadLine();
                            //Console.WriteLine(resourceIn);
                            foreach (string item in resources)
                            {
                                //Console.WriteLine(item);
                                if (item.Equals(resourceIn, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    //Console.WriteLine($"I found {item}");

                                    //index number will be used to reference resource
                                    break;      //break out of loop when resource name is found
                                }
                                resIndex++;
                            }
                            if (resIndex == 10)
                            {
                                Console.WriteLine("Resource name has not been found.");
                            }
                            //else if (checkedOut[resIndex])
                            //{
                            //    Console.WriteLine($"I'm sorry, {resourceIn} has already been checked out.");
                            //}
                            //else if (!checkedOut[resIndex])
                            //{
                            //    Console.WriteLine($"{students[nameIndex]} checked out {resourceIn}.");
                            checkedOut[resIndex] = false;                //Set the value of the checkedOut array to false to designate item is available
                                                                         //Console.WriteLine($"{resIndex} is the resource index.");
                                int itemIndex = 0;
                            foreach (string item in studentAccount)
                                {
                                    if (item.Equals(resourceIn, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        break;
                                    }
                                    itemIndex++;
                                }
                                switch (nameIndex)
                                {
                                        case 0:
                                            //studentAccount = account0;
                                            account0[itemIndex] = "";
                                            //Console.WriteLine($"0 student Abbey checked out {resourceOut}");
                                            break;
                                        case 1:
                                            //studentAccount = account1;
                                            account1[itemIndex] = "";
                                            break;
                                        case 2:
                                            // studentAccount = account2;
                                            account2[itemIndex] = "";
                                            break;
                                        case 3:
                                            //studentAccount = account3;
                                            account3[itemIndex] = "";
                                            break;
                                        case 4:
                                            //studentAccount = account4;
                                            account4[itemIndex] = "";
                                            break;
                                        default:
                                            //Console.WriteLine();
                                            //Console.WriteLine("Student's name was not found.");
                                            break;
                                    //}
                                }
                        }
                    }
                    Console.WriteLine();

                    break;

                case "X":       //Exit
                    Console.WriteLine("Goodbye!");
                    exitPressed = true;
                    break;

                default:        //Menu option was not found
                    Console.WriteLine("The code you entered was not found.  Please enter a valid code.");
                    //Run menu method
                    break;
            }
            } 
            while (!exitPressed);

            Console.WriteLine();
            Console.Write("You have exited the program.  Try again? ");
            char runAgain = char.Parse(Console.ReadLine());
            if (runAgain == 'Y' || runAgain == 'y' )
            {
                Main(args);
            }

        }
    }
}
