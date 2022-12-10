namespace CallbackInterfaceDelegate;

public class MessageDelegate
{
    public string Topic { get; set; }
    public Func<Task> MessageHandler;

}