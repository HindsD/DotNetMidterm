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

        public string WriteTicket(){
            return (ticketId+"|"+summary+"|"+status+"|"+priority+"|"+submitter+"|"+assigned+"|"+watching);
        }    

        public string Display(){
            
                return ("TicketID: "+arr[0]+"\nSummary: "+arr[1]+"\nStatus: "+arr[2]+"\nPriority: "+arr[3]+"\nSubmitter: "+arr[4]+"\nAssigned: "+arr[5]+"\nWatching: "+arr[6]+"\n");
            
        }
    }
}