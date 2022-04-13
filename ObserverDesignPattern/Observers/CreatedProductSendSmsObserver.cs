

using Microsoft.Extensions.Logging.Abstractions;
using System.Diagnostics;

namespace ObserverDesignPattern.Observers
{
    public class CreatedProductSendSmsObserver : CreatedProductSendObserver
    {
   

        public override void SendMessage(int productId, string productName)
        {
            
            Debug.WriteLine($"SMS Ürün Eklenmiştir. ID: {productId} Ürün ismi: {productName}");
        }
    }
}
