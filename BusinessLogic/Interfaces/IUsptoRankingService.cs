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
        Task<dynamic> GetSalesSummary(); 
        Task<List<dynamic>> GetAgent();
        Task<List<dynamic>> GetTeamStructure(string? searchText = null, int? monthId = null, int? year = null, int? pageNumber = 50, int? pageSize = 0);
        Task<dynamic> GetAgentOfTheDay();
        Task<dynamic> GetFrontorOfTheDay();
        Task<List<dynamic>> GetClosing();
        Task<List<dynamic>> GetTeam();
        Task<List<dynamic>> GetMonths();
        Task<List<dynamic>> GetAgentSales();
        Task<AgentSalesDto> InsertAgentSales(AgentSales Dto);
        Task<dynamic> InsertAgent(Agents Dto);
        Task<dynamic> InsertUpdateTeam(Teams Dto);
        Task<dynamic> InsertTeamAgent(TeamAgent Dto);
        Task<dynamic> InsertFrontorOfTheDay(FrontorModel Dto);
        Task<dynamic> UpdateTeamStructure(TeamAgent Dto);
        Task<dynamic> DeleteTeamStructure(TeamAgent Dto);
        Task<AgentSalesDto> RefundAgentSales(AgentSales Dto);
        Task<dynamic> DisabledFrontor(Delete Dto);
        Task<dynamic> DeleteAgent(Delete Dto);
        Task<dynamic> DeleteTeam(Delete Dto);
        Task<dynamic> GetTotalBench();
        

    }
}
