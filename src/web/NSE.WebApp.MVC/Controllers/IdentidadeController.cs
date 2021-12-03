using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.MVC.Models;
using NSE.WebApp.MVC.Services;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Controllers
{
    public class IdentidadeController : Controller
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public IdentidadeController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpGet()]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLogin model)
        {
            if (!ModelState.IsValid) 
                return View(model);

            var resposta = await _autenticacaoService.Login(model); 

            if (false) 
                return View(model);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistro model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var resposta = _autenticacaoService.Registro(model);

            if (false)
                return View(model);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("sair")]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
