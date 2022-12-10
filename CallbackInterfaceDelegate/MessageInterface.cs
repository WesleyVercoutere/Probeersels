namespace CallbackInterfaceDelegate;

public class MessageInterface
{
    public string Topic { get; set; }
    public IMessageHandler MessageHandler { get; set; }
}
