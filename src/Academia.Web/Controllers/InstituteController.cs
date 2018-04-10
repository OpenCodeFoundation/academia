using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academia.Core.Entities;
using Academia.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academia.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Institute")]
    public class InstituteController : Controller
    {
        private readonly IAsyncRepository<Institute> _instituteRepository;

        public InstituteController(IAsyncRepository<Institute> instituteRepository)
        {
            _instituteRepository = instituteRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Institute>> GetAll()
        {
            return await _instituteRepository.ListAllAsync();
        }


        [HttpGet("{id}", Name = "GetInstitute")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var institute = await _instituteRepository.GetByIdAsync(id);
            if (institute == null)
            {
                return NotFound();
            }

            return new ObjectResult(institute);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Institute institute)
        {
            if (institute == null)
            {
                return BadRequest();
            }

            await _instituteRepository.AddAsync(institute);

            return CreatedAtRoute("GetInstitute", new { id = institute.Id }, institute);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]Institute institute)
        {
            if (institute == null || institute.Id != id)
            {
                return BadRequest();
            }

            var ins = await _instituteRepository.GetByIdAsync(id);
            if(ins == null)
            {
                return NotFound();
            }

            await _instituteRepository.UpdateAsync(institute);

            return new NoContentResult();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var institute = await _instituteRepository.GetByIdAsync(id);

            if(institute == null)
            {
                return NotFound();
            }

            await _instituteRepository.DeleteAsync(institute);

            return new NoContentResult();
        }
    }
}
