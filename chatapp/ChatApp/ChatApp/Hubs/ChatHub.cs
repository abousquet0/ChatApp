using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
        public Task JoinRoom(string roomName)
        {
            Clients.Group(roomName).SendAsync(Context.User.Identity.Name + " joined.");
            return Groups.AddToGroupAsync(Context.ConnectionId, roomName);
        }

        public Task LeaveRoom(string roomName)
        {
            Clients.Group(roomName).SendAsync(Context.User.Identity.Name + " left.");
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
        }
    }
}
