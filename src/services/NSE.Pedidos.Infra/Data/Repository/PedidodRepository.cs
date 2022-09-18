using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Pedidos.Domain.Pedidos;
using NSE.Pedidos.Domain.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Pedidos.Infra.Data.Repository
{
    public class PedidodRepository : IPedidoRepository
    {
        private readonly PedidosContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public PedidodRepository(PedidosContext context)
        {
            _context = context;
        }

        public DbConnection ObterConexao()
        {
            return _context.Database.GetDbConnection();
        }

        public async Task<Pedido> ObterPorId(Guid id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId)
        {
            return await _context.Pedidos
                .Include(p => p.PedidoItems)
                .AsNoTracking()
                .Where(p => p.ClienteId == clienteId)
                .ToListAsync();
        }

        public void Adicionar(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
        }

        public void Atualizar(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
        }

        public async Task<PedidoItem> ObterItemPorId(Guid id)
        {
            return await _context.PedidoItems.FindAsync(id);
        }

        public async Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId)
        {
            return await _context.PedidoItems.SingleOrDefaultAsync(p => p.PedidoId == pedidoId && p.ProdutoId == produtoId);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
