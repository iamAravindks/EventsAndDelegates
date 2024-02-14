using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Notification
{
    public interface INotification<T> where T : class
    {
        void Notify(T Tobj, string action);
    }
}
