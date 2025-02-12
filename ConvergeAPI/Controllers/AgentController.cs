using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Response;
using BusinessLogicLayer.Service;
using BusinessObjectsLayer.Entities;
using ConvergeAPI.HUBS;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR; 

namespace ConvergeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {

        #region Depedenices
        private readonly IConfiguration _configuration;
        private readonly IUsptoRankingService _usptoRankingService; 
        private readonly IHubContext<RankingHub> _hubContext; 
        #endregion



        #region Constructor
        public AgentController(  IHubContext<RankingHub> hubContext, IUsptoRankingService usptoRankingService)
        { 
            _usptoRankingService = usptoRankingService;
            _hubContext = hubContext;
        }
        #endregion

        [HttpGet("GetTopTeam")]
        public async Task <IActionResult> GetTopTeam()
        {
            try
            {
                var rankings = await _usptoRankingService.GetTopTeam();
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }

        [HttpGet("GetSalesSummary")]
        public async Task<IActionResult> GetSalesSummary()
        {
            try
            {
                var rankings = await _usptoRankingService.GetSalesSummary(); 
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            } 
            return Ok(null);
        }
        [HttpGet("GetAgent")]
        public async Task<IActionResult> GetAgent()
        {
            try
            {
                var rankings = await _usptoRankingService.GetAgent();
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }
        [HttpGet("GetClosing")]
        public async Task<IActionResult> GetClosing()
        {
            try
            {
                var rankings = await _usptoRankingService.GetClosing();
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }
        [HttpGet("GetTeam")]
        public async Task<IActionResult> GetTeam()
        {
            try
            {
                var rankings = await _usptoRankingService.GetTeam();
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }
        [HttpGet("GetAgentSales")]
        public async Task<IActionResult> GetAgentSales()
        {
            try
            {
                var rankings = await _usptoRankingService.GetAgentSales();
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }
        [HttpPost("InsertAgentSales")]
        public async Task<IActionResult> InsertAgentSales(AgentSales Dto)
        {
            try
            {
                var rankings = await _usptoRankingService.InsertAgentSales(Dto);
                var List = await _usptoRankingService.GetSalesSummary();
                rankings.AchivedSale = Dto.Amount;
                if (rankings.TopicId == 1)
                {
                await _hubContext.Clients.All.SendAsync("InsertAgentSales", new { Data = rankings, List = List });

                }
                else
                {
                    await _hubContext.Clients.All.SendAsync("AddTeamStructure");
                }
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }
        [HttpPost("RefundAgentSales")]
        public async Task<IActionResult> RefundAgentSales(AgentSales Dto)
        {
            try
            {
                var rankings = await _usptoRankingService.RefundAgentSales(Dto);
                var List = await _usptoRankingService.GetSalesSummary();
                rankings.RefundSale = Dto.Amount;
                await _hubContext.Clients.All.SendAsync("RefundAgentSales", new { Data = rankings, List = List });
                 
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }

        [HttpGet("GetAgentOfTheDay")]
        public async Task<IActionResult> GetAgentOfTheDay()
        {
            try
            { 
                var data  = await _usptoRankingService.GetAgentOfTheDay(); 
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }

        [HttpGet("GetTeamStructure")]
        public async Task<IActionResult> GetTeamStructure(string? searchText = null, int? monthId = null, int? year = null, int? pageNumber = 50, int? pageSize = 0)
        {
            try
            {
                var data = await _usptoRankingService.GetTeamStructure(searchText,monthId,year,pageNumber,pageSize);
                return Ok(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }

        [HttpPost("CreateTeamStructure")]
        public async Task<IActionResult> InsertTeamAgent(TeamAgent Dto)
        {
            try
            {
                var rankings = await _usptoRankingService.InsertTeamAgent(Dto);
                await _hubContext.Clients.All.SendAsync("AddTeamStructure");
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }


        [HttpPost("UpdateTeamStructure")]
        public async Task<IActionResult> UpdateTeamStructure(TeamAgent Dto)
        {
            try
            {
                var rankings = await _usptoRankingService.UpdateTeamStructure(Dto);
                await _hubContext.Clients.All.SendAsync("AddTeamStructure");
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }


        [HttpPost("DeleteTeamStructure")]
        public async Task<IActionResult> DeleteTeamStructure(TeamAgent Dto)
        {
            try
            {
                var rankings = await _usptoRankingService.DeleteTeamStructure(Dto);
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }


        [HttpGet("GetMonths")]
        public async Task<IActionResult> GetMonths()
        {
            try
            {
                var rankings = await _usptoRankingService.GetMonths();
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }

        [HttpPost("InsertUpdateAgent")]
        public async Task<IActionResult> InsertAgent(Agents Dto)
        {
            try
            {
                var agents = await _usptoRankingService.InsertAgent(Dto);
                return Ok(agents);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }
[HttpGet("OnPageReload")]
        public async Task<IActionResult> OnPageReload()
        {
            try
            {
                await _hubContext.Clients.All.SendAsync("OnPageReload");
                return Ok(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }

        [HttpPost("InsertUpdateTeam")]
        public async Task<IActionResult> InsertUpdateTeam(Teams Dto)
        {
            try
            {
                var teams = await _usptoRankingService.InsertUpdateTeam(Dto);
                return Ok(teams);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }

        [HttpPost("DeleteAgent")]
        public async Task<IActionResult> DeleteAgent(Delete Dto)
        {
            try
            {
                var rankings = await _usptoRankingService.DeleteAgent(Dto);
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }


        [HttpPost("DeleteTeam")]
        public async Task<IActionResult> DeleteTeam(Delete Dto)
        {
            try
            {
                var rankings = await _usptoRankingService.DeleteTeam(Dto);
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }
        [HttpGet("GetTotalBench")]
        public async Task<IActionResult> GetTotalBench()
        {
            try
            {
                var rankings = await _usptoRankingService.GetTotalBench();
                return Ok(rankings);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Ok(null);
        }


    }
}