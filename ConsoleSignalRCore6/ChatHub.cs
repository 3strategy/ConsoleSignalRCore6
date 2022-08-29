// See https://aka.ms/new-console-template for more information
// see https://www.youtube.com/watch?v=pNfSOBzHd8Y for how to on creating this.
using Microsoft.AspNetCore.SignalR;

internal class ChatHub : Hub
{
    public async Task SendMessage(string user, string message) => await Clients.Others.SendAsync("ReceiveMessage", user, message);
    public async Task SendKey(string key) => await Clients.Others.SendAsync("ReceiveKey", key);
}