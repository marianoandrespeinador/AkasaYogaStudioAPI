using System.Collections.Generic;
using System.Threading.Tasks;
using Akasa.Dto.Core;
using Akasa.Services.Core;
using Microsoft.AspNetCore.Mvc;

namespace AkasaYogaStudioAPI.Core
{
    public class AkasaController<IService, TGetDto, TInsertDto, TUpdateDto> : Controller
        where IService : IAkasaService<TGetDto, TInsertDto, TUpdateDto>
        where TGetDto : FiniteDataEntityDto
        where TInsertDto : FiniteDataEntityDto
        where TUpdateDto : FiniteDataEntityDto
    {
        protected IService _service;

        public AkasaController(IService service)
        {
            _service = service;
        }
        
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<TGetDto>> Get()
        {
            return await _service.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<TGetDto> Get(int id)
        {
            return await _service.Get(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<TGetDto> Post([FromBody]TInsertDto insertData)
        {
            return await _service.Insert(insertData);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody]TUpdateDto updateData)
        {
            await _service.Update(id, updateData);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }

    }
}
