using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebApplication1;

[Authorize]
public class MyHub : Hub<IMyClient>
{
    public override async Task OnConnectedAsync()
    {
        Clients.Client(Context.ConnectionId).Receive($"Hello, {Context.User?.Identity?.Name}");
        await base.OnConnectedAsync();
    }
}

public interface IMyClient
{
    Task Receive(string message);
}