using Microsoft.AspNetCore.Mvc;
using NSE.Clientes.API.Application.Commands;
using NSE.Clientes.API.Models.Repositories;
using NSE.Core.Mediator;
using NSE.WebAPI.Core.Controllers;
using NSE.WebAPI.Core.Usuario;
using System;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Controllers
{
    public class ClientesController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAspNetUser _user;

        public ClientesController(IClienteRepository clienteRepository,
            IMediatorHandler mediatorHandler,
            IAspNetUser user)
        {
            _clienteRepository = clienteRepository;
            _mediatorHandler = mediatorHandler;
            _user = user;
        }

        [HttpGet("cliente/endereco")]
        public async Task<ActionResult> Index()
        {
            var endereco = await _clienteRepository.ObterEnderecoPorId(_user.ObterUserId());
            return endereco == null ? NotFound() : CustomResponse(endereco);
        }

        [HttpPost("cliente/endereco")]
        public async Task<IActionResult> AdicionarEndereco(AdicionarEnderecoCommand endereco)
        {
            endereco.ClienteId = _user.ObterUserId();
            return CustomResponse(await _mediatorHandler.EnviarComando(endereco));
        }
    }
}
