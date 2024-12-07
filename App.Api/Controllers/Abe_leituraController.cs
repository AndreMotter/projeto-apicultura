using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Abe_leituraController : Controller
    {
        private IAbe_leituraService _service;

        public Abe_leituraController(IAbe_leituraService service)
        {
            _service = service;
        }

        [HttpGet("ListaAbe_leitura")]
        public JsonResult ListaAbe_leitura(Guid? col_codigo, Guid? tip_codigo, DateTime? data_inicial, DateTime? data_final)
        {
            try
            {

                var obj = _service.ListaAbe_leitura(col_codigo, tip_codigo, data_inicial, data_final);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }


        [HttpGet("ListaAbe_tipoleitura")]
        public JsonResult ListaAbe_tipoleitura()
        {
            try
            {

                var obj = _service.ListaAbe_tipoleitura();
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("BuscarInformacoesGrafico")]
        public JsonResult BuscarInformacoesGrafico()
        {
            try
            {
                var obj = _service.BuscarInformacoesGrafico();
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
    }
}
