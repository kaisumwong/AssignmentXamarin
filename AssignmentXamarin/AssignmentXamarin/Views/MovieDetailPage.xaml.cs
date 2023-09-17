using AssignmentXamarin.Model;
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
            var htmlsource = new HtmlWebViewSource();
            htmlsource.Html = MovieDetails.MovieTrailerLink;

            TrailerDisplay.Source = htmlsource;
        }
    }
}