using Microsoft.AspNetCore.SignalR;

namespace MalusAdmin.WebApi
{
    public class ChatHub : Hub
    {
        /// <summary>
        /// 当用户连接上
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            await Console.Out.WriteLineAsync("用户连接:" + Context.ConnectionId);
        }

        /// <summary>
        /// 用户断开连接
        /// </summary>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Console.Out.WriteLineAsync("用户断开连接:" + Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        /// <summary>
        /// 收到的消息发送所有人
        /// </summary>
        /// <param name="username"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string username, string message)
        {
            await Console.Out.WriteLineAsync("用户发送消息:" + username+ "message");
            await Clients.All.SendAsync("messageReceived", username, message);
        }

        /// <summary>
        /// 强制下线
        /// </summary>
        /// <param name="usertoken"></param>
        /// <returns></returns>
        public async Task ForceOffline(string ConnectionId)
        { 
            await  Clients.Client(ConnectionId).ForceOffline("强制下线");
        }


    }
}
