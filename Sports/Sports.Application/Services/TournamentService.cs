using Sports.Application.ServiceAbstractions;
using Sports.Domain.Abstractions;
using Sports.Domain.DTOs;
using Sports.Domain.Entities;
using Sports.Domain.SharedModels;
using Sports.Domain.ViewModels;
using Sports.Infastructure.Abstractions;


namespace Sports.Application.Services
{
    public class TournamentService : ITournamentService
    {
        private readonly IUnitOfWork unitOfWork;
        public TournamentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork=unitOfWork;           
        }
        public async Task<ResponseModel> DeleteTournament(int Id)
        {
            var result= await unitOfWork.tournamentRepository.DeleteTournament(Id);
        return result ? new ResponseModel { IsSucceeded = true, StatusCode = 200 } : new ResponseModel {StatusCode=404} ;
        }

        public async Task<ResponseModel> GetTournament(int Id) =>
           new ResponseModel { Data = await unitOfWork.Repository<Tournament>().GetById(Id) ,IsSucceeded=true,StatusCode=200};

        public async Task<ResponseModel> GetTournamentForUpdate(int Id)
        {
            return new ResponseModel { Data = await unitOfWork.Repository<Tournament>().GetDataByDapper<TournamentUpdateViewModel>($"GetTourenamentForUpdate {Id}"), IsSucceeded = true, StatusCode = 200 };
        }

        public async Task<ResponseModel> GetTournaments()=>
           new ResponseModel { Data = await unitOfWork.Repository<Tournament>().GetAll(), IsSucceeded = true, StatusCode = 200 };


        public async Task<ResponseModel> PostTournament(TournamentDTO tournamentDTO)
        {
          var result = await unitOfWork.tournamentRepository.PostTournamentTeams(tournamentDTO);
         //  await unitOfWork.Complete();
            return result != null ? new ResponseModel { Data = tournamentDTO, IsSucceeded = true, StatusCode = 201 } : new ResponseModel { Data = tournamentDTO, IsSucceeded = false, StatusCode = 400 };
        }

        public async Task<ResponseModel> PutTournament(TournamentDTO tournamentDTO)
        {
           var result = await unitOfWork.tournamentRepository.PutTournamentTeams(tournamentDTO);
             //await unitOfWork.Complete();
            return result != null ? new ResponseModel { Data = tournamentDTO, IsSucceeded = true, StatusCode = 204 } : new ResponseModel { Data = tournamentDTO, IsSucceeded = false, StatusCode = 400 };
        }

        public async Task<ResponseModel> SearchTournamentByTitle(string Key)=>
    new ResponseModel { Data = await unitOfWork.Repository<Tournament>().GetObjs(x=>new {x.TournamentId,x.Name,x.Logo },x=>x.Name.Contains(Key)), IsSucceeded = true, StatusCode = 200 };


    }
}
