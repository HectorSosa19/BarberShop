using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotasWorkshop.Model.Entities
{
    public class SignalR : Hub
    {
        public async Task SendMessage(string imagePath)
        {
            await Clients.All.SendAsync("ReceiveMessage", imagePath);
        }
    }
}
