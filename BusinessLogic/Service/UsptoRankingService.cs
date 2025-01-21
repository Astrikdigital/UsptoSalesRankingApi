﻿ 
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
        public async Task<List<dynamic>> GetSalesSummary()
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
    }
}
