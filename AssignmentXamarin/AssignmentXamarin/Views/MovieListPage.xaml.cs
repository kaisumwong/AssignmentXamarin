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
    public partial class MovieListPage : ContentPage
    {

        public static List<Movie> movies = new List<Movie>
        {
            new Movie{MovieID=1,Description="Movie1",MoviePoster="Movie1.jpg",MovieRating="PG",MovieTrailerLink="<iframe src=\"https://www.youtube.com/embed/uYPbbksJxIg?autoplay=1&mute=1&controls=0\" allowtransparency=\"true\" style=\"-webkit-transform:scale(1.085);-moz-transform-scale(1.085);overflow: hidden;\" height=\"100%\" width=\"100%\" frameborder=\"0\" marginwidth=\"0\" marginheight=\"0\" hspace=\"0\" vspace=\"0\" scrolling=\"no\" style=\"border: none;\"></iframe>",Title="Movie1"},
            new Movie{MovieID=2,Description="Movie2",MoviePoster="Movie2.jpg",MovieRating="PG",MovieTrailerLink="",Title="Movie2"},
            new Movie{MovieID=3,Description="Movie3",MoviePoster="Movie3.jpg",MovieRating="PG",MovieTrailerLink="",Title="Movie3"},
            new Movie{MovieID=4,Description="Movie4",MoviePoster="Movie4.jpg",MovieRating="PG",MovieTrailerLink="",Title="Movie4"},
            new Movie{MovieID=5,Description="Movie5",MoviePoster="Movie5.jpg",MovieRating="PG",MovieTrailerLink="",Title="Movie5"},
            new Movie{MovieID=6,Description="Movie6",MoviePoster="Movie6.jpg",MovieRating="PG",MovieTrailerLink="",Title="Movie6"},
        };

        public MovieListPage()
        {
            
            InitializeComponent();
            MovieList.ItemsSource = movies;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var x = sender as StackLayout;

            var id = x.GestureRecognizers[0] as TapGestureRecognizer;
            var movieDetails = movies.Where(z => z.MovieID == Convert.ToInt32(id.CommandParameter)).FirstOrDefault();

            Navigation.PushAsync(new MovieDetailPage(movieDetails));

        }

           
        }
    }
