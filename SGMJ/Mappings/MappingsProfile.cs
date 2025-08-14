using AutoMapper;
using Sgmj.Modelos.Models;
using SGMJ.API.Dtos;

namespace SGMJ.API.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile() 
        {
            CreateMap<Jovem, JovemDto>()
                .ForMember(dest => dest.Idade, opt => opt.MapFrom(src =>
                    DateTime.Today.Year - src.DataNascimento.Year -
                    (DateTime.Today < src.DataNascimento.AddYears(DateTime.Today.Year - src.DataNascimento.Year) ? 1 : 0)
                )).ForMember(dest => dest.Congregacao,
                       opt => opt.MapFrom(src => src.Congregacao != null ? src.Congregacao.Nome : string.Empty))
             .ForMember(dest => dest.Setor,
               opt => opt.MapFrom(src => src.Congregacao != null && src.Congregacao.Setor != null
                                         ? src.Congregacao.Setor.NomeSetor
                                         : string.Empty));

            CreateMap<Congregacao, CongregacaoDto>();
        }
    }
}
