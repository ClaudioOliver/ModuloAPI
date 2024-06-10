using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Context;
using ModuloAPI.Entities;

namespace ModuloAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;

        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return Ok(contato);

        }

        [HttpGet("{Id}")]
        public IActionResult ObterPorId(int Id)
        {
            var contato = _context.Contatos.Find(Id);

            if (contato == null)
            {
                return NotFound();
            }
            return Ok(contato);
        }

        [HttpPut("{Id}")]
        public IActionResult Atualizar(int Id, Contato contato)
        {
            var contatoBanco = _context.Contatos.Find(Id);

            if (contatoBanco == null)
            {
                return NotFound();
            }

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);

        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            var contatoBanco = _context.Contatos.Find(Id);

            if (contatoBanco == null)
            {
                return NotFound();
            }

            _context.Contatos.Remove(contatoBanco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}