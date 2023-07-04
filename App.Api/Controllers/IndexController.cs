using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Autenticador.API.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : Controller
    {
        private readonly JwtIssuerOptions _jwtOptions;
        private IIndexService _service;

        public IndexController(IOptions<JwtIssuerOptions> jwtOptions, IIndexService service)
        {
            _service = service;
            _jwtOptions = jwtOptions.Value;
        }

        [HttpPost("Logar")]
        [AllowAnonymous]
        public async Task<JsonResult> Logar([FromBody] LoginDTO login)
        {
            try
            {
                var obj = _service.Logar(login);
                var token = await _jwtOptions.Token(obj);
                return await Task.Run(() =>
                {
                    return Json(new { status = "success", data = obj, token = token });
                });
            }
            catch (Exception e)
            {
                return Json(new { status = "error", message = e.Message });
            }
        }

        [HttpGet("Autenticado")]
        [AllowAnonymous]
        public JsonResult Autenticado()
        {
            try
            {
                var token = Request.Headers["Authorization"];
                var auth = _jwtOptions.GetAuthData(token);
                var obj = _service.Autenticado(auth);
                return Json(RetornoApi.Sucesso(obj, token));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
    }
}
