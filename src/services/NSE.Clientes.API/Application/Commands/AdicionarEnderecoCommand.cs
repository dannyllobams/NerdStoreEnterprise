using FluentValidation;
using NSE.Core.Messages;
using System;

namespace NSE.Clientes.API.Application.Commands
{
    public class AdicionarEnderecoCommand : Command
    {
        public Guid ClienteId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public AdicionarEnderecoCommand()
        {

        }

        public AdicionarEnderecoCommand(Guid clienteId, string logradouro, string numero, string complemento,
            string bairro, string cep, string cidade, string estado)
        {
            AggregateId = clienteId;
            ClienteId = clienteId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarEnderecoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AdicionarEnderecoCommandValidation : AbstractValidator<AdicionarEnderecoCommand>
        {
            public AdicionarEnderecoCommandValidation()
            {
                RuleFor(ae => ae.ClienteId)
                    .NotEqual(Guid.Empty)
                    .WithMessage(ae => "Id do cliente inválido");

                RuleFor(ae => ae.Logradouro)
                    .NotEmpty()
                    .WithMessage("Logradouro inválido");

                RuleFor(ae => ae.Bairro)
                    .NotEmpty()
                    .WithMessage("Bairro inválido");

                RuleFor(ae => ae.Cep)
                    .NotEmpty()
                    .WithMessage("Cep inválido");

                RuleFor(ae => ae.Cidade)
                    .NotEmpty()
                    .WithMessage("Cidade inválida");

                RuleFor(ae => ae.Estado)
                    .NotEmpty()
                    .WithMessage("Estado inválido");
            }
        }
    }
}
