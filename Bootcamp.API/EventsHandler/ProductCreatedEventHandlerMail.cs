using Bootcamp.API.Events;
using MediatR;

namespace Bootcamp.API.EventsHandler
{
    public class ProductCreatedEventHandlerMail:INotificationHandler<ProductCreatedEvent>
    {
        private readonly ILogger<ProductCreatedEventHandlerMail> _logger;

        public ProductCreatedEventHandlerMail(ILogger<ProductCreatedEventHandlerMail> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Gönderici Mail:ID'si {notification.Id} olan Ürün İsmi : {notification.ProductName} ");
            return Task.CompletedTask;
        }
    }
}
