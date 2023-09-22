using AssignmentXamarin.Model;
using AssignmentXamarin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
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

            var x = sender as PancakeView;

            var id = x.GestureRecognizers[0] as TapGestureRecognizer;

            //var movieDetails = .Where(z => z.MovieID == Convert.ToInt32(id.CommandParameter.ToString())).FirstOrDefault();

          
            Navigation.PushAsync(new MovieLocation());
        }


    }
}