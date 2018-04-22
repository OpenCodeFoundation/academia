using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        /// <summary>
        /// Get a institute by it's id
        /// </summary>
        /// <param name="id">GUID of a institute</param>
        /// <returns></returns>
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

        /// <summary>
        /// Add a new Institute
        /// </summary>
        /// <param name="institute"></param>
        /// <returns>A newly create institute</returns>
        /// <response code="201">Returns the newly created institute</response>
        /// <response code="400">If the institute is null</response>           
        [HttpPost]
        [ProducesResponseType(typeof(Institute), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody]Institute institute)
        {
            if (institute == null)
            {
                return BadRequest();
            }

            await _instituteRepository.AddAsync(institute);

            return CreatedAtRoute("GetInstitute", new { id = institute.Id }, institute);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">GUID of institute</param>
        /// <param name="institute"></param>
        /// <returns></returns>
        /// <response code="204">institute was succesfully updated</response>
        /// <response code="400">id or institute is empty</response>
        /// <response code="404">Institute not found for the id</response>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update(Guid id, [FromBody]Institute institute)
        {
            if (institute == null || institute.Id != id)
            {
                return BadRequest();
            }

            var efInstitute = await _instituteRepository.GetByIdAsync(id);
            if (efInstitute == null)
            {
                return NotFound();
            }

            efInstitute.Name = institute.Name;
            efInstitute.Address = institute.Address;
            efInstitute.Email = institute.Email;

            await _instituteRepository.UpdateAsync(efInstitute);

            return new NoContentResult();
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
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
