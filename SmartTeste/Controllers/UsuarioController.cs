using SmartTeste.Repositorio.Interface;
using Microsoft.AspNetCore.Mvc;
using SmartTeste.Model;

namespace SmartTeste.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarTodosUsuarios()
        {
            List<Usuario> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Usuario>>> BuscarPorId(int id)
        {
            Usuario usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Cadastrar([FromBody] Usuario usuarioModel)
        {

            Usuario usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Deletar(int id)
        {
            bool usuarioApagado = await _usuarioRepositorio.Apagar(id);
            return Ok(usuarioApagado);
        }




    }
}