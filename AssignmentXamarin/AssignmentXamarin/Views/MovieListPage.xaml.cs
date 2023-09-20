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
            new Movie{MovieID=1,Description="Story,Drama",MoviePoster="oppenheimer.jpeg",MovieRating="PG",DurationTime=180,MovieTrailerLink="<iframe src=\"https://www.youtube.com/embed/uYPbbksJxIg?autoplay=1&iv_load_policy=3&controls=0&disablekb=1&fs=0&color=white\" width=\"370\" height=\"310\" frameborder=\"0\"></iframe>",Title="Movie1",InColumn=0,InRow=0},
            new Movie{MovieID=2,Description="Movie2",MoviePoster="Flash.jpg",MovieRating="PG",MovieTrailerLink="<iframe width=\"370\" height=\"310\" src=\"https://www.youtube.com/embed/hebWYacbdvc?si=YhHr331kYL9mgfpD&amp;controls=0&amp;start=1\" title=\"YouTube video player\" frameborder=\"0\" allow=\"accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share\" allowfullscreen></iframe>",Title="Movie2",InColumn=1,InRow=0},
            new Movie{MovieID=3,Description="Movie3",MoviePoster="Movie3.jpg",MovieRating="PG",MovieTrailerLink="",Title="Movie3",InColumn=2,InRow=0},
            new Movie{MovieID=4,Description="Movie4",MoviePoster="Movie4.jpg",MovieRating="PG",MovieTrailerLink="",Title="Movie4",InColumn=0,InRow=1},
            new Movie{MovieID=5,Description="Movie5",MoviePoster="Movie5.jpg",MovieRating="PG",MovieTrailerLink="",Title="Movie5",InColumn=1,InRow=1},
            new Movie{MovieID=6,Description="Movie6",MoviePoster="Movie6.jpg",MovieRating="PG",MovieTrailerLink="",Title="Movie6",InColumn=2,InRow=1},
        };

        public MovieListPage()
        {

            InitializeComponent();
            BindableLayout.SetItemsSource(NowShowingContainer, movies);

            //NowShowingContainer.ItemsSource = movies;
            //ComingSoonContainer.BindingContext = movies;
            GetHeightRequest(movies.Count);
            MovieList.ItemsSource = movies;
        }
        private void UpdateHeightRequest(object sender, Xamarin.CommunityToolkit.UI.Views.TabSelectionChangedEventArgs e)
        {
            //Get Up Coming Movie Count
            var positionNow = e.NewPosition;
            double heightRequest = 0;
            if (positionNow == 0)
            {
                //Showing
                heightRequest = GetHeightRequest(movies.Count);
                NowShowingContainer.HeightRequest = heightRequest;
            }
            else if (positionNow == 1)
            {
                //UpComing
                heightRequest = GetHeightRequest(7);
                ComingSoonContainer.HeightRequest = heightRequest;
            }        

        }
        private double GetHeightRequest(int moviesCount)
        {
            int numberOfMovies = moviesCount;
            int moviesPerRow = 3;
            int numberOfRows = (int)Math.Ceiling((double)numberOfMovies / moviesPerRow);
            double heightRequest = numberOfRows * 230;
            int SLIDERHEIGHT = 450;
            MainPageContainer.HeightRequest = heightRequest + SLIDERHEIGHT;

            return heightRequest + SLIDERHEIGHT;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var x = sender as Image;

            var id = x.GestureRecognizers[0] as TapGestureRecognizer;
            var movieDetails = movies.Where(z => z.MovieID == Convert.ToInt32(id.CommandParameter.ToString())).FirstOrDefault();
            
            if( movieDetails != null )
            {              
                Navigation.PushAsync(new MovieDetailPage(movieDetails));
            }


        }


    }
}
