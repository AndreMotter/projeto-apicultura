﻿using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Esp32Controller : Controller
    {
        private IEsp32Service _service;

        public Esp32Controller(IEsp32Service service)
        {
            _service = service;
        }

        [HttpGet("Entrar")]
        public JsonResult Entrar(string token)
        {
            try
            {
                var obj = _service.Entrar(token);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
    }
}