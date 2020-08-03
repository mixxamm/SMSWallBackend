using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SMSWallBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SMSController : ControllerBase
    {
        private readonly ILogger<SMSController> _logger;

        public SMSController(ILogger<SMSController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<SMS> Get()
        {
            return new List<SMS> { new SMS() { Date = new DateTime(), Message = "test" } };
        }
    }
}
