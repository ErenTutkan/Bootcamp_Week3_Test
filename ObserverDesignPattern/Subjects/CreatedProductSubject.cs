using ObserverDesignPattern.Observers;

namespace ObserverDesignPattern.Subjects
{
    public class CreatedProductSubject
    {
        private readonly List<CreatedProductSendObserver> _observers=new List<CreatedProductSendObserver>();
        public void Subscribe(CreatedProductSendObserver observer)
        {
            _observers.Add(observer);
        }
        public void UnSubscribe(CreatedProductSendObserver observer)
        {
            _observers.Remove(observer);
        }
        public void Notify(int productId,string productName)
        {
            _observers.ForEach(o => o.SendMessage(productId, productName));
        }
    }
}
