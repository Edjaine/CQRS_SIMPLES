using System.Threading;
using System.Threading.Tasks;
using cqrssample.Notifications;
using MediatR;

namespace cqrssample.EventsHandlers
{
    public class EmailHandler : INotificationHandler<CustomerActionNotification>
    {
        public Task Handle(CustomerActionNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() => {
                // Aqui eu crio minha notificação personalizada que pode ser um registro no banco de dados ou um email ou um eventView
                System.Console.WriteLine($"O cliente {notification.FirstName} {notification.LastName} foi {notification.Action.ToString()} com sucesso");
            });
        }
    }
}