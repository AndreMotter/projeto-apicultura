using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Asp32Controller : Controller
    {
        private IAsp32Service _service;

        public Asp32Controller(IAsp32Service service)
        {
            _service = service;
        }

        [HttpGet("TesteApi")]
        public JsonResult TesteApi()
        {
            try
            {
                _service.TesteApi();
                return Json(RetornoApi.Sucesso());
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
    }
}