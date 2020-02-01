using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using aQordUiWPF.Annotations;

namespace aQordUiWPF
{
    public class Craftsman : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Profession { get; set; }
        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged();

            }
        }
        public string LastName { get; set; }
        public decimal HourlyRate { get; set; }
        public double WorkingHourDaily { get; set; }
        public double WorkingHourWeekly { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
