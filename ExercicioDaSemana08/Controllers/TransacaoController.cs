using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExercicioDaSemana08.Interface;
using ExercicioDaSemana08.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExercicioDaSemana08.Controllers
{
    [Microsoft.AspNetCore.Components.Route("transacao")]
    public class TransacaoController : Controller
    
    {
       private IClienteServices _clienteService;

    public TransacaoController(IClienteServices clienteServices)
    {
        _clienteService = clienteServices;
    }

    [HttpPost ("{idCliente}")]
    public ActionResult AdicionarTransacao([FromBody] Transacao transacao, [FromRoute] int idCliente)
    {
        _clienteService.AdicionarTransacao(transacao, idCliente);
        return Created(Request.Path, transacao);
    }

    [HttpGet ("{idCliente}")]
    public ActionResult ListarTransacao([FromRoute] int idCliente)
    {
        return Ok(_clienteService.ListarTransacao(idCliente));
    }
    }
}