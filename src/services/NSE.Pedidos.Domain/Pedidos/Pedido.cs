﻿using NSE.Core.DomainObjects;
using NSE.Pedidos.Domain.Vouchers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSE.Pedidos.Domain.Pedidos
{
    public class Pedido : Entity, IAggregateRoot
    {
        private readonly List<PedidoItem> _pedidoItems;

        public int Codigo { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public bool VoucherUtilizado { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PedidoStatus PedidoStatus { get; private set; }
        public Endereco Endereco { get; private set; }
        public Voucher Voucher { get; private set; }
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;

        protected Pedido() { }

        public Pedido(Guid clienteId, decimal valorTotal, List<PedidoItem> pedidoItems,
            bool voucherUtilizado = false, decimal desconto = 0, Guid? voucherid = null)
        {
            ClienteId = clienteId;
            ValorTotal = valorTotal;
            _pedidoItems = pedidoItems;

            Desconto = desconto;
            VoucherUtilizado = voucherUtilizado;
            VoucherId = voucherid;
        }

        public void AutorizarPedido()
        {
            PedidoStatus = PedidoStatus.Autorizado;
        }

        public void AtribuirVoucher(Voucher voucher)
        {
            VoucherUtilizado = true;
            VoucherId = voucher.Id;
            Voucher = voucher;
        }

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public void CalcularValorPedido()
        {
            ValorTotal = PedidoItems.Sum(p => p.Calcularvalor());
            CalcularValorDesconto();
        }

        private void CalcularValorDesconto()
        {
            if (!VoucherUtilizado)
                return;

            decimal desconto = 0;
            var valor = ValorTotal;

            if(Voucher.TipoDesconto == TipoDescontoVoucher.Porcentagem)
            {
                if(Voucher.Percentual.HasValue)
                {
                    desconto = (valor * Voucher.Percentual.Value) / 100;
                    valor -= desconto;
                }
            }
            else
            {
                if(Voucher.ValorDesconto.HasValue)
                {
                    desconto = Voucher.ValorDesconto.Value;
                    valor -= desconto;
                }
            }

            ValorTotal = valor < 0 ? 0 : valor;
            Desconto = desconto;
        }
    }
}
