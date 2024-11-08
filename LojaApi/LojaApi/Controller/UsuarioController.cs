using LojaApi.Repositorys;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LojaApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioReposirys _usuarioRepository;

        public UsuarioController(UsuarioReposirys usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ListarUsuariosDB()
        {
            var usuario = await _usuarioRepository.ListarUsuariosDB();
            return Ok(usuario);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<IActionResult> PostRegistrarUsuario()
        {
            var usuarios = await _usuarioRepository.ListarUsuariosDB();
            return Ok(usuarios);
        }

    }
}
