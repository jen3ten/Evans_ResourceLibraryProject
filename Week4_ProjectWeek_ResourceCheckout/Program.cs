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
            string[,] studentsAcct = new string[2, 4];      //array for 2 studentsAcct, change to 5 later
            studentsAcct[0, 0] = "Joe";
            studentsAcct[1, 0] = "Mary";
            for (int row = 0; row < 2; row++)
            {
                for (int col = 1; col <= 3; col ++)
                {
                    studentsAcct[row, col] = " ";        //initialize to 0 resources checked out
                }
            }
            studentsAcct[0, 1] = "Book";                //assign three resources to Joe for testing
            studentsAcct[0, 2] = "Book";
            studentsAcct[0, 3] = "Book";

            //Create Students array which holds student names
            string[] students = { "Abbey", "Brian", "Charlie", "Delaney", "Erin" };
            Array.Sort(students);

            //Create Accounts arrays for each student which holds checked out items
            //string[] account0 = { "", "", "" };
            string[] account0 = { "Ab0", "", "Ab2" };  //for testing
            string[] account1 = { "", "Br1", "" };
            string[] account2 = { "", "", "" };
            string[] account3 = { "D0", "D1", "D2" };
            string[] account4 = { "E0", "E1", "" };
            string[] studentAccount = new string[3];
            
            //Create Resource array which holds resource names and who it is checked out by
            string[,] resourcesInOut = new string[3, 2];     //array for 3 resources, change to 10 later
            resourcesInOut[0, 0] = "Book";
            resourcesInOut[1, 0] = "CD";
            resourcesInOut[2, 0] = "Notes";

            //Create Resource array which holds resource names
            string[] resources = { "Database Design", "SQL Queries", "JavaScript", "C# for Dummies", "C# Player's Guide", "HTML & CSS", "Agile Methodology", "Scrum 101", "Hooray for Arrays!", "Getting Along with Git" };
            Array.Sort(resources);

            //Create Checkout array which holds flag showing whether resource is checked "out" or "in".
            //if checkedOut = true then book is checked out
            //if checkedOut = false then book has not been checked out
            bool[] checkedOut = {false, false, false, false, false, false, false, false, false, false};

            /*test sort of array with blanks
            string[] test = { "bob", " ", "april", " ", "Zoe" };
            Array.Sort(test);
            int counter = 0;
            foreach (string item in test)
            {
                Console.WriteLine(item);
                if (item.Equals("BOB", StringComparison.CurrentCultureIgnoreCase))
                    Console.WriteLine($"{item} is a match. Index is {counter}");
                counter++;
            }
            Console.WriteLine(Array.IndexOf(test, "BOB"));*/


            for (int row = 0; row < 3; row++)
            {
                for (int col = 1; col <= 1; col++)
                {
                    resourcesInOut[row, col] = "in";        //initialize to "in" (not checked out)
                }
            }

            //Check elements of student array
            Console.WriteLine("studentsAcct");
            Console.WriteLine(studentsAcct[0, 0] + "\t|" + studentsAcct[0, 1] + "\t|" + studentsAcct[0, 2] + "\t|" + studentsAcct[0, 3]+ "\t|");
            Console.WriteLine(studentsAcct[1, 0] + "\t|" + studentsAcct[1, 1] + "\t|" + studentsAcct[1, 2] + "\t|" + studentsAcct[1, 3] + "\t|");
            Console.WriteLine();

            //Check elements of resource array
            Console.WriteLine("resourcesInOut");
            Console.WriteLine(resourcesInOut[0, 0] + "\t|" + resourcesInOut[0, 1] + "\t|");
            Console.WriteLine(resourcesInOut[1, 0] + "\t|" + resourcesInOut[1, 1] + "\t|");
            Console.WriteLine(resourcesInOut[2, 0] + "\t|" + resourcesInOut[2, 1] + "\t|");
            Console.WriteLine();

            //Title
            Console.WriteLine("WELCOME TO THE WE CAN CODE IT RESOURCE LIBRARY");
            Console.WriteLine();
            
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
                    /*for (int row = 0; row < studentsAcct.GetLength(0); row++)
                    {
                        Console.WriteLine("*\t"+studentsAcct[row, 0]+"\t\t\t\t*");
                    }*/
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
                    /*for (int row = 0; row < resourcesInOut.GetLength(0); row++)
                    {
                        Console.WriteLine("*\t" + resourcesInOut[row, 0] + "\t\t\t\t*");
                    }*/
                    foreach (string item in resources)
                    {
                        Console.WriteLine("*\t" + item + "\t\t\t\t*");
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
                        Console.WriteLine(name);
                        if (name.Equals(studentName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            //Console.WriteLine($"{name} is a match. Index is {index}");
                            //index number will be used to reference student
                            break;      //break out of loop when student name is found
                        }
                        index++;
                    }
                    //Console.WriteLine($"the index is {index}");
                    switch (index)
                    {
                        case 0:
                            //Console.WriteLine("found abby");
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

                    //Console.WriteLine(Array.IndexOf(students, "BOB"));
                    //int indexStudent = Array.IndexOf(students, studentName);
                    //Console.WriteLine(indexStudent);
                    //foreach (string )
                    /*bool noResources = true;
                    bool noStudent = true;
                    for (int row = 0; row < studentsAcct.GetLength(0); row++)
                    {
                        if (studentsAcct[row, 0].Equals(studentName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            noStudent = false;
                            Console.WriteLine("*****************************************");
                            Console.WriteLine($"*\t{studentName}'S ACCOUNT\t\t\t*");
                            Console.WriteLine("*\t\t\t\t\t*");
                            for (int col = 1; col < studentsAcct.GetLength(1); col++)
                            {
                                if (studentsAcct[row,col] != " ")
                                {
                                    noResources = false;
                                    Console.WriteLine($"*\t{studentsAcct[row, col]}\t\t\t\t*");
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
                    Console.WriteLine();*/
                    break;
                case "C":       //Checkout item
                    Console.Write("Please enter the student's name: ");
                    studentName = Console.ReadLine().ToUpper();
                    index = 0;
                    foreach (string name in students)
                    {
                        Console.WriteLine(name);
                        if (name.Equals(studentName, StringComparison.CurrentCultureIgnoreCase))
                        {
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
                    int checkNumItems = 0;
                    if (index <= 4)   //If the user name is found, see if they checked out 3 items
                    {
                        checkNumItems = Array.IndexOf(studentAccount, "");
                        if (checkNumItems == -1)
                        {
                            Console.WriteLine("The student has checked out a maximum of 3 items.");
                        }
                        else
                        {
                            Console.Write("Please enter the resource to be checked out: ");
                            string resourceOut = Console.ReadLine().ToUpper();
                            foreach (string item in resources)
                            {
                                //Console.WriteLine(name);
                                if (item.Equals(resourceOut, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    Console.WriteLine($"I found {item}");
                                    
                                    //index number will be used to reference resource
                                    break;      //break out of loop when resource name is found
                                }
                                index++;
                            }

                        }
                    }
                    //Console.WriteLine(checkNumItems);
                    

                    /*bool noStudent = true;
                    bool maxItems = true;
                    Console.Write("Please enter the student's name: ");
                    while (noStudent)
                    {
                        studentName = Console.ReadLine().ToUpper();
                        for (int row = 0; row < studentsAcct.GetLength(0); row++)
                        {
                            if (studentsAcct[row, 0].Equals(studentName, StringComparison.CurrentCultureIgnoreCase))
                            {
                                noStudent = false;
                                studentRow = row;
                                for (int col = 1; col < studentsAcct.GetLength(1); col++)
                                {
                                    if(studentsAcct[row,col] == " ")
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
                        for (int row = 0; row < resourcesInOut.GetLength(0); row++)
                        {
                            if (resourcesInOut[row, 0].Equals(resourceOut,StringComparison.CurrentCultureIgnoreCase))
                            {
                                noResources = false;
                                if (resourcesInOut[row,1] == "out")
                                {
                                    Console.WriteLine("The resource is unavailable.");
                                }
                                else
                                {
                                    resourcesInOut[row, 1] = "out";
                                    studentsAcct[studentRow, 1] = resourcesInOut[row, 0];
                                }
                            }
                        }
                        if (noResources)
                        {
                            Console.Write("The item was not found. Please enter the resource name: ");
                        }
                    }*/
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
