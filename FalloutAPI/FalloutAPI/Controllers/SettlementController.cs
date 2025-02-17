


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

        [HttpGet("{id:long}")]
        public IActionResult Get(long id)
        {
            Settlement settlement = _dataRepository.Get(id);

            if (settlement == null)
            {
                return NotFound("Settlement record could not be found");
            }

            return Ok(settlement);
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            Settlement settlement = _dataRepository.GetByName(name);

            if (settlement == null)
            {
                return NotFound("Settlement record could not be found");
            }

            return Ok(settlement);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Settlement settlement)
        {
            if (settlement == null)
            {
                return BadRequest("Settlement is Null");
            }

            _dataRepository.Add(settlement);
            return CreatedAtRoute(
                "Get",
                new { Id = settlement.ID },
                settlement);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Settlement settlement) 
        {
            if (settlement == null)
            {
                return BadRequest("Settlement is Null");
            }

            Settlement settlementToUpdate = _dataRepository.Get(id);
            if(settlementToUpdate == null) 
            {
                return NotFound("Settlement record could not be found");
            }

            _dataRepository.Update(settlementToUpdate, settlement);
            return Ok(settlement);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id) 
        {
            Settlement settlement = _dataRepository.Get(id);
            if(settlement == null)
            { 
                return NotFound("Settlement record could not be found");
            }

            _dataRepository.Delete(settlement);
            return Ok(settlement);
        }


    }
}