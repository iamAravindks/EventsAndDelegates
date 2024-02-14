

namespace UserManagement.Notification
{
    public class SMSNotification : INotification<User>
    {
        public void Notify(User user, string action)
        {
            Console.WriteLine($"SMS :{ action} performed on User with Id {user.Id} and Email {user.Email}");
        }
    }
}
