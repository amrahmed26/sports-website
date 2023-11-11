using AutoMapper;
using Sports.Domain.DTOs;
using Sports.Domain.Entities;
using Sports.Infastructure.Extensions;
using Microsoft.AspNetCore.Mvc;


namespace Sports.Infastructure.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            MapTeams();
            MapTournaments();
            MapPlayers();
        }
        private void MapTeams()
        {
            CreateMap<TeamDTO,Team>().ForMember(dest => dest.Logo, opt => opt.MapFrom(src =>
                    src.Logo == null ? src.LogoFile.UploadFile() : src.Logo));
        }
        private void MapTournaments()
        {
            CreateMap<TournamentDTO, Tournament>()
                .ForMember(dest => dest.Logo, opt => opt.MapFrom(src =>
                    src.LogoLink == null ? src.Logo.UploadFile() : src.LogoLink));

        }
        private void MapPlayers()
        {
            CreateMap<PlayerDTO, Player>().ReverseMap();

        }
    }
}
