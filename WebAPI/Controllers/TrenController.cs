using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;
using Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrenController : Controller
    {
        TrenManager trenManager = new TrenManager();

        [HttpPost("sorgula")]
        public IActionResult Sorgula(Content c)
        {
            var result = trenManager.Sorgula(c);
            return Ok(result);
        }
    }
}
