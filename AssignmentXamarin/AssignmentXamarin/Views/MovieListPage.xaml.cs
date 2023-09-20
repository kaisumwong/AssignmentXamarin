using AssignmentXamarin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AssignmentXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieListPage : ContentPage
    {

        public static List<Movie> movies;

        public MovieListPage()
        {
            
            string trailerLinkFormat1 = "<iframe src='https://www.youtube.com/embed/";
            string trailerLinkFormat2 = "?autoplay=0&controls=0' allowtransparency='true' style='-webkit-transform:scale(1.085);-moz-transform-scale(1.085);overflow: hidden;' height='100%' width='100%' frameborder='0' marginwidth='0' marginheight='0' hspace='0' vspace='0' scrolling='no' style='border: none;'></iframe>";

            movies = new List<Movie>
            {

            new Movie{MovieID=1,Description="P12 | ENG |",MoviePoster="oppenheimer.jpeg",MovieRating="PG",DurationTime=180,MovieTrailerLink=$"{trailerLinkFormat1}uYPbbksJxIg{trailerLinkFormat2}",Title="Oppenheimer",InColumn=0,InRow=0},
            new Movie{MovieID=2,Description="Movie2",MoviePoster="Flash.jpg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}r51cYVZWKdY{trailerLinkFormat2}",Title="Flash",InColumn=1,InRow=0},
            new Movie{MovieID=3,Description="Movie3",MoviePoster="JohnWick.jpg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}qEVUtrk8_B4{trailerLinkFormat2}",Title="Johnwick 4",InColumn=2,InRow=0},
            new Movie{MovieID=4,Description="Movie4",MoviePoster="MissionImpossible.jpg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}avz06PDqDbM{trailerLinkFormat2}",Title="Mission Impossible 7",InColumn=0,InRow=1},
            new Movie{MovieID=5,Description="Movie5",MoviePoster="Movie5.jpg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}r51cYVZWKdY{trailerLinkFormat2}",Title="Movie5",InColumn=1,InRow=1},
            new Movie{MovieID=6,Description="Movie6",MoviePoster="Movie6.jpg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}r51cYVZWKdY{trailerLinkFormat2}",Title="Movie6",InColumn=2,InRow=1},
        };

            foreach(var m in movies)
            {
                m.FormattedDuration = FormatDuration(m);
            }

            InitializeComponent();
            BindableLayout.SetItemsSource(NowShowingContainer, movies);

            //NowShowingContainer.ItemsSource = movies;
            //ComingSoonContainer.BindingContext = movies;

            GetHeightRequest(movies.Count);
            MovieList.ItemsSource = movies;
        }

            public string FormatDuration(Movie movie)
            {
                if (movie.DurationTime % 60 == 0)
                {
                    int hours = movie.DurationTime / 60;

                    if (hours == 1)
                    {
                        return $"{hours} hour";
                    }
                    else
                    {
                        return $"{hours} hours";
                    }
                }
                else
                {
                    return $"{movie.DurationTime} minutes";
                }
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

            if (movieDetails != null)
            {
                Navigation.PushAsync(new MovieDetailPage(movieDetails));
            }


        }


    }
}
