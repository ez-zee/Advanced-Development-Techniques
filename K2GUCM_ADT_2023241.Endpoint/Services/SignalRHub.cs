using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace K2GUCM_ADT_2023241.Endpoint.Services
{
    public class SignalRHub : Hub //inherits from Hub class & enables server-client communication
    {
        public override Task OnConnectedAsync() //is called when client connects the hub
        {
            Clients.Caller.SendAsync("Connected", Context.ConnectionId); //successful connection & its id
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception) //same logic when disconnected
        {
            Clients.Caller.SendAsync("Disconnected", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
