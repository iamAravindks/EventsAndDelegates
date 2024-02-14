

using UserManagement.Notification;

namespace UserManagement
{
    public class Menu
    {
        private readonly UserService _userService = null!;
        private readonly INotification<User> _smsNotification = null!;
        private readonly INotification<User> _emailNotification = null!;
        private readonly INotification<User> _pushNotification = null!;

        public Menu(SMSNotification smsNotification, EmailNotification emailNotification,PushNotification pushNotification)
        {
            _userService = new UserService();
            _smsNotification = smsNotification;
            _emailNotification = emailNotification;
            _pushNotification = pushNotification;
            _userService.UserAdded += (source, args) => { _smsNotification.Notify(args.User, "Added"); };
            _userService.UserAdded += (source, args) => { _emailNotification.Notify(args.User, "Added"); };
            _userService.UserAdded += (source, args) => { _pushNotification.Notify(args.User, "Added"); };


            _userService.UserUpdated += (source, args) => { _smsNotification.Notify(args.User, "Updated"); };
            _userService.UserUpdated += (source, args) => { _emailNotification.Notify(args.User, "Updated"); };
            _userService.UserUpdated += (source, args) => { _pushNotification.Notify(args.User, "Updated"); };


            _userService.UserRemoved += (source, args) => { _smsNotification.Notify(args.User, "Deleted"); };
            _userService.UserRemoved += (source, args) => { _emailNotification.Notify(args.User, "Deleted"); };
            _userService.UserRemoved += (source, args) => { _pushNotification.Notify(args.User, "Deleted"); };


        }

        public void HandleAddUser()
        {
            Console.WriteLine("Enter user details:");
            Console.Write("Id: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Contact: ");
            string contact = Console.ReadLine();

            User newUser = new User { Id = id, Name = name, Email = email, Contact = contact };
            _userService.Add(newUser);

            Console.WriteLine("User added successfully!\n");
        }

        public void HandleUpdateUser()
        {
            try
            {
                Console.Write("Enter the user Id to update: ");
                int userId = int.Parse(Console.ReadLine());

                User existingUser = _userService.Find(u=>u.Id == userId);
                if(existingUser != null)
                {
                    Console.WriteLine($"Current details for user with Id {userId}:");
                    Console.WriteLine($"New Name: (Just enter to leave it by default :{existingUser.Name})");
                    string name = Console.ReadLine();
                    Console.WriteLine($"New Email: (Just enter to leave it by default :{existingUser.Email})");
                    string email = Console.ReadLine();
                    Console.WriteLine($"New Contact: (Just enter to leave it by default :{existingUser.Contact})");
                    string contact = Console.ReadLine();

                    if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(contact)) return;

                    if (string.IsNullOrEmpty(name))
                    {
                        existingUser.Name = name;
                    }
                    if (string.IsNullOrEmpty(email))
                    {
                        existingUser.Email = email;
                    }
                    if (string.IsNullOrEmpty(contact))
                    {
                        existingUser.Contact = contact;
                    }

                    _userService.Update(existingUser);
                    Console.WriteLine("User updated successfully!\n");

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public void HandleDeleteUser()
        {
            try
            {
                Console.Write("Enter the user Id  to remove: ");
                int userId = int.Parse(Console.ReadLine());

                _userService.Remove(u=>u.Id == userId);
                Console.WriteLine("User removed successfully!\n");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

    }
}
