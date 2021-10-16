using System;
using System.IO;
using NLog.Web;

namespace DotNetTicketSysTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger(); // addslogger
            logger.Info("Program started"); //logs it started
            Ticket ticket = new Ticket();
            var bug = new Ticket.Bug();

            string choice;
            do
            {
                Console.WriteLine("1) List all tickets."); //asks the user what they'd like to do
                Console.WriteLine("2) Create new ticket.");
                Console.WriteLine("Enter any other key to exit.");
                choice = Console.ReadLine();
                logger.Info("User choice: " + choice); //leeps track of the user's choice

                if (choice == "1"){
                    string typeChoice;
                    do
                    {
                        Console.WriteLine("Which type of ticket would you like to read?");
                        Console.WriteLine("1) Bug/Defect Tickets");
                        Console.WriteLine("2) Enhancement Tickets");
                        Console.WriteLine("3) Task Tickets");
                        Console.WriteLine("Enter any other key to exit.");
                        typeChoice = Console.ReadLine();
                        if (typeChoice == "1")
                        {
                            bug.ReadTicket();
                        }
                        else if (typeChoice == "2")
                        {

                        }
                        else if (typeChoice == "3")
                        {

                        }
                    }while (choice == "1" || choice == "2" || choice == "3");
                }
                else if (choice == "2")
                {
                    string typeChoice;
                    do
                    {
                        Console.WriteLine("What type of ticket would you like to make?");
                        Console.WriteLine("1) Bug/Defect Tickets");
                        Console.WriteLine("2) Enhancement Tickets");
                        Console.WriteLine("3) Task Tickets");
                        Console.WriteLine("Enter any other key to exit.");
                        typeChoice = Console.ReadLine();
                        if (typeChoice == "1")
                        {
                            bug.Questions();
                        }
                        else if (typeChoice == "2")
                        {

                        }
                        else if (typeChoice == "3")
                        {

                        }
                    }while (choice == "1" || choice == "2" || choice == "3");
                }

            } while (choice == "1" || choice == "2"); // keeps looping as long as 1 or 2 is entered
            logger.Info("Program ended"); // logs that it ended
        }
    }
}
