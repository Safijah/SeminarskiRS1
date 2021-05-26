using Data.EFModels;
using Data.Interface;
using Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS_SEMINARSKI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminApiController : ControllerBase
    {
        private IAdminService _adminInterface;

        public AdminApiController(IAdminService adminInterface )
        {
            _adminInterface = adminInterface;
        }
        [HttpGet]
        public IActionResult GetAdmina()
        {
            return Ok(_adminInterface.GetAdmina());
        }
        [HttpPost]
        public IActionResult DodajNovog(KorisnikEvidentirajVM vm)
        {
            _adminInterface.DodajAdministratora(vm);
            return Ok();
        }
        [HttpGet("{id}")]
       
        public IActionResult GetByID(string id)
        {
            return Ok(_adminInterface.GetAdmin(id));
        }
        [HttpPut]
        public IActionResult EditAdmina(KorisnikEvidentirajVM vm )
        {
            _adminInterface.EditAdmina( vm);
            return Ok();
        }
    }
}
