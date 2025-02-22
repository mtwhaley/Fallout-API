using Microsoft.AspNetCore.Mvc;
using FalloutAPI.Models;
using FalloutAPI.Repository;
using System.Collections.Generic;

namespace FalloutAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IDataRepository<Area> _dataRepository;

        public AreaController(IDataRepository<Area> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Area> areas = _dataRepository.GetAll();
            return Ok(areas);
        }

        [HttpGet("{name}")]
        public IActionResult Get(string name)
        {
            Area area = _dataRepository.GetByName(name);

            if (area == null)
            {
                return NotFound("Area record could not be found");
            }

            return Ok(area);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Area area)
        {
            if (area == null)
            {
                return BadRequest("Area is Null");
            }

            _dataRepository.Add(area);
            return CreatedAtRoute(
                "Get",
                new { Name = area.Name },
                area);
        }

        [HttpPut("{name}")]
        public IActionResult Put(string name, [FromBody] Area area) 
        {
            if (area == null)
            {
                return BadRequest("Area is Null");
            }

            Area areaToUpdate = _dataRepository.GetByName(name);
            if(areaToUpdate == null) 
            {
                return NotFound("Area record could not be found");
            }

            _dataRepository.Update(areaToUpdate, area);
            return Ok(area);
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name) 
        {
            Area area = _dataRepository.GetByName(name);
            if(area == null)
            { 
                return NotFound("Area record could not be found");
            }

            _dataRepository.Delete(area);
            return Ok(area);
        }
    }
}
