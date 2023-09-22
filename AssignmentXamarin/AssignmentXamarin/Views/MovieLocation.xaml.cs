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
    public partial class MovieLocation : ContentPage
    {
        public MovieLocation()
        {
            InitializeComponent();

            //MovieDetailPageVM = new MovieDetailPageVM(Movies);
        }

        //protected override void OnAppearing()
        //{
        //    if (BindingContext is BaseViewModel viewModel)
        //        viewModel.LoadCommand.Execute(null);
        //}
        //private MovieDetailPageVM MovieDetailPageVM;


    }
}