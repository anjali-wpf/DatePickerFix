using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WpfApp1
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            this.username = "Ravi";
            this.Date = DateTime.Now;
            this.ageGroups = new List<string> { "1-10", "11-20", "20+" };
        }

        private string username;
        public string UserName
        {
            get => this.username;
            set
            {
                this.username = value;
                NotifyPropertyChanged(nameof(UserName));
            }
        }

        private List<string> ageGroups;
        public List<string> AgeGroups
        {
            get => this.ageGroups;
            set
            {
                this.ageGroups = value;
                NotifyPropertyChanged(nameof(AgeGroups));
            }
        }

        private DateTime? date;
        public DateTime? Date
        {
            get => this.date;

            set
            {
                this.date = value;
                NotifyPropertyChanged(nameof(Date));
            }
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                this.PropertyChanged(this, args);
            }
        }
    }
}
