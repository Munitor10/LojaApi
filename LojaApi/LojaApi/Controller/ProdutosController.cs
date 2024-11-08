using LojaApi.Models;
using LojaApi.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LojaApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutosRepositorys _produtosRepository;

        public ProdutosController(ProdutosRepositorys produtosRepository)
        {
            _produtosRepository = produtosRepository;
        }


        // GET api/<BlibiotecaControllers>/5
        [HttpGet("Listar-produtos")]
        public async Task<IActionResult> ListarProdutos()
        {
            var Produtos = await _produtosRepository.ListarProdutos();
            return Ok(Produtos);
        }

        // DELETE api/<ProdutosController>/5
        [HttpDelete("deleta-produto")]
        public async Task<IActionResult> ExcluirProduto(int id)
        {
            try
            {
                await _produtosRepository.ExcluirProduto(id);

                return Ok(new { mensagem = "Produtos excluído com sucesso" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}

