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
            //Print a menu of user options, including letter codes used to access the options
            //This code was saved in a method, but could have easily been typed directly into
            //the main() method, as it is only called once.
            //It was written and kept primarily for experimentation and practice.
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
            string[] students = { "Jen", "Imari", "Quinn", "Mary", "Kim" };
            Array.Sort(students);

            //Create Accounts arrays for each student which hold checked out items
            //Set initial value to empty string
            string[] account0 = { "", "", "" };  
            string[] account1 = { "", "", "" };
            string[] account2 = { "", "", "" };
            string[] account3 = { "", "", "" };
            string[] account4 = { "", "", "" };
            string[] studentAccount = new string[3];

            //Create Resource array which holds resource names
            string[] resources = { "Database Design", "SQL Queries", "JavaScript", "C# for Dummies", "C# Player's Guide", "HTML & CSS", "Agile Methodology", "Scrum 101", "Hooray for Arrays!", "Getting Along with Git" };
            Array.Sort(resources);

            //Create Checkout array which holds flag showing whether resource is checked "out" or "in".
            //if checkedOut = true then book is checked out
            //if checkedOut = false then book has not been checked out
            bool[] checkedOut = {false, false, false, false, false, false, false, false, false, false};

            bool exitPressed = false;       //Set flag to monitor when exit button is pressed

            //Title
            Console.WriteLine("WELCOME TO THE WE CAN CODE IT RESOURCE LIBRARY");
            Console.WriteLine();

            //do-While loop will continue to re-run code until exit command is pressed
            do
            {
                mainMenu(); //call main menu method
                string menuOption = Console.ReadLine();
                Console.WriteLine();

                //Switch statement runs code based on option chosen from menu
                //int studentRow = 0;   I don't think this was used.
                switch (menuOption.ToUpper())       //User can enter a lower case or upper case menu option
                {
                case "S":       //View list of students
                    Console.WriteLine("*****************************************");
                    Console.WriteLine("*\tSTUDENT LIST\t\t\t*");
                    Console.WriteLine("*\t\t\t\t\t*");
                    foreach (string student in students)
                    {
                        Console.WriteLine($"*\t{student,-32}*");
                        }
                    Console.WriteLine("*\t\t\t\t\t*");
                    Console.WriteLine("*****************************************");
                    break;

                case "I":       //View list of available items
                    Console.WriteLine("*****************************************");
                    Console.WriteLine("*\tRESOURCES LIST\t\t\t*");
                    Console.WriteLine("*\t\t\t\t\t*");
                    int bookIndex = Array.IndexOf(checkedOut, false);       //Find the first index in which resource is available (checkedOut = false)
                    if (bookIndex == -1)        //If all elements are true, then all books are checked out.  False is not found.
                    {
                        Console.WriteLine("*\t(All resources checked out)\t*");
                    }
                    while (bookIndex != -1)     //If available resource was found, continue searching for additional resources
                    {
                        Console.WriteLine($"*\t{resources[bookIndex],-32}*");       //Print the resource that has same index as checkedOut = false
                        bookIndex = Array.IndexOf(checkedOut, false, bookIndex + 1);        //Continue searching for next available item, until no more are found
                    }
                    Console.WriteLine("*\t\t\t\t\t*");
                    Console.WriteLine("*****************************************");
                    break;

                case "A":       //View student account
                    Console.Write("Please enter the student's name: ");
                    string studentName = Console.ReadLine().ToUpper();      //So that printout is in caps
                    int index = 0;            //counts which index I am on
                    foreach (string name in students)
                    {
                        if (name.Equals(studentName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            break;      //break out of loop when student name is found
                        }
                        index++;
                    }
                    switch (index)
                    {
                        case 0:
                            studentAccount = account0;      //Assign the student's account array to a generic array
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
                            Console.WriteLine("Student's name was not found.");
                            Console.WriteLine();
                            break;
                    }
                    Array.Sort(studentAccount);   //Sort items in student account so they print alphabetically
                    if (index < students.Length)         //If the user name is found, search for their resources
                    {
                        bool noResources = true;        //Set flag with default value indicating no items found in student's account
                        Console.WriteLine("*****************************************");
                        Console.WriteLine($"*\t{studentName}'S ACCOUNT\t\t\t*");
                        Console.WriteLine("*\t\t\t\t\t*");

                        foreach (string item in studentAccount)
                        {
                            if (item != "")     //An item was found...
                            {
                                Console.WriteLine($"*\t{item,-32}*");  //Print out the name of the item
                                noResources = false;           //Set flag to false
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
                    studentName = Console.ReadLine();       
                    int nameIndex = 0;
                    foreach (string name in students)
                    {
                        if (name.Equals(studentName, StringComparison.CurrentCultureIgnoreCase)) //Look for name in array
                        {
                            //index number will be used to reference student
                            break;      //break out of loop when student name is found
                        }
                        nameIndex++;
                    }
                    switch (nameIndex)
                    {
                        case 0:
                            studentAccount = account0;      //Assign student account to a generic account
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
                            Console.WriteLine("Student's name was not found.");
                            break;
                    }
                    int checkNumItems = 0;
                    if (nameIndex < students.Length)   //If the user name is found, see if they checked out 3 items
                    {
                        //Look for blanks in the student account which represent availability
                        //to check out additional resources; save index of first match
                        checkNumItems = Array.IndexOf(studentAccount, ""); 
                        if (checkNumItems == -1)  //If no blanks are found the student can't check out any items
                        {
                            Console.WriteLine("The student has checked out a maximum of 3 items.");
                        }
                        else
                        {
                            int resIndex = 0;     //Use resIndex to mark index of resource in array
                            Console.Write("Please enter the resource to be checked out: ");
                            string resourceOut = Console.ReadLine();
                            foreach (string item in resources)
                            {
                                //Search the array of resources until the one the user entered is found
                                if (item.Equals(resourceOut, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    //index number will be used to reference resource
                                    break;      //break out of loop when resource name is found
                                }
                                resIndex++;     //resIndex will mark which index of array matches user input
                            }
                            if (resIndex == resources.Length)   //when all resources are checked and there is
                                    //no match the index marker will be the length of the array
                            {
                                Console.WriteLine("Resource name has not been found.");
                            }
                            else if (checkedOut[resIndex])  //use same index as resource array and check whether
                                    //checkedOut array is true, indicating resources is already checked out
                            {
                                Console.WriteLine($"I'm sorry, {resourceOut} has already been checked out.");
                            }
                            else if (!checkedOut[resIndex]) //if resource is not already checked out...
                            {
                                Console.WriteLine($"{students[nameIndex]} checked out {resourceOut}.");
                                checkedOut[resIndex] = true;       //Set the value of the checkedOut array to true to designate item has been checked out
                                switch (nameIndex)
                                {
                                    case 0:
                                        account0[checkNumItems] = resourceOut;   //Assign the empty index with name of resource
                                        break;
                                    case 1:
                                        account1[checkNumItems] = resourceOut;
                                        break;
                                    case 2:
                                        account2[checkNumItems] = resourceOut;
                                        break;
                                    case 3:
                                        account3[checkNumItems] = resourceOut;
                                        break;
                                    case 4:
                                        account4[checkNumItems] = resourceOut;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }    
                    }
                    Console.WriteLine();
                    break;

                case "R":       //Return item
                    Console.Write("Please enter the student's name: ");
                    studentName = Console.ReadLine();     
                    nameIndex = 0;
                    foreach (string name in students)  //Check array of student names for match to user input
                    {
                        if (name.Equals(studentName, StringComparison.CurrentCultureIgnoreCase))
                        {
                            break;      //break out of loop when student name is found
                        }
                        nameIndex++;    //variable to save index of array that matches user input
                    }
                    switch (nameIndex)
                    {
                        case 0:
                            studentAccount = account0;  //Assign student account to generic array
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
                            Console.WriteLine("Student's name was not found.");
                            break;
                    }
                    checkNumItems = 0;
                    Array.Sort(studentAccount);     //Sort so that all available indexes move to begining of array
                    if (nameIndex < students.Length)   //If the user name is found, see if they checked out any items
                    {
                        checkNumItems = Array.LastIndexOf(studentAccount, "");      //Look for available index in student account, from the end
                        if (checkNumItems == studentAccount.Length - 1)     //If there is available index at the end, they are all available
                        {
                            Console.WriteLine("The student has not checked out any items.");
                        }
                        else
                        {
                            Console.Write("Please enter the resource to be returned: ");
                            string resourceIn = Console.ReadLine();
                            int resIndex = 0;        //index number will be used to reference resource index
                            foreach (string item in resources)
                            {
                                if (item.Equals(resourceIn, StringComparison.CurrentCultureIgnoreCase))     //search for the item to be returned in the resources array
                                {
                                    break;      //break out of loop when resource name is found
                                }
                                resIndex++;
                            }
                            if (resIndex == resources.Length) //If index is length of array, the item was not found
                            {
                                Console.WriteLine("Resource name has not been found.");
                            }
                            else
                            {
                                checkedOut[resIndex] = false;               
                                //Set the value of the checkedOut array to false to designate item is available
                                int itemIndex = 0;
                                foreach (string item in studentAccount)
                                {
                                    if (item.Equals(resourceIn, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        break;
                                    }
                                    itemIndex++;
                                }
                                if (itemIndex == studentAccount.Length)     //If the index is the length of the array, the resource was not found in student account
                                {
                                    Console.WriteLine($"{students[nameIndex]} has not checked out {resourceIn}.");
                                }
                                else        //The resource was found in the student account at index "itemIndex"
                                {
                                    switch (nameIndex)
                                    {
                                        case 0:
                                            account0[itemIndex] = "";   //Index where item found, reset to ""
                                            break;
                                        case 1:
                                            account1[itemIndex] = "";
                                            break;
                                        case 2:
                                            account2[itemIndex] = "";
                                            break;
                                        case 3:
                                            account3[itemIndex] = "";
                                            break;
                                        case 4:
                                            account4[itemIndex] = "";
                                            break;
                                        default:
                                            break;
                                    }
                                }
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
                    Console.WriteLine();
                    break;
                }  
            } while (!exitPressed);

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
