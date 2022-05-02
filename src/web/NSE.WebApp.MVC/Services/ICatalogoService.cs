using NSE.WebApp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSE.WebApp.MVC.Services
{
    public interface ICatalogoService
    {
        Task<ProdutoViewModel> ObterPorId(Guid id);
        Task<IEnumerable<ProdutoViewModel>> ObterTodos();
    }
}
