using Microsoft.Extensions.Options;
using NSE.Core.Comunication;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface IAutenticacaoService
    {
        public Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);
        public Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
    }

    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(
            HttpClient httpClient, 
            IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(settings.Value.AutenticacaoUrl);
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = base.ObterConteudo(usuarioLogin);
            var response = await _httpClient.PostAsync("/api/identidade/autenticar", loginContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin()
                {
                    ResponseResult = await base.DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await base.DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = base.ObterConteudo(usuarioRegistro);
            var response = await _httpClient.PostAsync("/api/identidade/nova-conta", registroContent);

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin()
                {
                    ResponseResult = await base.DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await base.DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }
    }
}