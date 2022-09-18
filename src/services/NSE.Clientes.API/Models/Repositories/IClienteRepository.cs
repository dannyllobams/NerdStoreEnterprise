using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Models.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        void Adicionar(Cliente cliente);
        void AdicionarEndereco(Endereco endereco);

        Task<IEnumerable<Cliente>> ObterTodos();
        Task<Cliente> ObterPorCpf(string cpf);
        Task<Endereco> ObterEnderecoPorId(Guid clienteId);
    }
}
