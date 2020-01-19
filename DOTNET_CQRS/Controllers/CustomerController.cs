using System.Collections.Generic;
using System.Threading.Tasks;
using DOTNET_CQRS.Domain.Customer.Command;
using DOTNET_CQRS.Infra;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DOTNET_CQRS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICustomerRepository _repository;

        public CustomerController(IMediator mediator, ICustomerRepository repository)
        {
            _mediator = mediator;
            _repository =   repository;
        }


        [HttpPost]
        public async Task<IActionResult> Post(CustomerCreateCommand command){
            var response = await _mediator.Send(command);
            return Ok(response);            
        }

        [HttpPut]
        public async Task<IActionResult> Put(CustomerCreateCommand command){
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id){
            var command = new CustomerDeleteCommand{Id = id};
            var response = await _mediator.Send(command);
            return Ok(response);            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _repository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id){
            var result = await _repository.GetById(id);
            return Ok(result);
        }
        
    }
}