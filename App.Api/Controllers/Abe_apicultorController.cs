using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Abe_apicultorController : Controller
    {
        private IAbe_apicultorService _service;

        public Abe_apicultorController(IAbe_apicultorService service)
        {
            _service = service;
        }

        [HttpGet("ListaAbe_apicultor")]
        public JsonResult ListaAbe_apicultor(string Abe_apicultor)
        {
            try
            {
               
                var obj = _service.ListaAbe_apicultor(Abe_apicultor);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("BuscaPorId")]
        public JsonResult BuscaPorId(Guid id)
        {
            try
            {
                var obj = _service.BuscaPorId(id);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpPost("Salvar")]
        public JsonResult Salvar([FromBody] abe_apicultor obj)
        {
            try
            {
                _service.Salvar(obj);
                return Json(RetornoApi.Sucesso(true));
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
