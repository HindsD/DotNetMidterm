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

            string bugFile = "Tickets.csv"; //imports the csv where we will collect the tickets
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

                if (choice == "1")
                {
                    bug.ReadTicket();
                    // if (File.Exists(bugFile))
                    // {
                    //     StreamReader sr = new StreamReader(bugFile);
                        
                    //     while (!sr.EndOfStream)
                    //     {
                    //         string line = sr.ReadLine();
                    //         bug.arr = line.Split('|');
                    //         Console.WriteLine(bug.Display()); //reads the csv and displays each ticket
                            
                    //     }
                    //     sr.Close();
                    // }
                    // else
                    // {
                    //     logger.Error("File does not exist: Tickets.csv"); // logs if it cant reach the csv
                    // }
                }
                else if (choice == "2")
                {
                    bug.Questions();
                }
            } while (choice == "1" || choice == "2"); // keeps looping as long as 1 or 2 is entered
            logger.Info("Program ended"); // logs that it ended
        }
    }
}
