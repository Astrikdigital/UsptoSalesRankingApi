 
using BusinessLogicLayer.Interfaces;
using BusinessObjectsLayer.Entities;
using DataAccessLayer.Interface;
using DataAccessLayer.Repositories; 
using Microsoft.Extensions.Configuration; 
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Nodes;

namespace BusinessLogicLayer.Service
{ 
    public class UsptoRankingService : IUsptoRankingService
    {

        private readonly IUsptoRankingRepository _usptoRankingRepository; 
        private readonly IConfiguration _configuration;


        public UsptoRankingService(IUsptoRankingRepository usptoRankingRepository, IConfiguration configuration)
        {
            _usptoRankingRepository = usptoRankingRepository; 
           _configuration  = configuration;

    } 
        public async Task<dynamic> GetSalesSummary()
        {
            try
            {
                return await _usptoRankingRepository.GetSalesSummary();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<dynamic>> GetTopTeam()
        {
            try
            {
                return await _usptoRankingRepository.GetTopTeam();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<dynamic>> GetAgentSales()
        {
            try
            {
                return await _usptoRankingRepository.GetAgentSales();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<dynamic>> GetTeam()
        {
            try
            {
                return await _usptoRankingRepository.GetTeam();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<dynamic>> GetMonths()
        {
            try
            {
                return await _usptoRankingRepository.GetMonths();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<dynamic>> GetClosing()
        {
            try
            {
                return await _usptoRankingRepository.GetClosing();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<dynamic>> GetAgent()
        {
            try
            {
                return await _usptoRankingRepository.GetAgent();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<AgentSalesDto> InsertAgentSales(AgentSales Dto)
        {
            try
            {
                return await _usptoRankingRepository.InsertAgentSales(Dto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<dynamic> InsertTeamAgent(TeamAgent Dto)
        {
            try
            {
                return await _usptoRankingRepository.InsertTeamAgent(Dto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<dynamic> UpdateTeamStructure(TeamAgent Dto)
        {
            try
            {
                return await _usptoRankingRepository.UpdateTeamStructure(Dto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<AgentSalesDto> RefundAgentSales(AgentSales Dto)
        {
            try
            {
                return await _usptoRankingRepository.RefundAgentSales(Dto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<dynamic> DisabledFrontor(Delete Dto)
        {
            try
            {
                return await _usptoRankingRepository.DisabledFrontor(Dto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<dynamic> GetAgentOfTheDay()
        {
            try
            {
                return await _usptoRankingRepository.GetAgentOfTheDay();
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<List<dynamic>> GetTeamStructure(string? searchText = null, int? monthId = null, int? year = null, int? pageNumber = 50, int? pageSize = 0)
        {
            try
            {
                return await _usptoRankingRepository.GetTeamStructure(searchText,monthId,year,pageNumber,pageSize);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<dynamic> DeleteTeamStructure(TeamAgent Dto)
        {
            try
            {
                return await _usptoRankingRepository.DeleteTeamStructure(Dto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<dynamic> InsertAgent(Agents Dto)
        {
            try
            {
                return await _usptoRankingRepository.InsertAgent(Dto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<dynamic> InsertUpdateTeam(Teams Dto)
        {
            try
            {
                return await _usptoRankingRepository.InsertUpdateTeam(Dto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<dynamic> DeleteAgent(Delete Dto)
        {
            try
            {
                return await _usptoRankingRepository.DeleteAgent(Dto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<dynamic> DeleteTeam(Delete Dto)
        {
            try
            {
                return await _usptoRankingRepository.DeleteTeam(Dto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<dynamic> GetTotalBench()
        {
            try
            {
                return await _usptoRankingRepository.GetTotalBench();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<dynamic> InsertFrontorOfTheDay(FrontorModel Dto)
        {
            try
            {
                return await _usptoRankingRepository.InsertFrontorOfTheDay(Dto);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<dynamic> GetFrontorOfTheDay()
        {
            try
            {
                return await _usptoRankingRepository.GetFrontorOfTheDay();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
