using MediatR;

namespace DOTNET_CQRS.Domain.Customer.Command
{
    public class CustomerCreateCommand : IRequest<string>
    {
        public string Id { get;  set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get;  set; }
        public string Phone { get;  set; }
    }
}