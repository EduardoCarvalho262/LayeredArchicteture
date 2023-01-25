using AutoMapper;
using BusinessLayer.Dto;
using PersistenceLayer.Dao;
using PersistenceLayer.Repository.UnitOfWork;

namespace BusinessLayer.Service;

public class UsuarioService
{
    private UnitOfWork unitOfWork;
    private readonly IMapper _mapper;

    public UsuarioService(IMapper mapper)
    {
        _mapper = mapper;
        unitOfWork = new UnitOfWork();
    }

    public UsuarioDto ObterUsuarioPorCpf(string cpf)
    {
        var usuario = unitOfWork.UsuarioRepository.GetById(cpf);
        var resposta = _mapper.Map<UsuarioDto>(usuario);

        return resposta;
    }

    public UsuarioDto CriarUsuario(UsuarioDto usuario)
    {
        try
        {
            var usuarioDao = _mapper.Map<UsuarioDao>(usuario);

            unitOfWork.UsuarioRepository.Insert(usuarioDao);
            unitOfWork.Save();

            return usuario;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public string ExcluirUsuario(string cpf)
    {
        try
        {
            var user = unitOfWork.UsuarioRepository.GetById(cpf);

            if (user is null)
                return "";

            unitOfWork.UsuarioRepository.Delete(user);
            unitOfWork.Save();

            return user.Cpf;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public UsuarioDto AlterarUsuario(UsuarioDto usuario)
    {
        try
        {
            var usuarioDao = _mapper.Map<UsuarioDao>(usuario);

            unitOfWork.UsuarioRepository.Update(usuarioDao);
            unitOfWork.Save();

            return usuario;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public List<UsuarioDto> ListarUsuarios()
    {
        var usuarios = unitOfWork.UsuarioRepository.GetAll();

        var resposta = _mapper.Map<List<UsuarioDto>>(usuarios);

        return resposta;
    }
}