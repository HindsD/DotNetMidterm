using System;
using System.IO;
using NLog.Web;

namespace DotNetTicketSysTypes
{
    public class Ticket
    {
        public int ticketId { get; set; }
        public string summary { get;  set; }
        public string status { get;  set; }
        public string priority { get;  set; }
        public string submitter { get;  set; }
        public string assigned { get;  set; }
        public string watching { get;  set; }
        public string[] arr { get;  set; }
    
        public Ticket(){
            ticketId = 0;
            summary = "";
            status = "";
            priority = "";
            submitter = "";
            assigned = "";
            watching = "";     
            }

        public virtual string WriteTicket(){
            return (ticketId+"|"+summary+"|"+status+"|"+priority+"|"+submitter+"|"+assigned+"|"+watching);
        }    

        public virtual string Display(){
            
                return ("TicketID: "+arr[0]+"\nSummary: "+arr[1]+"\nStatus: "+arr[2]+"\nPriority: "+arr[3]+"\nSubmitter: "+arr[4]+"\nAssigned: "+arr[5]+"\nWatching: "+arr[6]+"\n");
            
        }

        

        public class Bug : Ticket
        {
            public string severity { get; set; }



        public void Questions(){
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger(); // addslogger
            logger.Info("Program started"); //logs it started

            string file = "Tickets.csv";
                StreamWriter sw = new StreamWriter(file); //writes a new ticket
                    
                    for (int i = 1; i < 10; i++)
                    {
                        ticketId = i;
                        Console.WriteLine("Enter a Ticket (Y/N)?");
                        string resp = Console.ReadLine().ToUpper();
                        if (resp != "Y") { break; }
                        Console.WriteLine("Enter the summary of the ticket.");
                        summary = Console.ReadLine();
                        Console.WriteLine("Enter the current status.");
                        status = Console.ReadLine();
                        Console.WriteLine("Enter the priority.");
                        priority = Console.ReadLine();
                        Console.WriteLine("Who submitted the ticket?");
                        submitter = Console.ReadLine();
                        Console.WriteLine("Who is assigned the ticket?");
                        assigned = Console.ReadLine();
                        Console.WriteLine("Who is watching?");
                        watching = Console.ReadLine();
                        Console.WriteLine("What is the severity of the bug?");
                        severity = Console.ReadLine();
                        
                            try{
                                sw.WriteLine(WriteTicket()); //a  try catch that will throw an exception if it can't write a ticket
                            }catch (Exception ex)
                        {
                            logger.Error("Unable to add ticket!"); // logs an exception
                            logger.Error(ex.Message);
                        }
                    }
                    sw.Close();
        }

        public void ReadTicket(){
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger(); // addslogger
            logger.Info("Program started"); //logs it started

            string file = "Tickets.csv";
            if (File.Exists(file))
                    {
                        StreamReader sr = new StreamReader(file);
                        
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            arr = line.Split('|');
                            Console.WriteLine(Display()); //reads the csv and displays each ticket
                            
                        }
                        sr.Close();
                    }
                    else
                    {
                        logger.Error("File does not exist: Tickets.csv"); // logs if it cant reach the csv
                    }
        }

            public override string WriteTicket()
        {
            return (ticketId+"|"+summary+"|"+status+"|"+priority+"|"+submitter+"|"+assigned+"|"+watching+"|"+severity);
        }
        
        public override string Display()
        {
            return ("TicketID: "+arr[0]+"\nSummary: "+arr[1]+"\nStatus: "+arr[2]+"\nPriority: "+arr[3]+"\nSubmitter: "+arr[4]+"\nAssigned: "+arr[5]+"\nWatching: "+arr[6]+"\nSeverity: "+arr[7]+"\n");
        }
        }



    }
}