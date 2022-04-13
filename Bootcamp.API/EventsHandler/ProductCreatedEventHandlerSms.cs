using Bootcamp.API.Events;
using MediatR;

namespace Bootcamp.API.EventsHandler
{
    public class ProductCreatedEventHandlerSms : INotificationHandler<ProductCreatedEvent>
    {
       private readonly ILogger<ProductCreatedEventHandlerSms> _logger;

        public ProductCreatedEventHandlerSms(ILogger<ProductCreatedEventHandlerSms> logger)
        {
            _logger = logger;
        }

      
        public  Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Gönderici Sms:ID'si {notification.Id} olan Ürün İsmi : {notification.ProductName} ");
            return Task.CompletedTask;
        }
    }
}
