using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
        Task SendSmsAsync(string userId, string name, string number, string message);
    }
}
