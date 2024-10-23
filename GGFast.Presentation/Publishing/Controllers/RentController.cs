using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AutoMapper;
using GottaGoFast.Domain.Publishing.Models.Entities;
using GottaGoFast.Presentation.Publishing.Filters;
using GottaGoFast.Domain.Publishing.Models.Commands;
using GottaGoFast.Domain.Publishing.Models.Queries;
using GottaGoFast.Domain.Publishing.Models.Response;
using GottaGoFast.Domain.Publishing.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GottaGoFast.Presentation.Publishing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRentCommandService _rentCommandService;
        private readonly IRentQueryService _rentQueryService;
        
        public RentController(IRentQueryService rentQueryService, IRentCommandService rentCommandService, IMapper mapper)
        {
            _rentQueryService = rentQueryService;
            _rentCommandService = rentCommandService;
            _mapper = mapper;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(List<RentResponse>), 200)]
        [ProducesResponseType(typeof(void),statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(500)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _rentQueryService.Handle(new GetAllRentsQuery());
            
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetRentById")]
        [ProducesResponseType(typeof(RentResponse), 200)]
        [ProducesResponseType(typeof(void),statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void),StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _rentQueryService.Handle(new GetRentByIdQuery(id));
            
            if (result==null) StatusCode(StatusCodes.Status404NotFound);

            return Ok(result);
        }
        
        
        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(void),statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(void),StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostAsync([FromBody] CreateRentCommand command)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest();

                var rent = await _rentCommandService.Handle(command);

                return CreatedAtRoute("GetRentById", new { id = rent }, rent);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null) return StatusCode(StatusCodes.Status500InternalServerError, ex.InnerException.Message);
            }
            
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void),statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void),StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] UpdateRentCommand command)
        {
            if (!ModelState.IsValid) return BadRequest();
            var result = await _rentCommandService.Handle(id, command);
            
            if (!result) StatusCode(StatusCodes.Status404NotFound);

            return Ok();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), 200)]
        [ProducesResponseType(typeof(void),statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(void),StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            DeleteRentCommand command = new DeleteRentCommand { Id = id };
            
            var result = await _rentCommandService.Handle(command);
            
            if (!result) StatusCode(StatusCodes.Status404NotFound);

            return Ok();
        }
    }
}
