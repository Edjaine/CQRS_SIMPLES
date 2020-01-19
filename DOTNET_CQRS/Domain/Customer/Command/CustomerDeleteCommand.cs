using MediatR;

namespace DOTNET_CQRS.Domain.Customer.Command
{
    public class CustomerDeleteCommand: IRequest<string>
    {
        public string Id {get; set;}        
    }
}