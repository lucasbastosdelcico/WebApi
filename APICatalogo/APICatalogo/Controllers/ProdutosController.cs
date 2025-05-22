using APICatalogo.Domain.Context;
using APICatalogo.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;


namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetAll()
        {

            var resultados = _context.Produtos
                .AsNoTracking()
                .ToList();

            if (resultados is null)
                return NotFound();

            return resultados;
        }

        [HttpGet("{id:int}")]
        public ActionResult<Produto> GetById(int id)
        {
            var resultado = _context.Produtos
                .AsNoTracking()
                .FirstOrDefault(p => p.ProdutoId == id);
            if (resultado is null)
                return NotFound();
            return resultado;
        }

        [HttpPost("new")]
        public ActionResult<Produto> Post(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = produto.ProdutoId }, produto);
        }

        [HttpPut("att/{id:int}")]
        public ActionResult<Produto> Put(int id, Produto prod) {
            var produto = _context.Produtos.Find(id);
            if (produto is null)
                return NotFound();
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(produto);  
        }
        [HttpDelete("{id :int}")]
        ActionResult<Produto> Delete(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto is null)
                return NotFound();
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return produto;
        }   
    }
}
