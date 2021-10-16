﻿using System;
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

            string file = "Tickets.csv"; //imports the csv where we will collect the tickets
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
                    if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            bug.arr = line.Split('|');
                            Console.WriteLine(bug.Display()); //reads the csv and displays each ticket
                            
                        }
                        sr.Close();
                    }
                    else
                    {
                        logger.Error("File does not exist: Tickets.csv"); // logs if it cant reach the csv
                    }
                }
                else if (choice == "2")
                {
                    StreamWriter sw = new StreamWriter(file); //writes a new ticket
                    for (int i = 1; i < 10; i++)
                    {
                        bug.ticketId = i;
                        Console.WriteLine("Enter a Ticket (Y/N)?");
                        string resp = Console.ReadLine().ToUpper();
                        if (resp != "Y") { break; }
                        Console.WriteLine("Enter the summary of the ticket.");
                        bug.summary = Console.ReadLine();
                        Console.WriteLine("Enter the current status.");
                        bug.status = Console.ReadLine();
                        Console.WriteLine("Enter the priority.");
                        bug.priority = Console.ReadLine();
                        Console.WriteLine("Who submitted the ticket?");
                        bug.submitter = Console.ReadLine();
                        Console.WriteLine("Who is assigned the ticket?");
                        bug.assigned = Console.ReadLine();
                        Console.WriteLine("Who is watching?");
                        bug.watching = Console.ReadLine();
                        Console.WriteLine("What is the severity of the bug?");
                        bug.severity = Console.ReadLine();
                        
                            try{
                                sw.WriteLine(bug.WriteTicket()); //a  try catch that will throw an exception if it can't write a ticket
                            }catch (Exception ex)
                        {
                            logger.Error("Unable to add ticket!"); // logs an exception
                            logger.Error(ex.Message);
                        }
                    }
                    sw.Close();
                }
            } while (choice == "1" || choice == "2"); // keeps looping as long as 1 or 2 is entered
            logger.Info("Program ended"); // logs that it ended
        }
    }
}
