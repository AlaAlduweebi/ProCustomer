using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace CustomerUI.Model
{
    public class DbStatistic : ObservableObject
    {
        private string table;
        public string Table
        {
            get { return table; }
            set { SetProperty(ref table, value); }
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { SetProperty(ref count, value); OnPropertyChanged(nameof(Percentage)); }
        }

        private int maxcount;
        public int MaxCount
        {
            get { return maxcount; }
            set { SetProperty(ref maxcount, value); OnPropertyChanged(nameof(Percentage)); }
        }

        public double Percentage => Math.Min((double)Count / MaxCount * 100, 100);

        public DbStatistic()
        {
            table = string.Empty;
        }
    }
}
