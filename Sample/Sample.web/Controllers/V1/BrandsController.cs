using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Sample.web.Contracts.V1.Request;
using Sample.web.Contracts.V1.Responses;
using Sample.web.Domain;
using Sample.web.Services;
using System.Threading.Tasks;

namespace Sample.web.Controllers.V1
{
    [Route("api/v1/[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandsController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] CreateBrandRequest request)
        {
            var name = request.Name.Trim();
            var brand = new Brand
            {
                Name = name
            };

            await _brandService.CreateBrandAsync(brand);

            brand = await _brandService.GetBrandByNameAsync(name);

            return Created($"v1/api/brands/{brand.Id}", _mapper.Map<BrandResponse>(brand));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _brandService.DeleteBrandAsync(id);

            if (deleted)
                return NoContent();

            return NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] UpdateBrandRequest request)
        {
            var brand = await _brandService.GetBrandByIdAsync(id);

            if(brand == null)
                return NotFound();

            brand.Name = request.Name;

            var updated = await _brandService.UpdateBrandAsync(brand);

            if (updated)
                return Ok(_mapper.Map<BrandResponse>(brand));

            return BadRequest(new { error = "Failed to created"});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var brand = await _brandService.GetBrandByIdAsync(id);

            if (brand == null)
                return NotFound();
            return Ok(_mapper.Map<BrandResponse>(brand));
        }

        [HttpGet()]
        public async Task<IActionResult> Get([FromQuery]string name)
        {
            var brand = await _brandService.GetBrandByNameAsync(name);

            if (brand == null)
                return NotFound();
            return Ok(_mapper.Map<BrandResponse>(brand));
        }
    }
}
