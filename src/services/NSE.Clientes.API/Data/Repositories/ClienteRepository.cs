using Microsoft.EntityFrameworkCore;
using NSE.Clientes.API.Models;
using NSE.Clientes.API.Models.Repositories;
using NSE.Core.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.Clientes.API.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClientesContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ClienteRepository(ClientesContext context)
        {
            _context = context;
        }

        public void Adicionar(Cliente cliente)
        {
            _context.Add(cliente);
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
        }

        public async Task<IEnumerable<Cliente>> ObterTodos()
        {
            return await _context.Clientes.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> ObterPorCpf(string cpf)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Cpf.Numero == cpf);
        }

        public async Task<Endereco> ObterEnderecoPorId(Guid clienteId)
        {
            return await _context.Enderecos.FirstOrDefaultAsync(e => e.ClienteId == clienteId);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
