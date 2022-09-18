using NSE.Core.Data;
using NSE.Pedidos.Domain.Vouchers;
using System.Threading.Tasks;

namespace NSE.Pedidos.Domain.Repositorios
{
    public interface IVoucherRepository : IRepository<Voucher>
    {
        Task<Voucher> ObterVoucherPorCodigo(string codigo);
        void Atualizar(Voucher voucher);
    }
}
