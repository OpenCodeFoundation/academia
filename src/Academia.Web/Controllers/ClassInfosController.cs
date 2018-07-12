using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Academia.Core.Interfaces;
using Academia.Core.Entities;
using System.Net;

namespace Academia.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/ClassInfos")]
    public class ClassInfosController : Controller
    {
        private readonly IAsyncRepository<ClassInfo> _repository;
        public ClassInfosController(IAsyncRepository<ClassInfo> repository)
        {
            _repository = repository;
        }

        // GET: api/ClassInfos
        [HttpGet]
        public async Task<IEnumerable<ClassInfo>> GetAll()
        {
            return await _repository.ListAllAsync();
        }

        // GET: api/ClassInfos/5
        [HttpGet("{id}", Name = "GetClassInfo")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var classInfo = await _repository.GetByIdAsync(id);
            if(classInfo == null)
            {
                return NotFound();
            }
            return new ObjectResult(classInfo);
        }


        // POST: api/ClassInfos
        [HttpPost]
        [ProducesResponseType(typeof(Institute), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody]ClassInfo classInfo)
        {
            if(classInfo == null)
            {
                return BadRequest();
            }

            await _repository.AddAsync(classInfo);
            return CreatedAtRoute("GetClassInfo", new { id = classInfo.Id }, classInfo);
        }
        
        // PUT: api/ClassInfos/5
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Put(Guid id, [FromBody]ClassInfo classInfo)
        {
            if(classInfo == null || id != classInfo.Id)
            {
                return BadRequest();
            }

            var objClassInfo = await _repository.GetByIdAsync(id);
            
            if(objClassInfo == null)
            {
                return NotFound();
            }


            objClassInfo.Name = classInfo.Name;
            objClassInfo.Description = classInfo.Description;


            await _repository.UpdateAsync(objClassInfo);

            return new NoContentResult();


        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            var classInfo = await _repository.GetByIdAsync(id);
            if(classInfo == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(classInfo);

            return new NoContentResult();
        }
    }
}
