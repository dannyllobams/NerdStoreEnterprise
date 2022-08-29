using FluentValidation.Results;
using MediatR;
using NSE.Clientes.API.Application.Events;
using NSE.Clientes.API.Models;
using NSE.Clientes.API.Models.Repositories;
using NSE.Core.Messages;
using NSE.Core.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Application.Commands
{
    public class RegistrarClienteCommandHandler : 
        CommandHandler, 
        IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        private readonly IClienteRepository _clienteRepository;

        public RegistrarClienteCommandHandler(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<ValidationResult> Handle(RegistrarClienteCommand request, CancellationToken cancellationToken)
        {
            if (!request.EhValido()) 
                return request.ValidationResult;

            var cliente = new Cliente(request.Id, request.Nome, request.Email, request.Cpf);
            var clienteExistente = await _clienteRepository.ObterPorCpf(cliente.Cpf.Numero);

            // Validações de negócio
            if(clienteExistente != null)
            {
                AdicionarErro("Este CPF já está em uso.");
                return ValidationResult;
            }

            // Persistir no banco
            _clienteRepository.Adicionar(cliente);

            cliente.AdicionarEvento(new ClienteRegistradoEvent(request.Id, request.Nome, request.Email, request.Cpf));

            return await base.PersistirDados(_clienteRepository.UnitOfWork);
        }
    }
}
