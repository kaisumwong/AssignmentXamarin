using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AssignmentXamarin.Model
{
    public class MovieSchedule :INotifyPropertyChanged
    {
        protected bool SetProperty<T>(ref T backingStore, T value,
          [CallerMemberName] string propertyName = "",
          Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int CSID { get; set; }

        public DateTime OrderSeatStartTime { get; set; }
        public DateTime OrderSeatEndTime { get;set; }
        //public int Movie_ID { get; set; }
        public int Room_Type { get; set; }
        public int LeftSeatCount { get; set; }
        public string LeftSeatCountList { get; set; }
        public bool IsFullRooms { get; set; }
    }
}
