using AssignmentXamarin.Model;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AssignmentXamarin.ViewModel
{
    public class MovieDetailPageVM : BaseViewModel
    {

        public MovieDetailPageVM()
        {
            Movie = new Movie();
            
        }

        public MovieDetailPageVM(Movie movie)
        {
            Movie = movie;

            var htmlsource = new HtmlWebViewSource();
            htmlsource.Html = Movie.MovieTrailerLink;
            FormattedYoutubeList = htmlsource;
        }

        protected override void OnLoadCommandExecute()
        {
    
        }

        private Movie movie;
        public Movie Movie
        {
            get { return movie; }
            set { SetProperty(ref movie, value); }
        }

        private HtmlWebViewSource formattedYoutubeList;

        public HtmlWebViewSource FormattedYoutubeList
        {
            get => formattedYoutubeList;
            set => SetProperty(ref formattedYoutubeList, value);
        }


    }
}
