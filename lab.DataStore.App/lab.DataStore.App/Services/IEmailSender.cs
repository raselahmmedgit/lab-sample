using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab.DataStore.App.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string userId, string email, string subject, string message);
        Task SendEmailAsync(string userId, string name, string email, string subject, string message);
        Task SendEmailBySendGridAsync(string userId, string email, string subject, string message);
        Task SendEmailBySendGridAsync(string userId, List<string> emailList, string subject, string message);
    }
}
