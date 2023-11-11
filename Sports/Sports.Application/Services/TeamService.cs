using Sports.Application.ServiceAbstractions;
using Sports.Domain.Abstractions;
using Sports.Domain.DTOs;
using Sports.Domain.Entities;
using Sports.Domain.SharedModels;

namespace Sports.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork unitOfWork;
        public TeamService(IUnitOfWork unitOfWork)
        {
                this.unitOfWork = unitOfWork;
        }
        public async Task<ResponseModel> DeleteTeam(int Id)
        {
           return await unitOfWork.teamRepository.DeleteTeam(Id)?new ResponseModel { IsSucceeded=true,StatusCode=200}: new ResponseModel { IsSucceeded = false, StatusCode = 404 };
        }

        public async Task<ResponseModel> GetTeam(int Id) => 
            new ResponseModel { Data = await unitOfWork.Repository<Team>().GetById(Id),IsSucceeded=true,StatusCode=200 };
        

        public async Task<ResponseModel> GetTeams()=>
           new ResponseModel { Data = await unitOfWork.Repository<Team>().GetAll(), IsSucceeded = true, StatusCode = 200 };

        public async Task<ResponseModel> GetTeamsByTournament(int Id)=>
                        new ResponseModel { Data = await unitOfWork.teamRepository.GetTeamsByTournament(Id), IsSucceeded = true, StatusCode = 200 };

        public async Task<ResponseModel> LastXAddedTeams(int count)=>
            new ResponseModel { Data = await unitOfWork.teamRepository.LastXAddedTeams(count), IsSucceeded = true, StatusCode = 200 };



        public async Task<ResponseModel> PostTeam(TeamDTO teamDTO)
        {
           await unitOfWork.Repository<Team>().AddAsync(teamDTO);
          var result=await unitOfWork.Complete();
            return result != 0 ? new ResponseModel { Data = teamDTO, IsSucceeded = true, StatusCode = 201 } : new ResponseModel {IsSucceeded=false,StatusCode=400 };   
        }

        public async Task<ResponseModel> PutTeam(TeamDTO teamDTO)
        {
            await unitOfWork.Repository<Team>().UpdateAsync(teamDTO);
            var result = await unitOfWork.Complete();
            return result != 0 ? new ResponseModel { Data = teamDTO, IsSucceeded = true, StatusCode = 204 } : new ResponseModel { IsSucceeded = false, StatusCode = 400 };
        }
    }
}
