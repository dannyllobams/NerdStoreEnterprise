using NSE.Core.Data;
using NSE.Pedidos.Domain.Pedidos;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace NSE.Pedidos.Domain.Repositorios
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        DbConnection ObterConexao();
        Task<Pedido> ObterPorId(Guid id);
        Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId);
        void Adicionar(Pedido pedido);
        void Atualizar(Pedido pedido);

        Task<PedidoItem> ObterItemPorId(Guid id);
        Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId);
    }
}
