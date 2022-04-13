using Microsoft.Extensions.Logging.Abstractions;
using System.Diagnostics;

namespace ObserverDesignPattern.Observers
{
    public class CreatedProductSendMailObserver : CreatedProductSendObserver
    {
       

       

        public override void SendMessage(int productId, string productName)
        {

            Debug.WriteLine($"Mail Ürün Eklenmiştir. ID: {productId} Ürün ismi: {productName}");
        }
    }
}
