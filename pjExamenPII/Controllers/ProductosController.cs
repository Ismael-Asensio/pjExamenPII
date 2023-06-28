using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pjExamenPII.Models.Dto;
using pjExamenPII.Models;
using pjExamenPII.RepostoryF.IRepositoryF;

namespace pjExamenPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ILogger<ProductosController> _logger;
        public readonly IMapper _mapper;
        public readonly IProductosRepository _Repos;

        public ProductosController(ILogger<ProductosController> logger, IMapper mapper, IProductosRepository repos)
        {
            _logger = logger;
            _mapper = mapper;
            _Repos = repos;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductosDto>>> GetAllP()
        {
            _logger.LogInformation("get All");

            var List = await _Repos.GetAll();

            return Ok(_mapper.Map<IEnumerable<ProductosDto>>(List));
        }

        [HttpGet("{id:int}", Name = "GetIdProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductosDto>> GetIdProduct(int id)
        {
            if (id == 0)
            {
                _logger.LogError($"Error al traer con Id {id}");
                return BadRequest();
            }
            var fac = await _Repos.Get(s => s.IdProducto == id);

            if (fac == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClientesDto>(fac));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductosDto>> AddFa([FromBody] ProductosCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _Repos.Get(s => s.Nombres.ToLower() == createDto.Nombres.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "¡ese Nombre ya existe!");
                return BadRequest(ModelState);
            }

            if (createDto == null)
            {
                return BadRequest(createDto);
            }

            Productos modelo = _mapper.Map<Productos>(createDto);

            await _Repos.Add(modelo);

            return CreatedAtRoute("GetIdProduct", new { id = modelo.IdProducto }, modelo);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteFa(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var fac = await _Repos.Get(s => s.IdProducto == id);

            if (fac == null)
            {
                return NotFound();
            }

            _Repos.Remove(fac);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateFa(int id, [FromBody] ProductosUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.IdProducto)
            {
                return BadRequest();
            }

            Productos modelo = _mapper.Map<Productos>(updateDto);

            _Repos.Update(modelo);

            return NoContent();
        }
    }
}
