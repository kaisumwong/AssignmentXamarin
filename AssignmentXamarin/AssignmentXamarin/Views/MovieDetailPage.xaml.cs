using AssignmentXamarin.Model;
using AssignmentXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssignmentXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailPage : ContentPage
    {
        public MovieDetailPage(Movie MovieDetails)
        {
            InitializeComponent();

            MovieDetailPageVM = new MovieDetailPageVM(MovieDetails);
            BindingContext = MovieDetailPageVM;

        }

        protected override void OnAppearing()
        {
            if (BindingContext is BaseViewModel viewModel)
                viewModel.LoadCommand.Execute(null);
        }
        private MovieDetailPageVM MovieDetailPageVM;

        private void BuyTicket(object sender, EventArgs e)
        { 
            Navigation.PushAsync(new MovieLocation());
        }

        //private void UpdateLabel(object sender, EventArgs e)
        //{
        //    MovieDetailPageVM.UpdateLabel();
        //}

        //private async void LoadNewData(object sender, EventArgs e)
        //{
        //    await MovieDetailPageVM.GetNewData();
        //}

        //private void DeleteFirst(object sender, EventArgs e)
        //{
        //    MovieDetailPageVM.DeleteFirst();
        //}
    }
}