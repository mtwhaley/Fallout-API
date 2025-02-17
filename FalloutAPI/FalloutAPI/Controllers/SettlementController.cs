


using System.Collections.Generic;
using Fallout.Models;
using Fallout.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Fallout.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class SettlementController : ControllerBase
    {

        private readonly IDataRepository<Settlement> _dataRepository;

        public SettlementController(IDataRepository<Settlement> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Settlement> settlements = _dataRepository.GetAll();
            return Ok(settlements);
        }


    }
}