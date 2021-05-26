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
    public class KonobarApiController : ControllerBase
    {
        private IKonobarService _konobarInterface;

        public KonobarApiController(IKonobarService konobarInterface)
        {
            _konobarInterface = konobarInterface;
        }
        [HttpGet]
        public IActionResult GetKonobare()
        {
            return Ok(_konobarInterface.GetKonobare());
        }
        [HttpPost]
        public IActionResult DodajNovog(KonobariEvidentirajVM vm)
        {
            _konobarInterface.DodajKonobara(vm);
            return Ok();
        }
        [HttpGet("{id}")]

        public IActionResult GetByID(int id)
        {
            return Ok(_konobarInterface.GetKonobara(id));
        }
        [HttpPut]
        public IActionResult EditAdmina(KonobariEvidentirajVM vm)
        {
            _konobarInterface.EditKonobara(vm);
            return Ok();
        }
    }
}
