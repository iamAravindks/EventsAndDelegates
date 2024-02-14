

namespace UserManagement.Notification
{
    public class EmailNotification : INotification<User>
    {
        public void Notify(User user, string action)
        {
            Console.WriteLine($"Email :{action} perfomed on User with Id {user.Id} and Email {user.Email}");
        }
    }
}
