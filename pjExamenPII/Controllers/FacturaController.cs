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
    public class FacturaController : ControllerBase
    {
        private readonly ILogger<FacturaController> _logger;
        public readonly IMapper _mapper;
        public readonly IFacturasRepository _Repos;

        public FacturaController(ILogger<FacturaController> logger, IMapper mapper, IFacturasRepository repos)
        {
            _logger = logger;
            _mapper = mapper;
            _Repos = repos;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<FacturasDto>>> GetAllF()
        {
            _logger.LogInformation("get All ");

            var List = await _Repos.GetAll();

            return Ok(_mapper.Map<IEnumerable<FacturasDto>>(List));
        }

        [HttpGet("{id:int}", Name = "GetIdFactura")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FacturasDto>> GetIdFactura(int id)
        {
            if (id == 0)
            {
                _logger.LogError($"Error al traer con Id {id}");
                return BadRequest();
            }
            var fac = await _Repos.Get(s => s.IdFactura == id);

            if (fac == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClientesDto>(fac));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FacturasDto>> AddF([FromBody] FacturasCreateDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (await _Repos.Get(s => s.IdFactura.ToLower() == createDto.IdFactura.ToLower()) != null)
            //{
            //    ModelState.AddModelError("NombreExiste", "¡El CLiente con ese Nombre ya existe!");
            //    return BadRequest(ModelState);
            //}

            if (createDto == null)
            {
                return BadRequest(createDto);
            }

            Facturas modelo = _mapper.Map<Facturas>(createDto);

            await _Repos.Add(modelo);

            return CreatedAtRoute("GetIdFactura", new { id = modelo.IdCliente }, modelo);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteF(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var fac = await _Repos.Get(s => s.IdFactura == id);

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
        public async Task<IActionResult> UpdateF(int id, [FromBody] FacturasUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.IdFactura)
            {
                return BadRequest();
            }

            Facturas modelo = _mapper.Map<Facturas>(updateDto);

            _Repos.Update(modelo);

            return NoContent();
        }
    }
}
