using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VodusInfrastructureLayer.Repository;

namespace VodusApiLayer.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class VodusController : ControllerBase
    {
        private readonly VodusRepository _vodusRepository;

        public VodusController(VodusRepository vodusRepository)
        {
            _vodusRepository = vodusRepository;
        }


    }
}
