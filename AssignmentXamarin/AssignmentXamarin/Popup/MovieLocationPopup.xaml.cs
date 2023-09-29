using AssignmentXamarin.Model;
using AssignmentXamarin.ViewModel;
using AssignmentXamarin.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssignmentXamarin.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieLocationPopup 
    {
        private string SelectedDate;
        private string SelectedTime;
        private MovieLocation movieLocation;

        public MovieLocationPopup(string selectedDate, string selectedTime, MovieLocation movieLocation)
        {
            SelectedDate = selectedDate;
            SelectedTime = selectedTime;
            this.movieLocation = movieLocation;

        }

        public MovieLocationPopup(Movie MovieDetail,string selectedDate,string selectedTime)
        {
            InitializeComponent();
            movieDetailPageVM = new MovieDetailPageVM(MovieDetail);
            BindingContext = movieDetailPageVM;
            MovieDateLabel.Text = selectedDate;
            MovieTimeLabel.Text = selectedTime;
        }

        protected override void OnAppearing()
        {
            if (BindingContext is BaseViewModel viewModel)
                viewModel.LoadCommand.Execute(null);
        }



        private MovieDetailPageVM movieDetailPageVM;


        private void SelectSeatButton_Clicked(object sender, EventArgs e)
        {
            var SelectSeatView = new SelectSeat(movieDetailPageVM.Movie, SelectedDate, SelectedTime);
            PopupNavigation.Instance.PopAsync();
            Navigation.PushAsync(SelectSeatView);   
        }
    }
}