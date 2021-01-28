using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Employees : INotifyPropertyChanged
    {
        private string name;
        private int age;
        private Enum position;
        private double experience;
        private bool retiree;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        public Enum Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged("Position");
            }
        }

        public double Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                OnPropertyChanged("Experience");
            }
        }

        public bool Retiree
        {
            get { return retiree; }
            set
            {
                retiree = value;
                OnPropertyChanged("Retiree");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
