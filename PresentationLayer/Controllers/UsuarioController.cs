using AutoMapper;
using BusinessLayer.Dto;
using BusinessLayer.Service;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;
        private readonly IMapper _mapper;
        public UsuarioController(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioService = new UsuarioService(_mapper);
        }

        [HttpGet]
        public IActionResult ObterUsuarioPorCpf(string cpf)
        {
            var usuario = _usuarioService.ObterUsuarioPorCpf(cpf);

            if (usuario is null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpGet("lista")]
        public IActionResult BuscarTodos() 
        {
            var usuarios = _usuarioService.ListarUsuarios();

            if (usuarios is null)
                return NotFound();

            return Ok(usuarios);
        }

        [HttpPost]
        public IActionResult CriarUsuario([FromBody]UsuarioDto usuario)
        {
            var user =  _usuarioService.CriarUsuario(usuario);

            if (user is null){
                return BadRequest();
            }

            return Created(user.Cpf, user);
        }

        [HttpPut]
        public IActionResult AlterarUsuario([FromBody] UsuarioDto usuario)
        {
            var response = _usuarioService.AlterarUsuario(usuario);

            if (response is null)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult ExcluirUsuario(string cpf)
        {
            var response = _usuarioService.ExcluirUsuario(cpf);

            if (response is null)
                return NotFound();

            return NoContent();
        }
    }
}
