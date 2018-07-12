using Academia.Core.Entities;
using Academia.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Academia.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/ClassInfo")]
    public class ClassInfoController : Controller
    {
        private readonly IAsyncRepository<ClassInfo> _classInfoRepository;

        public ClassInfoController(IAsyncRepository<ClassInfo> classInfoRepository)
        {
            _classInfoRepository = classInfoRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<ClassInfo>> GetAll()
        {
            return await _classInfoRepository.ListAllAsync();
        }

        [HttpGet("{id}", Name = "GetClassInfo")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var classInfo = await _classInfoRepository.GetByIdAsync(id);

            if (classInfo == null)
            {
                return NotFound();
            }

            return new ObjectResult(classInfo);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClassInfo), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody]ClassInfo classInfo)
        {
            if (classInfo == null)
            {
                return BadRequest();
            }

            await _classInfoRepository.AddAsync(classInfo);

            return CreatedAtRoute("GetClassInfo", new { id = classInfo.Id }, classInfo);
        }

        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update(Guid id, ClassInfo classInfo)
        {
            if (classInfo == null || classInfo.Id != id)
            {
                return BadRequest();
            }

            var efClassInfo = await _classInfoRepository.GetByIdAsync(id);
            if (efClassInfo == null)
            {
                return NotFound();
            }

            efClassInfo.Name = classInfo.Name;
            efClassInfo.Code = classInfo.Code;
            efClassInfo.Description = classInfo.Description;

            await _classInfoRepository.UpdateAsync(efClassInfo);

            return new NoContentResult();
        }
    }
}