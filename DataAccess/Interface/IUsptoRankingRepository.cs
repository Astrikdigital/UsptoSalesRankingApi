

using BusinessObjectsLayer.Entities;

namespace DataAccessLayer.Interface
{
    public interface IUsptoRankingRepository
    { 
        Task<dynamic> GetSalesSummary();
        Task<List<dynamic>> GetTopTeam();
        Task<List<dynamic>> GetTeamStructure();
        Task<List<dynamic>> GetAgent();
        Task<List<dynamic>> GetClosing();
        Task<List<dynamic>> GetTeam();
        Task<List<dynamic>> GetMonths();
        Task<dynamic> InsertAgent(Agents Dto);
        Task<dynamic> InsertUpdateTeam(Teams Dto);
        Task<List<dynamic>> GetAgentSales();
        Task<AgentSalesDto> InsertAgentSales(AgentSales Dto);
        Task<dynamic> InsertTeamAgent(TeamAgent Dto);
        Task<dynamic> UpdateTeamStructure(TeamAgent Dto);
        Task<dynamic> DeleteTeamStructure(TeamAgent Dto);
        Task<AgentSalesDto> RefundAgentSales(AgentSales Dto);
        Task<dynamic> GetAgentOfTheDay();
        Task<dynamic> DeleteAgent(Agents Dto);
        Task<dynamic> DeleteTeam(Teams Dto);



    }
}



