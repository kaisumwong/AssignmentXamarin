using AssignmentXamarin.Model;
using AssignmentXamarin.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentXamarin.ViewModel
{
    public class MovieLocationVM : BaseViewModel
    {


        public MovieLocationVM()
        {
            MovieSchedule = new MovieSchedule();
        }

        public MovieLocationVM(MovieSchedule moviedeschedule)
        {
            MovieSchedule = moviedeschedule;
        }


        protected override void OnLoadCommandExecute()
        {

        }

        private MovieSchedule movieschedule;

        public MovieSchedule MovieSchedule
        {
            get { return movieschedule; }
            set { SetProperty(ref movieschedule, value); }
        }


    }
}
