using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pjExamenPII.Models;
using pjExamenPII.Models.Dto;
using pjExamenPII.RepostoryF.IRepositoryF;
using System.Data;

namespace pjExamenPII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        public readonly IMapper _mapper;
        public readonly IClientesRepositoy _ClienteRepos;

        public ClienteController(ILogger<ClienteController> logger, IMapper mapper, IClientesRepositoy clienteRepos)
        {
            _logger = logger;
            _mapper = mapper;
            _ClienteRepos = clienteRepos;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ClientesDto>>> GetClientes()
        {
            _logger.LogInformation("get All CLientes");

            var clientesList = await _ClienteRepos.GetAll();

            return Ok(_mapper.Map<IEnumerable<ClientesDto>>(clientesList));
        }

        [HttpGet("{id:int}", Name = "GetCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClientesDto>> GetCliente(int id)
        {
            if (id == 0)
            {
                _logger.LogError($"Error al traer Libro con Id {id}");
                return BadRequest();
            }
            var clientes = await _ClienteRepos.Get(s => s.IdCliente == id);

            if (clientes == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ClientesDto>(clientes));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClientesDto>> AddAutor([FromBody] ClientesCreateDto cienteCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await _ClienteRepos.Get(s => s.Nombre.ToLower() == cienteCreateDto.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste", "¡El CLiente con ese Nombre ya existe!");
                return BadRequest(ModelState);
            }

            if (cienteCreateDto == null)
            {
                return BadRequest(cienteCreateDto);
            }

            Clientes modelo = _mapper.Map<Clientes>(cienteCreateDto);

            await _ClienteRepos.Add(modelo);

            return CreatedAtRoute("GetCliente", new { id = modelo.IdCliente }, modelo);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var cliente = await _ClienteRepos.Get(s => s.IdCliente == id);

            if (cliente == null)
            {
                return NotFound();
            }

            _ClienteRepos.Remove(cliente);

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] ClientesUpdateDto clienteUpdateDto)
        {
            if (clienteUpdateDto == null || id != clienteUpdateDto.IdCliente)
            {
                return BadRequest();
            }

            Clientes modelo = _mapper.Map<Clientes>(clienteUpdateDto);

            _ClienteRepos.Update(modelo);

            return NoContent();
        }
    }
}
