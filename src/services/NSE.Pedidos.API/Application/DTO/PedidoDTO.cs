using NSE.Pedidos.Domain.Pedidos;
using System;
using System.Collections.Generic;

namespace NSE.Pedidos.API.Application.DTO
{
    public class PedidoDTO
    {
        public Guid Id { get; set; }
        public int Codigo { get; set; }
        public int Status { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorTotal { get; set; }
        public decimal Desconto { get; set; }
        public string VoucherCodigo { get; set; }
        public bool VoucherUtilizado { get; set; }
        public List<PedidoItemDTO> PedidoItems { get; set; }
        public EnderecoDTO Endereco { get; set; }

        public static PedidoDTO ParaPedidoDTO(Pedido pedido)
        {
            var pedidoDTO = new PedidoDTO();
            pedidoDTO.Id = pedido.Id;
            pedidoDTO.Codigo = pedido.Codigo;
            pedidoDTO.Status = (int)pedido.PedidoStatus;
            pedidoDTO.Data = pedido.DataCadastro;
            pedidoDTO.ValorTotal = pedido.ValorTotal;
            pedidoDTO.Desconto = pedido.Desconto;
            pedidoDTO.VoucherUtilizado = pedido.VoucherUtilizado;
            pedidoDTO.PedidoItems = new List<PedidoItemDTO>();
            pedidoDTO.Endereco = new EnderecoDTO();

            foreach(var item in pedido.PedidoItems)
            {
                pedidoDTO.PedidoItems.Add(new PedidoItemDTO()
                {
                    PedidoId = item.PedidoId,
                    ProdutoId = item.ProdutoId,
                    Nome = item.ProdutoNome,
                    Imagem = item.ProdutoImagem,
                    Quantidade = item.Quantidade,
                    Valor = item.ValorUnitario,
                });
            }

            if(pedido.Endereco != null)
            {
                pedidoDTO.Endereco = new EnderecoDTO()
                {
                    Logradouro = pedido.Endereco.Logradouro,
                    Numero = pedido.Endereco.Numero,
                    Bairro = pedido.Endereco.Bairro,
                    Cep = pedido.Endereco.Cep,
                    Cidade = pedido.Endereco.Cidade,
                    Estado = pedido.Endereco.Estado,
                };
            }

            return pedidoDTO;
        }
    }
}
