using covid.Dtos;
using covid.Models;
using covid.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace covid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : Controller
    {
        private ICaseRepository _caseRepository;
        public CaseController(ICaseRepository caseRepository)
        {
            _caseRepository = caseRepository;
        }

        //api/case
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CaseDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetCases()
        {
            var cases = _caseRepository.GetCases();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var casesDto = new List<CaseDto>();

            foreach (var data in cases)
            {
                casesDto.Add(new CaseDto
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    Type = data.Type,
                    Description = data.Description
                });
            }

            return Ok(casesDto);
        }

        //api/case/caseId
        [HttpGet("{caseId}", Name = "GetCase")]
        [ProducesResponseType(200, Type = typeof(CaseDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCase(int caseId)
        {
            if (!_caseRepository.CaseExists(caseId))
                return NotFound();

            var data = _caseRepository.GetCase(caseId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var caseDto = new CaseDto()
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Type = data.Type,
                Description = data.Description
            };

            return Ok(caseDto);
        }


        //api/case/type/cured
        [HttpGet("type/cured", Name = "GetCured")]
        [ProducesResponseType(200, Type = typeof(CaseDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetCuredCase()
        {

            var data = _caseRepository.GetCuredCases();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(data);
        }

        [HttpGet("type/infected", Name = "GetInfected")]
        [ProducesResponseType(200, Type = typeof(CaseDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetInfectedCase()
        {
            var data = _caseRepository.GetInfectedCases();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(data);
        }


        [HttpGet("type/deceased", Name = "GetDeceased")]
        [ProducesResponseType(200, Type = typeof(CaseDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetDeceasedCase()
        {
            var data = _caseRepository.GetDeceasedCases();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(data);
        }


        //api/case
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Case))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CreateCase([FromBody] Case data)
        {
            if (data == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_caseRepository.CreateCase(data))
            {
                ModelState.AddModelError("", $"Something went wrong saving the case " +
                                             $"{data.FirstName} {data.LastName}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetCase", new { caseId = data.Id }, data);
        }

        //api/case/caseId
        [HttpPut("{caseId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateCase(int caseId, [FromBody]Case data)
        {
            if (data == null)
                return BadRequest(ModelState);

            if (caseId != data.Id)
                return BadRequest(ModelState);

            if (!_caseRepository.CaseExists(caseId))
                ModelState.AddModelError("", "Case doesn't exist!");

            if (!ModelState.IsValid)
                return StatusCode(404, ModelState);

            if (!_caseRepository.UpdateCase(data))
            {
                ModelState.AddModelError("", $"Something went wrong updating the case " +
                                            $"{data.FirstName} {data.LastName}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }

        //api/case/caseId
        [HttpDelete("{caseId}")]
        [ProducesResponseType(204)] //no content
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public IActionResult DeleteCase(int caseId)
        {
            if (!_caseRepository.CaseExists(caseId))
                return NotFound();

            var data = _caseRepository.GetCase(caseId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_caseRepository.DeleteCase(data))
            {
                ModelState.AddModelError("", $"Something went wrong deleting " +
                                            $"{data.FirstName} {data.LastName}");
                return StatusCode(500, ModelState);
            }

            return Ok();
        }


    }
}
