using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace CustomerUI.Model
{
    public class DatabaseHistory : ObservableObject
    {
        private string user;
        public string User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }
        private string action;
        public string Action
        {
            get { return action; }
            set { action = value; }
        }
        private DateOnly date;
        public DateOnly Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }
        private TimeSpan time;
        public TimeSpan Time
        {
            get { return time; }
            set { SetProperty(ref time, value); }
        }

        public DatabaseHistory()
        {
            user = string.Empty;
            action = string.Empty;
            date = new DateOnly();
            time = new TimeSpan();
        }
    }
}
