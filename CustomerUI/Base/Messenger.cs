using CustomerUI.Interfaces;

namespace CustomerUI.Base
{
    public class Messenger : IMessenger
    {
        private static readonly Dictionary<Type, List<Action<object>>> _actions = new Dictionary<Type, List<Action<object>>>();

        public static Messenger Default { get; } = new Messenger();

        public void Register<T>(object recipient, Action<T> action)
        {
            var messageType = typeof(T);
            if (!_actions.ContainsKey(messageType))
            {
                _actions[messageType] = new List<Action<object>>();
            }

            _actions[messageType].Add(obj => action((T)obj));
        }

        public void Send<T>(T message)
        {
            var messageType = typeof(T);
            if (_actions.ContainsKey(messageType))
            {
                foreach (var action in _actions[messageType])
                {
                    action(message);
                }
            }
        }
    }
}
