using Academia.Core.Entities;
using Academia.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
    }
}