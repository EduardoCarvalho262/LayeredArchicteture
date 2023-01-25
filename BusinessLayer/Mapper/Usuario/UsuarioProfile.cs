using AutoMapper;
using BusinessLayer.Dto;
using PersistenceLayer.Dao;

namespace BusinessLayer.Mapper.Usuario
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioDto, UsuarioDao>();
            CreateMap<UsuarioDao, UsuarioDto>();
        }
    }
}
