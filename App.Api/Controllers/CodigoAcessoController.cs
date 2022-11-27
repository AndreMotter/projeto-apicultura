using App.Domain.DTO;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodigoAcessoController : Controller
    {
        private ICodigoAcessoService _service;

        public CodigoAcessoController(ICodigoAcessoService service)
        {
            _service = service;
        }

        [HttpGet("Gerar")]
        public JsonResult Gerar()
        {
            try
            {
                var obj = _service.Gerar();
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
    }
}
