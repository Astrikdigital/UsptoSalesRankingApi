
using BusinessObjectsLayer.Entities;
using Dapper;
using DataAccess.DbContext;
using DataAccessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccessLayer.Repositories
{
    public class UsptoRankingRepository : IUsptoRankingRepository
    {
        private readonly DapperContext _context;
        private readonly HttpContextAccessor _httpContextAccessor;
        public UsptoRankingRepository(HttpContextAccessor httpContextAccessor,DapperContext context)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<dynamic> GetSalesSummary()
        {
            try
            {
                using (IDbConnection con = _context.CreateConnection())
                {
                    using var multi = await con.QueryMultipleAsync("GetSalesSummary", commandType: CommandType.StoredProcedure);


                    var UpSell = (await multi.ReadAsync<dynamic>()).ToList();
                    var FrontSell = (await multi.ReadAsync<dynamic>()).ToList();
                    return new { UpSell = UpSell, FrontSell = FrontSell };
                }
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
                using (IDbConnection con = _context.CreateConnection())
                {
                    var parameters = new
                    {
                    };
                    return (await con.QueryAsync<dynamic>("GetTopTeam", param: parameters, commandType: CommandType.StoredProcedure)).ToList();
                }
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
                using (IDbConnection con = _context.CreateConnection())
                { 
                    return (await con.QueryAsync<dynamic>("GetAgentSales",   commandType: CommandType.StoredProcedure)).ToList();
                }
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
                using (IDbConnection con = _context.CreateConnection())
                {
                    return (await con.QueryAsync<dynamic>("GetTeam", commandType: CommandType.StoredProcedure)).ToList();
                }
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
                using (IDbConnection con = _context.CreateConnection())
                {
                    
                    return (await con.QueryAsync<dynamic>("GetClosing", commandType: CommandType.StoredProcedure)).ToList();
                }
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
                using (IDbConnection con = _context.CreateConnection())
                { 
                    return (await con.QueryAsync<dynamic>("GetAgent", commandType: CommandType.StoredProcedure)).ToList();
                }
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
                using (IDbConnection con = _context.CreateConnection())
                {
                    var parameters = new
                    {
                        AgentId = Dto.AgentId,
                        Amount = Dto.Amount,
                        Date = Dto.Date,
                        Month = Dto.Month,
                        StatusId = Dto.StatusId !=null ? Dto.StatusId : 1
                    };
                    return (await con.QueryAsync<AgentSalesDto>("InsertAgentSales", param: parameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                }
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
                using (IDbConnection con = _context.CreateConnection())
                {
                    return (await con.QueryAsync<dynamic>("GetAgentOfTheDay", commandType: CommandType.StoredProcedure)).ToList();
                }
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
                using (IDbConnection con = _context.CreateConnection())
                {
                    var parameters = new
                    {
                        AgentId = Dto.AgentId, 
                        Id = Dto.Id,
                        Month = Dto.Month
                    };
                    return (await con.QueryAsync<AgentSalesDto>("RefundAgentSales", param: parameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
