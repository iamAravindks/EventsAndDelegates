using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Notification
{
    public class PushNotification : INotification<User>
    {
        public void Notify(User user, string action)
        {
            Console.WriteLine($"Push Notification :{action} performed on User with Id {user.Id} and Email {user.Email}");
        }
    }
}
