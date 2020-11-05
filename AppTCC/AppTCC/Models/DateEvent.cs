using System.ComponentModel;

namespace AppTCC.Models
{
    public class DateEvent: INotifyPropertyChanged
    {
        private string date { get; set; }
        private int fatigue { get; set; }
        private int distraction { get; set; }

        public string Date
        {
            get { return date; }
            set
            {
                this.date = value;
                RaisePropertyChanged("Date");
            }
        }

        public int Fatigue
        {
            get { return fatigue; }
            set
            {
                fatigue = value;
                RaisePropertyChanged("Fatigue");
            }
        }

        public int Distraction
        {
            get { return distraction; }
            set
            {
                distraction = value;
                RaisePropertyChanged("Distraction");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
