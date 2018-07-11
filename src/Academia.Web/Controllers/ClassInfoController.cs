using Academia.Core.Entities;
using Academia.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetById (Guid id)
        {
            var classInfo = await _classInfoRepository.GetByIdAsync(id);

            if (classInfo == null)
            {
                return NotFound();
            }

            return new ObjectResult(classInfo);
        }
    }
}