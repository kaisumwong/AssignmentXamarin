using AssignmentXamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static List<MovieSchedule> schedules;
        public static List<Movie> expiremovie;

        public MovieListPage()
        {

            string trailerLinkFormat1 = "<iframe src='https://www.youtube.com/embed/";
            string trailerLinkFormat2 = "?autoplay=0&controls=0' allowtransparency='true' style='-webkit-transform:scale(1.085);-moz-transform-scale(1.085);overflow: hidden;' height='100%' width='100%' frameborder='0' marginwidth='0' marginheight='0' hspace='0' vspace='0' scrolling='no' style='border: none;'></iframe>";

            movies = new List<Movie>
            {

            new Movie{MovieID=1,Description="P12 | ENG |",Subtitle="Bahasa Melayu,Chinese,English",MovieEndTime=DateTime.Parse("2023-09-23"),MovieCasts="Cillian Murphy , Emily Blunt",MovieSynopsis="Oppenheimer is a 2023 epic biographical thriller film[5] written and directed by Christopher Nolan and starring Cillian Murphy as J. Robert Oppenheimer, the American theoretical physicist credited with being the \"father of the atomic bomb\" for his role in the Manhattan Project—the World War II undertaking that developed the first nuclear weapons",MoviePoster="oppenheimer.jpeg",MovieRating="PG",DurationTime=new TimeSpan(3,0,0),MovieTrailerLink=$"{trailerLinkFormat1}uYPbbksJxIg{trailerLinkFormat2}",Title="Oppenheimer",InColumn=0,InRow=0},
            new Movie{MovieID=2,Description="P13 | ENG |",Subtitle="Bahasa Melayu,Chinese,English",MovieEndTime=DateTime.Parse("2023-09-26"),MovieCasts="Ezra Miller , Sasha Calle",MoviePoster="Flash.jpg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}r51cYVZWKdY{trailerLinkFormat2}",Title="Flash",InColumn=1,InRow=0,DurationTime=new TimeSpan(2,10,0),MovieSynopsis="After helping Bruce Wayne / Batman and Diana Prince / Wonder Woman stop a robbery in Gotham City, Barry Allen revisits his childhood home, where he lived with his parents Nora and Henry, before Henry's wrongful imprisonment for Nora's murder.[a] On the day of her death, Nora sent Henry to the grocery store for a can of tomatoes that she forgot to buy, leaving her alone in the kitchen, resulting in her being killed by an unidentified assailant.[b] Overcome by emotions, Barry accidentally uses the Speed Force to form a \"Chronobowl\" and travel back in time earlier in the day. Despite Bruce's warnings of time travel's unintended consequences, Barry time travels and places the can of tomatoes in Nora's cart at the store, so that his father will not have to leave the house. As he returns to the present, Barry is knocked out of the Chronobowl by an unknown speedster and ends up in a 2013 where Nora is alive. He encounters his parents, his past self, and realizes this is the day he originally obtained his powers."},
            new Movie{MovieID=3,Description="P18 | ENG |",Subtitle="Bahasa Melayu,Chinese,English",MovieEndTime=DateTime.Parse("2023-09-26"),MovieCasts="Keanu Reeves,Donnie Yen",MoviePoster="JohnWick.jpg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}qEVUtrk8_B4{trailerLinkFormat2}",Title="Johnwick 4",InColumn=2,InRow=0,DurationTime=new TimeSpan(2,0,0),MovieSynopsis="In New York City, John Wick prepares to exact vengeance against the High Table while hiding underground with the Bowery King. He travels to Morocco and kills the Elder, the \"one who sits above the Table\". In response, the Marquis Vincent Bisset de Gramont, a High Table member, summons New York Continental hotel manager Winston and his concierge, Charon, explains that the High Table has given him unlimited resources to kill John, and chastises Winston for previously failing to do so. As punishment, the Marquis strips Winston of his managerial duties, declares him \"excommunicado\", destroys the New York Continental, and executes Charon. The Marquis then enlists Caine – a blind, retired High Table assassin – to kill his old friend John, threatening to murder Caine's daughter if he refuses."},
            new Movie{MovieID=4,Description="P16 | ENG |",Subtitle="Bahasa Melayu,Chinese,English",MovieEndTime=DateTime.Parse("2023-09-28"),MovieCasts="Tom Cruise , Hayley Atwell",MoviePoster="MissionImpossible7.jpg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}avz06PDqDbM{trailerLinkFormat2}",Title="Mission Impossible 7",InColumn=0,InRow=1,DurationTime=new TimeSpan(2,30,0),MovieSynopsis="The next-generation Russian submarine Sevastopol employs an advanced AI, activated by a two-pieced cruciform key. The AI deceives the crew into attacking a falsely hostile target, only to fire its own torpedo back on itself, sinking the ship and killing all aboard.\r\n\r\nIMF agent Ethan Hunt travels to the Empty Quarter of the Arabian Desert to retrieve one-half of the key from disavowed MI6 agent Ilsa Faust, who carries a bounty from an unknown source. Ethan retrieves the half-key and fakes Ilsa's death. Back in Washington D.C., Ethan infiltrates a U.S. Intelligence Community briefing for Director of National Intelligence Denlinger to discuss the rogue AI. Director Eugene Kittridge recounts how the \"Entity\" has achieved sentience and can manipulate major defense, intelligence, and financial networks of the world at will. World powers compete to obtain the key to control the Entity, though the exact means of controlling it are unknown. Revealing himself and exposing Kittridge's bounty on Ilsa, Ethan states his intention to destroy the Entity. Knowing he will be racing against all world powers including the US, he and his IMF teammates Benji Dunn and Luther Stickell travel to Abu Dhabi International Airport to intercept the holder of the other half-key."},
            new Movie{MovieID=5,Description="P12 | ENG |",Subtitle="Bahasa Melayu,Chinese,English",MovieEndTime=DateTime.Parse("2023-09-29"),MovieCasts="Harrison Ford , Phoebe Waller-Bridge",MoviePoster="IndianaJones.jpeg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}eQfMbSe7F2g{trailerLinkFormat2}",Title="Indiana Jones",InColumn=1,InRow=1,DurationTime=new TimeSpan(2,45,0), MovieSynopsis = "In 1944, Nazis capture Indiana Jones and Oxford archeologist Basil Shaw as they attempt to retrieve the Lance of Longinus from a castle in the French Alps. Astrophysicist Jürgen Voller informs his superiors the Lance is fake, but he has found half of Archimedes' Dial, an Antikythera mechanism built by the ancient Syracusan mathematician Archimedes which reveals time fissures, allowing for possible time travel. Indy escapes onto a Berlin-bound train filled with looted antiquities and frees Basil. He obtains the Dial piece, and the two leap from the train just before Allied forces derail it."},
            new Movie{MovieID=6,Description="P12 | ENG |",Subtitle="Bahasa Melayu,Chinese,English",MovieEndTime=DateTime.Parse("2023-09-30"),MovieCasts="Suzume Iwato , Souta Munakata",MoviePoster="Suzume.jpg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}5pTcio2hTSw{trailerLinkFormat2}",Title="Suzume",InColumn=2,InRow=1,DurationTime=new TimeSpan(2,0,0), MovieSynopsis = "Suzume Iwato is a 17-year-old high school girl, who lives with her aunt in a quiet town in the Kyushu region of Japan. While heading to school, she encounters a young man searching for an abandoned area with a door, so she informs him of an abandoned onsen (spa) resort nearby, and curiously follows him. There, she discovers a door standing alone on its frame. She opens it to witness a starlit field inside, which she can't enter. She trips over a cat statue on the floor, which turns into a real cat and flees. Frightened, Suzume rushes back to school."},



        };

            InitializeComponent();
            FilterMovies();
            GetHeightRequest(movies.Count);

            expiremovie = new List<Movie>
            {
                  new Movie{MovieID=1,Description="P12 | ENG |",Subtitle="Bahasa Melayu,Chinese,English",MovieEndTime=DateTime.Parse("2023-09-23"),MovieCasts="Cillian Murphy , Emily Blunt",MovieSynopsis="Oppenheimer is a 2023 epic biographical thriller film[5] written and directed by Christopher Nolan and starring Cillian Murphy as J. Robert Oppenheimer, the American theoretical physicist credited with being the \"father of the atomic bomb\" for his role in the Manhattan Project—the World War II undertaking that developed the first nuclear weapons",MoviePoster="oppenheimer.jpeg",MovieRating="PG",DurationTime=new TimeSpan(3,0,0),MovieTrailerLink=$"{trailerLinkFormat1}uYPbbksJxIg{trailerLinkFormat2}",Title="Oppenheimer",InColumn=0,InRow=0},
            new Movie{MovieID=2,Description="P13 | ENG |",Subtitle="Bahasa Melayu,Chinese,English",MovieEndTime=DateTime.Parse("2023-09-26"),MovieCasts="Ezra Miller , Sasha Calle",MoviePoster="Flash.jpg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}r51cYVZWKdY{trailerLinkFormat2}",Title="Flash",InColumn=1,InRow=0,DurationTime=new TimeSpan(2,10,0),MovieSynopsis="After helping Bruce Wayne / Batman and Diana Prince / Wonder Woman stop a robbery in Gotham City, Barry Allen revisits his childhood home, where he lived with his parents Nora and Henry, before Henry's wrongful imprisonment for Nora's murder.[a] On the day of her death, Nora sent Henry to the grocery store for a can of tomatoes that she forgot to buy, leaving her alone in the kitchen, resulting in her being killed by an unidentified assailant.[b] Overcome by emotions, Barry accidentally uses the Speed Force to form a \"Chronobowl\" and travel back in time earlier in the day. Despite Bruce's warnings of time travel's unintended consequences, Barry time travels and places the can of tomatoes in Nora's cart at the store, so that his father will not have to leave the house. As he returns to the present, Barry is knocked out of the Chronobowl by an unknown speedster and ends up in a 2013 where Nora is alive. He encounters his parents, his past self, and realizes this is the day he originally obtained his powers."},
            new Movie{MovieID=3,Description="P18 | ENG |",Subtitle="Bahasa Melayu,Chinese,English",MovieEndTime=DateTime.Parse("2023-09-26"),MovieCasts="Keanu Reeves,Donnie Yen",MoviePoster="JohnWick.jpg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}qEVUtrk8_B4{trailerLinkFormat2}",Title="Johnwick 4",InColumn=2,InRow=0,DurationTime=new TimeSpan(2,0,0),MovieSynopsis="In New York City, John Wick prepares to exact vengeance against the High Table while hiding underground with the Bowery King. He travels to Morocco and kills the Elder, the \"one who sits above the Table\". In response, the Marquis Vincent Bisset de Gramont, a High Table member, summons New York Continental hotel manager Winston and his concierge, Charon, explains that the High Table has given him unlimited resources to kill John, and chastises Winston for previously failing to do so. As punishment, the Marquis strips Winston of his managerial duties, declares him \"excommunicado\", destroys the New York Continental, and executes Charon. The Marquis then enlists Caine – a blind, retired High Table assassin – to kill his old friend John, threatening to murder Caine's daughter if he refuses."},
            new Movie{MovieID=4,Description="P16 | ENG |",Subtitle="Bahasa Melayu,Chinese,English",MovieEndTime=DateTime.Parse("2023-09-28"),MovieCasts="Tom Cruise , Hayley Atwell",MoviePoster="MissionImpossible7.jpg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}avz06PDqDbM{trailerLinkFormat2}",Title="Mission Impossible 7",InColumn=0,InRow=1,DurationTime=new TimeSpan(2,30,0),MovieSynopsis="The next-generation Russian submarine Sevastopol employs an advanced AI, activated by a two-pieced cruciform key. The AI deceives the crew into attacking a falsely hostile target, only to fire its own torpedo back on itself, sinking the ship and killing all aboard.\r\n\r\nIMF agent Ethan Hunt travels to the Empty Quarter of the Arabian Desert to retrieve one-half of the key from disavowed MI6 agent Ilsa Faust, who carries a bounty from an unknown source. Ethan retrieves the half-key and fakes Ilsa's death. Back in Washington D.C., Ethan infiltrates a U.S. Intelligence Community briefing for Director of National Intelligence Denlinger to discuss the rogue AI. Director Eugene Kittridge recounts how the \"Entity\" has achieved sentience and can manipulate major defense, intelligence, and financial networks of the world at will. World powers compete to obtain the key to control the Entity, though the exact means of controlling it are unknown. Revealing himself and exposing Kittridge's bounty on Ilsa, Ethan states his intention to destroy the Entity. Knowing he will be racing against all world powers including the US, he and his IMF teammates Benji Dunn and Luther Stickell travel to Abu Dhabi International Airport to intercept the holder of the other half-key."},
            new Movie{MovieID=5,Description="P12 | ENG |",Subtitle="Bahasa Melayu,Chinese,English",MovieEndTime=DateTime.Parse("2023-09-29"),MovieCasts="Harrison Ford , Phoebe Waller-Bridge",MoviePoster="IndianaJones.jpeg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}eQfMbSe7F2g{trailerLinkFormat2}",Title="Indiana Jones",InColumn=1,InRow=1,DurationTime=new TimeSpan(2,45,0), MovieSynopsis = "In 1944, Nazis capture Indiana Jones and Oxford archeologist Basil Shaw as they attempt to retrieve the Lance of Longinus from a castle in the French Alps. Astrophysicist Jürgen Voller informs his superiors the Lance is fake, but he has found half of Archimedes' Dial, an Antikythera mechanism built by the ancient Syracusan mathematician Archimedes which reveals time fissures, allowing for possible time travel. Indy escapes onto a Berlin-bound train filled with looted antiquities and frees Basil. He obtains the Dial piece, and the two leap from the train just before Allied forces derail it."},
            new Movie{MovieID=6,Description="P12 | ENG |",Subtitle="Bahasa Melayu,Chinese,English",MovieEndTime=DateTime.Parse("2023-09-30"),MovieCasts="Suzume Iwato , Souta Munakata",MoviePoster="Suzume.jpg",MovieRating="PG",MovieTrailerLink=$"{trailerLinkFormat1}5pTcio2hTSw{trailerLinkFormat2}",Title="Suzume",InColumn=2,InRow=1,DurationTime=new TimeSpan(2,0,0), MovieSynopsis = "Suzume Iwato is a 17-year-old high school girl, who lives with her aunt in a quiet town in the Kyushu region of Japan. While heading to school, she encounters a young man searching for an abandoned area with a door, so she informs him of an abandoned onsen (spa) resort nearby, and curiously follows him. There, she discovers a door standing alone on its frame. She opens it to witness a starlit field inside, which she can't enter. She trips over a cat statue on the floor, which turns into a real cat and flees. Frightened, Suzume rushes back to school."},
            };

            FilterExpireMovies();
            GetHeightRequest(expiremovie.Count);

        }



        public static List<Movie> Expiremovie;

        public ObservableCollection<Movie> Movies { get; set; }


        private void RearrangeMovies()
        {
            int maxRowsPerColumn = Movies.Count / 3; // 假设平均分布
            int columnCount = 3;
            int rowIndex = 0;
            int columnIndex = 0;

            foreach (var movie in Movies)
            {
                movie.InColumn = columnIndex;
                movie.InRow = rowIndex;

                rowIndex++;

                if (rowIndex >= maxRowsPerColumn)
                {
                    rowIndex = 0;
                    columnIndex++;

                    if (columnIndex >= columnCount)
                    {
                        columnIndex = 0;
                    }
                }
            }
        }

        private void FilterMovies()
        {
            var currentDate = DateTime.Now;
            Movies = new ObservableCollection<Movie>(movies.Where(movie => movie.MovieEndTime.Date >= currentDate.Date));

            RearrangeMovies();
            OnPropertyChanged(nameof(Movies));
            MovieList.ItemsSource = Movies;
            BindableLayout.SetItemsSource(NowShowingContainer, Movies);
        }

        private void FilterExpireMovies()
        {
            var currentDate = DateTime.Now;
            Movies = new ObservableCollection<Movie>(expiremovie.Where(movie => movie.MovieEndTime.Date < currentDate.Date));

            RearrangeMovies();
            OnPropertyChanged(nameof(Movies));
            BindableLayout.SetItemsSource(ExpireMovieContainer, Movies);
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
                ExpireMovieContainer.HeightRequest = heightRequest;
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
