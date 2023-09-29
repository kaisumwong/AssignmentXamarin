using AssignmentXamarin.Model;
using AssignmentXamarin.Popup;
using AssignmentXamarin.ViewModel;
using CarouselView.FormsPlugin.Abstractions;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
        private Movie movie; // 保存Movie对象
        private MovieDetailPageVM movieDetailPageVM;

        public MovieLocation()
        {
            InitializeComponent();

        }
        private List<Cinema> GenerateTimeShows()
        {
            List<Cinema> cinemas = new List<Cinema>
        {
            new Cinema("Kuala Lumpur - Lalaport BBCC"),
            new Cinema("Kuala Lumpur - Aurum, The Gardens Mall"),
            new Cinema("Kuala Lumpur - Mid Valley Megamall"),
            new Cinema("Petaling Jaya - 1 Utama (New Wing)"),
            new Cinema("Johor Bahru - The Mall,Mid Valley"),
            new Cinema("Johor Bahru - Sunway Big Box"),
            new Cinema("Kulai - IOI Mall"),
            new Cinema("Subang Jaya - Summit USJ"),
            new Cinema("Suabang Jaya - Subang Parade"),
            new Cinema("Setia Alam - Setia City Mall"),

        };

            foreach (var cinema in cinemas)
            {
                foreach (var date in GenerateDateRange(DateTime.Now, DateTime.Now.AddDays(0)))
                {
                    cinema.Showtimes[date] = GenerateRandomShowtimesWithAmPm(3, 5);

                }
            }
            return cinemas;
        }

        private Dictionary<string, List<Cinema>> CinemaLists = new Dictionary<string, List<Cinema>>();
        private List<DateTime> GenerateDateRange(DateTime startDate, DateTime endDate)
        {
            List<DateTime> dateRange = new List<DateTime>();
            DateTime currentDate = startDate;

            while (currentDate <= endDate)
            {
                dateRange.Add(currentDate);
                currentDate = currentDate.AddDays(1);
            }

            return dateRange;
        }

        private List<string> GenerateRandomShowtimesWithAmPm(int minShowings, int maxShowings)
        {
            List<string> showtimes = new List<string>();
            Random random = new Random();

            int numberOfShowings = random.Next(minShowings, maxShowings + 1);

            for (int i = 0; i < numberOfShowings; i++)
            {
                int hours = random.Next(10, 24);
                int minutes = random.Next(0, 60);
                string amPm = hours < 12 ? "AM" : "PM";

                if (hours > 12)
                {
                    hours -= 12;
                }
                else if (hours == 0)
                {
                    hours = 12;
                }

                string formattedTime = $"{hours:D2}:{minutes:D2} {amPm}";
                showtimes.Add(formattedTime);
            }

            return showtimes;
        }



        public MovieLocation(Movie movie) : this()
        {
            this.movie = movie; // 保存传递的Movie对象
            BindingContext = movie; // 设置 BindingContext 为 Movie 对象
            ShowDateStackLayouts(movie.MovieEndTime);
        }

        protected override bool OnBackButtonPressed()
        {
            if (PopupNavigation.Instance.PopupStack.Count > 0)
            {
                PopupNavigation.Instance.PopAsync();
            }

            else
            {
                Navigation.PopAsync();
            }

            return true;
        }

        protected override void OnAppearing()
        {
            if (BindingContext is BaseViewModel viewModel)
                viewModel.LoadCommand.Execute(null);
        }
        //private MovieDetailPageVM MovieDetailPageVM;

        private void ShowDateStackLayouts(DateTime movieEndTime)
        {
            // 获取当前日期
            DateTime currentDate = DateTime.Now.Date;

            // 清除所有日期的StackLayout（如果有的话）
            DateStackLayout.Children.Clear();


            bool isFirst = true;
            // 添加日期的StackLayout
            while (currentDate <= movieEndTime.Date)
            {
                CinemaLists.Add(currentDate.ToString("yyyy-MM-dd"), GenerateTimeShows());
                // 创建日期的StackLayout
                Frame dateStackLayout = new Frame
                {
                    //Orientation = StackOrientation.Vertical,
                    Padding = new Thickness(10),
                    //Spacing = 5,
                    BackgroundColor = Color.White,
                    Margin = new Thickness(0, 20, 0, 0),
                    CornerRadius = 3,


                };



                if (isFirst)
                {
                    currentDateFrame = dateStackLayout;
                    dateStackLayout.BackgroundColor = Color.Red;
                    SelectedDate = currentDate.ToString("yyyy-MM-dd");
                    isFirst = false;
                }

                StackLayout dateLabelContainer = new StackLayout
                {
                    Orientation = StackOrientation.Vertical
                };

                // 创建日期标签
                Label dateLabel = new Label
                {
                    Text = currentDate.ToString("yyyy-MM-dd"),
                    TextColor = Color.Black
                };

                dateLabelContainer.Children.Add(dateLabel);

                dateStackLayout.Content = dateLabelContainer;
                // 如果日期是过去的日期，则隐藏StackLayout

                if (currentDate < DateTime.Now.Date)
                {
                    dateStackLayout.IsVisible = false;
                }

                TapGestureRecognizer tapGesture = new TapGestureRecognizer();
                tapGesture.Tapped += MovieData_Clicked;
                tapGesture.CommandParameter = currentDate.ToString("yyyy-MM-dd");
                dateStackLayout.GestureRecognizers.Add(tapGesture);


                // 将StackLayout添加到父级StackLayout中
                DateStackLayout.Children.Add(dateStackLayout);

                // 增加当前日期
                currentDate = currentDate.AddDays(1);
            }


            BindableLayout.SetItemsSource(CinemListsView, CinemaLists.First().Value);
        }
        private Frame currentDateFrame;
        private async void MovieData_Clicked(object sender, EventArgs e)
        {
            //await this.ScaleTo(20, 1000, Easing.Linear);

            var stack = sender as Frame;
            var tapGesture = stack.GestureRecognizers[0] as TapGestureRecognizer;
            var date = tapGesture.CommandParameter.ToString();

            currentDateFrame.BackgroundColor = Color.White;
            stack.BackgroundColor = Color.Red;
            currentDateFrame = null;
            currentDateFrame = stack;

            SelectedDate = ((Label)((StackLayout)stack.Content).Children.FirstOrDefault(c => c is Label)).Text;
            BindableLayout.SetItemsSource(CinemListsView, CinemaLists[date]);

            //DisplayAlert("halo", date, "ok");

        }

        private Frame StoreMovieTime;
        private string SelectedDate;
        private string SelectedTime;

        private Frame previousSelectedFrame = null;

        private void MovieTime_Clicked(object sender, EventArgs e)
        {

            var stack = sender as Frame;

            if (previousSelectedFrame != null)
            {
                previousSelectedFrame.BackgroundColor = Color.FromHex("#363636");
                previousSelectedFrame.BorderColor = Color.White;
            }

            SelectedTime = ((Label)stack.Content).Text;
            stack.BackgroundColor = Color.Red;
            stack.BorderColor = Color.Black;

            previousSelectedFrame = stack;

            //DisplayAlert(SelectedDate, SelectedTime, "ok");
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new MovieLocationPopup(movie,SelectedTime,SelectedDate));

        }
    }
}