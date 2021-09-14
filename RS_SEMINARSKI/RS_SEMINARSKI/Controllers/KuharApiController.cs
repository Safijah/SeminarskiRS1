using Data.Interface;
using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KuharApiController : ControllerBase
    {
        private IKuharService _kuharInterface;

        public KuharApiController(IKuharService kuharInterface)
        {
            _kuharInterface = kuharInterface;
        }
        [HttpGet]
        public IActionResult GetKuhara()
        {
            return Ok(_kuharInterface.GetKuhara());
        }
        [HttpPost]
        public IActionResult DodajNovog(KuharEvidentirajVM vm)
        {
            _kuharInterface.DodajKuhara(vm);
            return Ok();
        }
        [HttpGet("{id}")]

        public IActionResult GetByID(int id)
        {
            return Ok(_kuharInterface.GetKuhara(id));
        }
        [HttpPut]
        public IActionResult EditKuhara(KuharEvidentirajVM vm)
        {
            _kuharInterface.EditKuhara(vm);
            return Ok();
        }
        public IActionResult DeleteKuhar(int id)
        {
            _kuharInterface.DeleteKuhar(id);
            return Ok();
        }
    }
}
