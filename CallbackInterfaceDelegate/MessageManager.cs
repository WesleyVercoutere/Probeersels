namespace CallbackInterfaceDelegate;

public class MessageManager
{
    private List<MessageDelegate> _delegates;
    private List<MessageInterface> _interfaces;

    public MessageManager()
    {
        _delegates = new List<MessageDelegate>();
        _interfaces = new List<MessageInterface>();
    }

    public void AddDelegate(MessageDelegate del)
    {
        _delegates.Add(del);
    }

    public void ReceiveMessage(string topic)
    {
        var message = _delegates.Find(e => e.Topic.Equals(topic));
        message?.MessageHandler();
    }
}