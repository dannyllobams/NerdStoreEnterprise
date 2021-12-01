using NSE.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface IAutenticacaoService
    {
        public Task<string> Login(UsuarioLogin usuarioLogin);
        public Task<string> Registro(UsuarioRegistro usuarioRegistro);
    }
}
