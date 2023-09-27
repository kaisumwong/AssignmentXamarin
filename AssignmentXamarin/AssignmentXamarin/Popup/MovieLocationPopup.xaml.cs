using AssignmentXamarin.Model;
using AssignmentXamarin.ViewModel;
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

      
        public MovieLocationPopup(Movie MovieDetail)
        {
            InitializeComponent();
            movieDetailPageVM = new MovieDetailPageVM(MovieDetail);
            BindingContext = movieDetailPageVM;
        }

        protected override void OnAppearing()
        {
            if (BindingContext is BaseViewModel viewModel)
                viewModel.LoadCommand.Execute(null);
        }



        private MovieDetailPageVM movieDetailPageVM;
    }
}