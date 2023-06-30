using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IndexController : Controller
    {
        private IIndexService _service;

        public IndexController(IIndexService service)
        {
            _service = service;
        }

        [HttpPost("Logar")]
        public JsonResult Logar([FromBody] LoginDTO login)
        {
            try
            {
                var obj = _service.Logar(login);
                return Json(RetornoApi.Sucesso(obj));
            }
            catch (Exception ex)
            {
                return Json(RetornoApi.Erro(ex.Message));
            }
        }
    }
}
