using CustomerUI.Base;

namespace CustomerUI.Model
{
    public class TasksBottuns : BaseViewModel
    {
        public string content;
        public string Content
        {
            get { return content; }
            set { SetProperty(ref content, value); }
        }

        private string iconPath;
        public string IconPath
        {
            get { return iconPath; }
            set { SetProperty(ref iconPath, value); }
        }

        private bool isSelected;
        public bool IsSelected
        {
            get { return isSelected; }
            set { SetProperty(ref isSelected, value); }
        }

        public TasksBottuns(string content, string iconPath = null)
        {
            Content = content;
            IconPath = iconPath;
        }
    }
}
