using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HistoricoAcessosController : Controller
    {
        private IHistoricoAcessosService _service;

        public HistoricoAcessosController(IHistoricoAcessosService service)
        {
            _service = service;
        }

        [HttpGet("Listar")]
        public JsonResult Listar(string busca)
        {
            try
            {
                var obj = _service.Listar(busca);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
    }
}
