using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface IAutenticacaoService
    {
        public Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin);
        public Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro);
    }
}
