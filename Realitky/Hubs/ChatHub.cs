using Microsoft.AspNetCore.SignalR;
using Realitky.Models.Entity;
using WebApplication4.Models;

namespace Realitky.Hubs;

public class ChatHub : Hub
{
    MyContext db = new MyContext();
    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"{Context.ConnectionId} connected");
        return base.OnConnectedAsync();
    }
    
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"{Context.ConnectionId} disconnected");
        return base.OnDisconnectedAsync(exception);
    }

    public async Task SendMessage(int ThreadID, int UserId, string message) 
    {
        Request_user thread = db.Request_user.Find(ThreadID);
        User user = db.Users.Find(UserId);
        if (user == null || thread == null)
            return;
            
        //Check if user should have access to this thread
        Offer offer = db.Offers.Find(thread.IdOffer);
        if (offer.IdDealer != UserId && thread.IdUser != UserId && user.IdRole != 2){ //only dealer, user and admin can send messages to this thread
            await Clients.Client(Context.ConnectionId).SendAsync("ErrorMessage", "You don't have access to this thread");
            return;
        }
        
        Message msg = new Message();
            msg.IdThread = ThreadID;
            msg.IdSender = UserId;
            msg.content = message;
            msg.sent_at = DateTime.Now;
        db.Message.Add(msg);
        db.SaveChanges();
        
        Console.WriteLine("Message received");
        await Clients.All.SendAsync("ReceiveMessage", user.username, user.avatar, message, msg.sent_at.ToString("HH:mm"));
    }
    
    // Make threads groups
    public async Task JoinGroup(string threadId)
    {
        Console.WriteLine("Group joined");
        await Groups.AddToGroupAsync(Context.ConnectionId, threadId);
        await Clients.Group(threadId).SendAsync("ReceiveMessage", $"{Context.ConnectionId} has joined the thread {threadId}.");
    }
}