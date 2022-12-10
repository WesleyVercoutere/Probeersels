namespace CallbackInterfaceDelegate;

public class MessageController
{
    private readonly MessageManager _messageManager;
    
    public MessageController(MessageManager messageManager)
    {
        _messageManager = messageManager;
    }
    
    public void SetDelegateTopics()
    {
        var del1 = new MessageDelegate
        {
            Topic = "delegate1",
            MessageHandler = HandleDelegate1
        };

        var del2 = new MessageDelegate
        {
            Topic = "delegate2",
            MessageHandler = HandleDelegate2
        };

        _messageManager.AddDelegate(del1);
        _messageManager.AddDelegate(del2);
    }

    public async Task HandleDelegate1()
    {
        Console.WriteLine("Handling delegate 1");
    }
    
    public async Task HandleDelegate2()
    {
        Console.WriteLine("Handling delegate 2");
    }

    public void SetInterfaceTopics()
    {
        
    }
}