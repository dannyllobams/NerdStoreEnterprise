using NSE.Core.DomainObjects;
using System;

namespace NSE.Clientes.API.Models
{
    public class Endereco : Entity
    {
        public Guid ClienteId { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Cliente Cliente { get; protected set; }

        protected Endereco() { }

        public Endereco(
            Guid id,
            Guid clienteId,
            string logradouro, 
            string numero, 
            string complemento, 
            string bairro, 
            string cep, 
            string cidade, 
            string estado)
        {
            this.Id = id;
            this.ClienteId = clienteId;
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Cep = cep;
            this.Cidade = cidade;
            this.Estado = estado;
        }
    }
}
