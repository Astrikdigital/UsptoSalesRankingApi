using BusinessObjectsLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUsptoRankingService
    { 
        Task<List<dynamic>> GetTopTeam();
        Task<List<dynamic>> GetSalesSummary(); 
        Task<List<dynamic>> GetAgent();
        Task<dynamic> GetAgentOfTheDay();
        Task<List<dynamic>> GetClosing();
        Task<List<dynamic>> GetTeam();
        Task<List<dynamic>> GetAgentSales();
        Task<AgentSalesDto> InsertAgentSales(AgentSales Dto);
        Task<AgentSalesDto> RefundAgentSales(AgentSales Dto);
    }
}
