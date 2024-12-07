using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Abe_racaController : Controller
    {
        private IAbe_racaService _service;

        public Abe_racaController(IAbe_racaService service)
        {
            _service = service;
        }

        [HttpGet("ListaAbe_raca")]
        public JsonResult ListaAbe_raca(string rac_descricao, int rac_status)
        {
            try
            {
               
                var obj = _service.ListaAbe_raca(rac_descricao, rac_status);
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
        public JsonResult Salvar([FromBody] abe_raca obj)
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

        [HttpGet("Ativar")]
        public JsonResult Ativar(Guid id)
        {
            try
            {
                _service.Ativar(id);
                return Json(RetornoApi.Sucesso());
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
    }
}
