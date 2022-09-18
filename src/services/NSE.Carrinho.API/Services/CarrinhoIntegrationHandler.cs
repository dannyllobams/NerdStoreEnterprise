using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSE.Carrinho.API.Data;
using NSE.Core.Messages.Integration;
using NSE.MessageBus;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NSE.Carrinho.API.Services
{
    public class CarrinhoIntegrationHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public CarrinhoIntegrationHandler(IMessageBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetSubscriber();
            return Task.CompletedTask;
        }

        private void SetSubscriber()
        {
            _bus.SubscribeAsync<PedidoRealizadoIntegrationEvent>("PedidoRealizado", async request => await ApagarCarrinho(request));
            _bus.AdvancedBus.Connected += OnConnect;
        }

        private void OnConnect(object s, EventArgs e)
        {
            SetSubscriber();
        }

        private async Task ApagarCarrinho(PedidoRealizadoIntegrationEvent message)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<CarrinhoContext>();

            var carrinho = await context.CarrinhoCliente
                .FirstOrDefaultAsync(c => c.ClienteId == message.ClienteId);

            if(carrinho != null)
            {
                context.CarrinhoCliente.Remove(carrinho);
                await context.SaveChangesAsync();
            }
        }
    }
}
