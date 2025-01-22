using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectsLayer.Entities
{
    public class AgentSales  
    {
        public int? Id  { get; set; }
        public int? AgentId { get; set; } 
        public int? Amount { get; set; } 
        public DateTime? Date { get; set; } 
        public string? Month { get; set; }
        public int? StatusId { get; set; } 
    }
    public class RefundAgentSales
    {
        public int? AgentId { get; set; } 
        public string? Month { get; set; }
        public int? Id { get; set; }
    }
    public class AgentSalesDto
    {
        public int? Id { get; set; }
        public int? AchivedSale { get; set; }
        public int? RefundSale { get; set; }

        public string? Month { get; set; }
        public int? Bench { get; set; }
        public int? Achive { get; set; }
        public string? AgentName { get; set; }
        public string? TeamName { get; set; }
        public string? TeamLogo { get; set; }
    }


    public class TeamAgent
    {
        public int? Id { get; set; }
        public int? AgentId { get; set; }
        public int? Month { get; set; }
        public int? Bench { get; set; }
        public int? Achive { get; set; }
        public int? TeamId { get; set; }
        public int? ClosingId { get; set; }
    }
}
