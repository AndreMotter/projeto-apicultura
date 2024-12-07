using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : Controller
    {
        private IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet("ImprimirAbe_raca")]
        public JsonResult ImprimirAbe_raca(string rac_descricao, int rac_status)
        {
            try
            {
                var obj = _service.ImprimirAbe_raca(rac_descricao, rac_status);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }

        [HttpGet("ImprimirAbe_colmeia")]
        public JsonResult ImprimirAbe_colmeia(string col_descricao, int col_status)
        {
            try
            {
                var obj = _service.ImprimirAbe_colmeia(col_descricao, col_status);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }


        [HttpGet("ImprimirAbe_leitura")]
        public JsonResult ImprimirAbe_leitura(Guid? col_codigo, Guid? tip_codigo, DateTime? data_inicial, DateTime? data_final)
        {
            try
            {
                var obj = _service.ImprimirAbe_leitura(col_codigo, tip_codigo, data_inicial, data_final);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
       
    }
}
