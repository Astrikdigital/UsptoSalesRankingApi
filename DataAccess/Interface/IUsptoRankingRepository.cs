

using BusinessObjectsLayer.Entities;

namespace DataAccessLayer.Interface
{
    public interface IUsptoRankingRepository
    { 
        Task<dynamic> GetSalesSummary();
        Task<List<dynamic>> GetTopTeam();
        Task<List<dynamic>> GetTeamStructure(string? searchText = null, int? monthId = null, int? year = null, int? pageNumber = 50, int? pageSize = 0);
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
        Task<dynamic> DisabledFrontor(Delete Dto);
        Task<dynamic> GetAgentOfTheDay();
        Task<dynamic> GetFrontorOfTheDay();
        Task<dynamic> DeleteAgent(Delete Dto);
        Task<dynamic> DeleteTeam(Delete Dto);
        Task<dynamic> GetTotalBench();
        Task<dynamic> InsertFrontorOfTheDay(FrontorModel Dto);




    }
}



