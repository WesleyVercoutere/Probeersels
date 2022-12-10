namespace CallbackInterfaceDelegate;

public class App
{
    private readonly MessageManager _messageManager;
    private readonly MessageController _messageController;
    public App()
    {
        _messageManager = new MessageManager();
        _messageController = new MessageController(_messageManager);
    }

    public void Run()
    {
        _messageController.SetDelegateTopics();
        _messageController.SetInterfaceTopics();
        
        _messageManager.ReceiveMessage("delegate1");
        _messageManager.ReceiveMessage("delegate2");
        _messageManager.ReceiveMessage("delegate1");
        _messageManager.ReceiveMessage("delegate2");
        _messageManager.ReceiveMessage("delegate3");
        _messageManager.ReceiveMessage("delegate2");
    }
}
