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
        public int TopicId { get; set; }
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
        public int? Year { get; set; }
    }

    public class Agents
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? TeamId { get; set; }
        public int? RoleId { get; set; }
        public int? IsCordinator { get; set; }
    }

    public class Teams
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }

    }


    public class Delete
    {
        public int? Id { get; set; }

    }

    public class FrontorModel
    {
        public int? AgentId { get; set; }
        public bool? IsEnabled { get; set; }
        public string? ScreenTitle { get; set; }

    }


}
