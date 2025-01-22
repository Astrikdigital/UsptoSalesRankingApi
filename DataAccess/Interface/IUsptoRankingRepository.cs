

using BusinessObjectsLayer.Entities;

namespace DataAccessLayer.Interface
{
    public interface IUsptoRankingRepository
    { 
        Task<dynamic> GetSalesSummary();
        Task<List<dynamic>> GetTopTeam();
        Task<List<dynamic>> GetAgent();
        Task<List<dynamic>> GetClosing();
        Task<List<dynamic>> GetTeam();
        Task<List<dynamic>> GetAgentSales();
        Task<AgentSalesDto> InsertAgentSales(AgentSales Dto);
        Task<AgentSalesDto> RefundAgentSales(AgentSales Dto);
        Task<dynamic> GetAgentOfTheDay();


    }
}



