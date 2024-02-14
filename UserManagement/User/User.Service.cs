
namespace UserManagement
{
    public class UserService
    {
        public delegate void UserActionHandler(object source , UserEventArgs args);

        public event UserActionHandler UserAdded;
        public event UserActionHandler UserUpdated;
        public event UserActionHandler UserRemoved;
        public void Add(User user)
        {
            if (UserRepository.users.Any(u => u.Id == user.Id || u.Email == user.Email))
            {
                throw new Exception("Duplicate User");
            }
            UserRepository.users.Add(user);
            Thread.Sleep(1000);
            UserAdded?.Invoke(this, new UserEventArgs
            {
                User = user,
            });
        }
        public void Remove(Predicate<User> predicate)
        {
            User? userToBeRemoved = UserRepository.users.Find(predicate);
            if (userToBeRemoved != null)
            {
                UserRepository.users.Remove(userToBeRemoved);
                UserRemoved?.Invoke(this, new UserEventArgs
                {
                    User = userToBeRemoved,
                });
            }
            else
            {
                throw new Exception("No user found");
            }

        }
        public User Update(User user)
        {
            User? existingUser = UserRepository.users.Find(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Email = user.Email;
                existingUser.Id = user.Id;
                existingUser.Name = user.Name;
                existingUser.Contact = user.Contact;
                UserUpdated?.Invoke(this, new UserEventArgs
                {
                    User = existingUser,
                });
                return existingUser;
            }
            else
            {
                throw new Exception("User not found");
            }

        }

        public User Find(Predicate<User> predicate)
        {
            User? user = UserRepository.users.Find(predicate);
            if(user != null)
            {

                return user;
            }
            else
            {
                throw new Exception("User not found");
            }

        }
    }
}
