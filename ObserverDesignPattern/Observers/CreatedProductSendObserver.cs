namespace ObserverDesignPattern.Observers
{
    public abstract class CreatedProductSendObserver
    {
       public abstract void SendMessage(int productId, string productName);
    }
}
