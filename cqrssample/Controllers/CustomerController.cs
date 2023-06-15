using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using cqrssample.Core;
using cqrssample.Domain.Customer.Command;
using cqrssample.Domain.Customer.Entity;
using cqrssample.Infra;
using cqrssample.Service;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace cqrssample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICustomerRepository _repository;
        private readonly ServiceUri _serviceUri;

        public CustomerController(IMediator mediator, ICustomerRepository repository, ServiceUri serviceUri)
        {
            _mediator = mediator;
            _repository =   repository;
            _serviceUri = serviceUri;
        }


        [HttpPost]
        public async Task<IActionResult> Post(IList<CustomerCreateCommand> command){
            
            var result = new List<string>();
            foreach (var c in command)
            {
                var r = await _mediator.Send(c);
                result.Add(r);
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CustomerCreateCommand command){
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id){
            var command = new CustomerDeleteCommand{Id = id};
            var response = await _mediator.Send(command);
            return Ok(response);            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationFilter filter)
        {
            var result = await _repository.GetAll(filter.PageNumber, filter.PageSize);
            return Ok(PagiantionHelper.CreatePagedReponse<CustomerEntity>(result, filter, result.Count(), (ServiceUri)_serviceUri, Request.Path.Value));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id){
            var result = await _repository.GetById(id);
            return Ok(result);
        }
        
    }
}