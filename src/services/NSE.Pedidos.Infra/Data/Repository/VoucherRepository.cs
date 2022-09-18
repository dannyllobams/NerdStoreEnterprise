using Microsoft.EntityFrameworkCore;
using NSE.Core.Data;
using NSE.Pedidos.Domain.Repositorios;
using NSE.Pedidos.Domain.Vouchers;
using System.Threading.Tasks;

namespace NSE.Pedidos.Infra.Data.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        public PedidosContext _context { get; set; }
        public IUnitOfWork UnitOfWork => _context;

        public VoucherRepository(PedidosContext context)
        {
            _context = context;
        }

        public async Task<Voucher> ObterVoucherPorCodigo(string codigo)
        {
            return await _context.Vouchers.FirstOrDefaultAsync(p => p.Codigo == codigo);
        }

        public void Atualizar(Voucher voucher)
        {
            _context.Vouchers.Update(voucher);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
