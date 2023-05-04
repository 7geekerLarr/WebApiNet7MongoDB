using ApiSystemCQRSAplication.GyfSystem.Commands.CreateSystem;
using ApiSystemCQRSAplication.GyfSystem.Commands.DeleteSystem;
using ApiSystemCQRSAplication.GyfSystem.Commands.UpdateSystem;
using ApiSystemCQRSAplication.GyfSystem.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace ApiSystemCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GyfController : ControllerBase
    {
        #region IDependencies
        private readonly IMediator _mediator;
        private readonly ILogger<GyfController> _logger;
        #endregion
        #region [GyfController]       
        public GyfController(IMediator mediator, ILogger<GyfController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }
        #endregion

        #region [Add]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(CreateSystemCommand.CreateSystem data)
        {
            var systemToReturn = await _mediator.Send(data);           
            return CreatedAtRoute("GetOne", new { id = systemToReturn.IdSystem }, systemToReturn);
        }
        #endregion
        #region [GetOne] 
        [HttpGet("{id:int}", Name = "GetOne")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetOne(int id)
        {
            var resultado = await _mediator.Send(new GetSystemByIdQuery.GetSystemById { IdSystem = id.ToString() });
            return Ok(resultado);
        }
        #endregion
        #region [Del]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Del(int id)
        {

            var resultado = await _mediator.Send(new DeleteSystemCommand.DeleteSystem { IdSystem = id.ToString() });
            return NoContent();
        }
        #endregion       
        #region [Get] 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
           
            var resultado = await _mediator.Send(new GetAllSystemsQuery.GetAllSystems());            
            return Ok(resultado);
        }
        #endregion        
        #region [Upd]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Upd([FromBody] UpdateSystemCommand.UpdateSystem data)
        {
            await _mediator.Send(data);
            return NoContent();
        }
        #endregion        
       
        
        
    }
}
