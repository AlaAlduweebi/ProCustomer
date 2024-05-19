using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerUI.Interfaces
{
    public interface IMessenger
    {
        void Register<T>(object recipient, Action<T> action);
        void Send<T>(T message);
    }
}
