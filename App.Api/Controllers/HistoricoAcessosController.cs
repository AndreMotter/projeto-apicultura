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
        public JsonResult Listar(string usuario, DateTime? dataInicial, DateTime? DataFinal)
        {
            try
            {
                var obj = _service.Listar(usuario, dataInicial, DataFinal);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("Imprimir")]
        public JsonResult Imprimir(string usuario, DateTime? dataInicial, DateTime? DataFinal)
        {
            try
            {
                var obj = _service.Imprimir(usuario, dataInicial, DataFinal);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }


        [HttpDelete("Remover")]
        public JsonResult Remover(Guid id)
        {
            try
            {
                _service.Remover(id);
                return Json(RetornoApi.Sucesso(true));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
    }
}
