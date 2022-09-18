﻿using NSE.Pedidos.API.Application.DTO;
using NSE.Pedidos.Domain.Repositorios;
using System.Threading.Tasks;

namespace NSE.Pedidos.API.Application.Queries
{
    public interface IVoucherQueries
    {
        Task<VoucherDTO> ObterVoucherPorCodigo(string codigo);
    }

    public class VoucherQueries : IVoucherQueries
    {
        private readonly IVoucherRepository _voucherRepository;

        public VoucherQueries(IVoucherRepository voucherRepository)
        {
            _voucherRepository = voucherRepository;
        }

        public async Task<VoucherDTO> ObterVoucherPorCodigo(string codigo)
        {
            var voucher = await _voucherRepository.ObterVoucherPorCodigo(codigo);

            if (voucher == null || !voucher.EstaValidoParaUtilizacao())
                return null;

            return new VoucherDTO 
            { 
                Codigo = voucher.Codigo, 
                ValorDesconto = voucher.ValorDesconto, 
                Percentual = voucher.Percentual, 
                TipoDesconto = (int)voucher.TipoDesconto 
            };
        }
    }
}
