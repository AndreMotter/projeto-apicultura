﻿using App.Domain.DTO;
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
    }
}