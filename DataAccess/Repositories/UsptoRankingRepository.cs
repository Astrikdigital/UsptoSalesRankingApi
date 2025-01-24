
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

        public async Task<List<dynamic>> GetMonths()
        {
            try
            {
                using (IDbConnection con = _context.CreateConnection())
                {
                    return (await con.QueryAsync<dynamic>("API_Select_Months", commandType: CommandType.StoredProcedure)).ToList();
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
                    
                    return (await con.QueryAsync<dynamic>("API_Select_Closing", commandType: CommandType.StoredProcedure)).ToList();
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

        public async Task<dynamic> InsertTeamAgent(TeamAgent Dto)
        {
            try
            {
                using (IDbConnection con = _context.CreateConnection())
                {
                    var parameters = new
                    {
                        agentId = Dto.AgentId,
                        month = Dto.Month,
                        bench = Dto.Bench,
                        achive = Dto.Achive,
                        teamId = Dto.TeamId,
                        closingId = Dto.ClosingId
                    };
                    return (await con.QueryAsync<AgentSalesDto>("Insert_TeamAgent", param: parameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                }
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
                using (IDbConnection con = _context.CreateConnection())
                {
                    var parameters = new
                    {   
                        id = Dto.Id,
                        agentId = Dto.AgentId,
                        month = Dto.Month,
                        bench = Dto.Bench,
                        achive = Dto.Achive,
                        teamId = Dto.TeamId,
                        closingId = Dto.ClosingId
                    };
                    return (await con.QueryAsync<AgentSalesDto>("API_Update_TeamStructure", param: parameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<dynamic>> GetTeamStructure()
        {
            try
            {
                using (IDbConnection con = _context.CreateConnection())
                {
                    return (await con.QueryAsync<dynamic>("API_Select_TeamStructure", commandType: CommandType.StoredProcedure)).ToList();
                }
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
                using (IDbConnection con = _context.CreateConnection())
                {
                    var parameters = new
                    {
                        id = Dto.Id,
                    };
                    return (await con.QueryAsync<dynamic>("API_Delete_TeamStructure", param: parameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                }
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
                using (IDbConnection con = _context.CreateConnection())
                {
                    var parameters = new
                    {
                        Id = Dto.Id,
                        name = Dto.Name,
                        teamId = Dto.TeamId,
                        roleId = Dto.RoleId,
                        isCordinator = Dto.IsCordinator
                    };
                    return (await con.QueryAsync<dynamic>("API_Insert_Update_Agent", param: parameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                }
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
                using (IDbConnection con = _context.CreateConnection())
                {
                    var parameters = new
                    {
                        id = Dto.Id,
                        name = Dto.Name,
                        logo = Dto.Logo
                    };
                    return (await con.QueryAsync<dynamic>("API_Insert_Update_Team", param: parameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
