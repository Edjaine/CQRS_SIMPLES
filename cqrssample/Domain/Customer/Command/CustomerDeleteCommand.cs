using MediatR;

namespace cqrssample.Domain.Customer.Command
{
    public class CustomerDeleteCommand: IRequest<string>
    {
        public string Id {get; set;}        
    }
}