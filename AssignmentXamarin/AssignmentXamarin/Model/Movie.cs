using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace AssignmentXamarin.Model
{
    public class Movie : INotifyPropertyChanged
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

        public int MovieID { get; set; }
        private string title;
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string MoviePoster { get; set; }
        public string MovieTrailerLink { get; set; }
        public double RatingStar { get; set; }
        public string MovieRating { get; set; } //G //PG //PG13 R
        public TimeSpan DurationTime { get; set; }
        public string MovieStatus { get; set; } = null;
        public string FormattedDuration { get; set; }
        public string MovieCasts { get; set; }
        public string MovieSynopsis { get; set; }
        public string Subtitle { get; set; }
        public DateTime MovieStartTime { get; set; }
        public DateTime MovieEndTime { get; set; }

        public List<MovieSchedule> Schedules { get; set; }
        //FOR grid
        public int InRow { get; set; }
        public int InColumn { get; set; }
    }
}
