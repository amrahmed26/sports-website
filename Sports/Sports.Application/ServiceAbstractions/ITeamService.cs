using Azure;
using Sports.Domain.DTOs;
using Sports.Domain.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Application.ServiceAbstractions
{
    public interface ITeamService
    {
        Task<ResponseModel> GetTeams();
        Task<ResponseModel> GetTeam(int Id);
        Task<ResponseModel> GetTeamsByTournament(int Id);
        Task<ResponseModel> LastXAddedTeams(int count);
        Task<ResponseModel> PostTeam(TeamDTO teamDTO);
        Task<ResponseModel> PutTeam(TeamDTO teamDTO);
        Task<ResponseModel> DeleteTeam(int Id);
    }
}
