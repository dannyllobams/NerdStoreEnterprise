using NSE.WebApp.MVC.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public class AutenticacaoService : Service, IAutenticacaoService
    {
        private readonly HttpClient _httpClient;

        public AutenticacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = base.ObterConteudo(usuarioLogin);
            var response = await _httpClient.PostAsync("https://localhost:44364/api/identidade/autenticar", loginContent);

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
            var response = await _httpClient.PostAsync("https://localhost:44364/api/identidade/nova-conta", registroContent);

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