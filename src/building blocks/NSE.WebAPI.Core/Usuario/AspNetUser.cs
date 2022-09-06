using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace NSE.WebAPI.Core.Usuario
{
    public class AspNetUser : IAspNetUser
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AspNetUser(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string Nome
        {
            get
            {
                return _contextAccessor.HttpContext.User.Identity.Name;
            }
        }

        public Guid ObterUserId()
        {
            return this.EstaAutenticado() ? Guid.Parse(_contextAccessor.HttpContext.User.GetUserId()) : Guid.Empty;
        }
        public string ObterUserEmail()
        {
            return this.EstaAutenticado() ? _contextAccessor.HttpContext.User.GetUserEmail() : null;
        }

        public string ObterUserToken()
        {
            return this.EstaAutenticado() ? _contextAccessor.HttpContext.User.GetUserToken() : null;
        }

        public bool EstaAutenticado()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> ObterClaims()
        {
            return _contextAccessor.HttpContext.User.Claims;
        }

        public HttpContext ObterHttpContext()
        {
            return _contextAccessor.HttpContext;
        }

        public bool PossuiRole(string role)
        {
            return _contextAccessor.HttpContext.User.IsInRole(role);
        }
    }
}
