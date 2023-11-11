using Sports.Domain.DTOs;
using Sports.Domain.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sports.Application.ServiceAbstractions
{
    public interface ITournamentService
    {
        Task<ResponseModel> GetTournaments();
        Task<ResponseModel> GetTournament(int Id);
        Task<ResponseModel> SearchTournamentByTitle(string Key);
        Task<ResponseModel> GetTournamentForUpdate(int Id);
        Task<ResponseModel> PostTournament(TournamentDTO tournamentDTO);
        Task<ResponseModel> PutTournament(TournamentDTO tournamentDTO);
        Task<ResponseModel> DeleteTournament(int Id);
    }
}
