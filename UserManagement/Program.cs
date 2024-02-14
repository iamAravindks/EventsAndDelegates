using UserManagement;
using UserManagement.Notification;




Menu menu = new Menu(new SMSNotification(), new EmailNotification(),new PushNotification());


while (true)
{
    Console.WriteLine("Choose an option: ");
    Console.WriteLine("1. Add User");
    Console.WriteLine("2. Update User");
    Console.WriteLine("3. Remove User");
    Console.WriteLine("4. Exit");

    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            menu.HandleAddUser();
            break;

        case 2:
            menu.HandleUpdateUser();
            break;
        case 3:
            menu.HandleDeleteUser();
            break;
        case 4:
            Console.WriteLine("Exiting menu");
            break;
        default:
            Console.WriteLine("Wrong choice");
            break;
    }

    if (choice == 4)
    {
        break;
    }

}