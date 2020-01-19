using System.Threading;
using System.Threading.Tasks;
using DOTNET_CQRS.Domain.Customer.Command;
using DOTNET_CQRS.Domain.Customer.Entity;
using DOTNET_CQRS.Infra;
using DOTNET_CQRS.Notifications;
using MediatR;

namespace DOTNET_CQRS.Domain.Customer.Handler
{
    public class CustomerHandler :
        IRequestHandler<CustomerCreateCommand, string>,
        IRequestHandler<CustomerUpdateCommand, string>,
        IRequestHandler<CustomerDeleteCommand, string>
    {
        private readonly IMediator _mediator;
        private readonly ICustomerRepository _repository;

        public CustomerHandler(IMediator mediator, ICustomerRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<string> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            var customer = new CustomerEntity(request.FirstName, request.LastName, request.Email, request.Phone);
            await _repository.Save(customer);

            await _mediator.Publish(new CustomerActionNotification{
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Action = ActionNotification.Criado
            }, cancellationToken);

            return await Task.FromResult("Cliente criado com sucesso");
        }

        public async Task<string> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var customer = new CustomerEntity(request.FirstName, request.LastName, request.Email, request.Phone);
            await _repository.Update(request.Id, customer);

            await _mediator.Publish(new CustomerActionNotification{
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Action = ActionNotification.Atualizado
            }, cancellationToken);

            return await Task.FromResult("Cliente atualizado com sucesso");
        }

        public async Task<string> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repository.GetById(request.Id);

            await _repository.Delete(request.Id);

            await _mediator.Publish(new CustomerActionNotification{
                FirstName = cliente.FirstName,
                LastName = cliente.LastName,
                Email = cliente.Email,
                Action = ActionNotification.Excluido
            }, cancellationToken);

            return await Task.FromResult("Cliente excluído com sucesso");
        }
    }
}