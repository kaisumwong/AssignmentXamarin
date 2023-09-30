using AssignmentXamarin.Model;
using AssignmentXamarin.ViewModel;
using SkiaSharp;
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
    public partial class SelectSeat : ContentPage
    {
        public static List<string> CheckOutSelectedSeat = new List<string>();

        //public int W = 0;
        //public int H = 0;
        //public int CSId = 0;

        private string SelectedDate;
        private string SelectedTime;

        public SelectSeat(Movie moviedetail, string selectedTime , string selectedDate)
        {
            InitializeComponent();
            movieDetailPageVM = new MovieDetailPageVM(moviedetail);
            BindingContext = movieDetailPageVM;

            SelectedTime = selectedTime;
            SelectedDate = selectedDate;

            ShowDate.Text = SelectedDate;
            ShowTime.Text = SelectedTime;

            var mygridlayout = MyGrid as Grid;

            for (int i = 0; i < 5; i++)
            {
                for (int z = 0; z < 5; z++)
                {
                    var NewStack = new StackLayout
                    {
                        BackgroundColor = Color.Transparent,
                        Children =
                        { new Image { Source="unselect.png", HorizontalOptions = LayoutOptions.CenterAndExpand} },
                        HeightRequest= 5,
                        WidthRequest= 5,   
                        Spacing= 10, 
                        Margin = 10
                    };


                    TapGestureRecognizer tapGesture = new TapGestureRecognizer();
                    tapGesture.CommandParameter = $"R{i} C{z}";
                    tapGesture.Tapped += async (s, arg) =>
                    {

                        int selectedSeatCount = 0;

                        var clickedItem = s as StackLayout;
                        var selectedSeat = clickedItem.Children[0] as Image;
                        var selectedSeatPosition = clickedItem.GestureRecognizers[0] as TapGestureRecognizer;

                        if (selectedSeat.Source.ToString() == "File: unselect.png")
                        {
                            selectedSeat.Source = "selected.png";
                            CheckOutSelectedSeat.Add(selectedSeatPosition.CommandParameter.ToString());
               
                            SelectedSeatList.Text = string.Join(",", CheckOutSelectedSeat);
                            selectedSeatCount++;
                        }
                        else
                        {
                            selectedSeat.Source = "unselect.png";
                            CheckOutSelectedSeat.Remove(selectedSeatPosition.CommandParameter.ToString());
                            SelectedSeatList.Text = string.Join(",", CheckOutSelectedSeat);
                            selectedSeatCount--;
                        }

                        decimal totalPrice = CheckOutSelectedSeat.Count * 12; // 假设每张票12块

                        TotalPriceLabel.Text = $"Total Price: RM{totalPrice.ToString("0.00")}";
                    };

                    NewStack.GestureRecognizers.Add(tapGesture);

                    mygridlayout.Children.Add(NewStack, z, i);
                    
                }

            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            // 清空SelectedSeatList文本
            SelectedSeatList.Text = string.Empty;

            // 清空CheckOutSelectedSeat列表（假设它是一个List<string>）
            CheckOutSelectedSeat.Clear();
        }



        private MovieDetailPageVM movieDetailPageVM;

        private Ticket ticket;

        private async void TicketConfirmButton_Clicked(object sender, EventArgs e)
        {
            ticket = new Ticket()
            {
                MovieTitle = movieDetailPageVM.Movie.Title,
                Image = movieDetailPageVM.Movie.MoviePoster,
                Seats = string.Join(",",CheckOutSelectedSeat),
                ShowingDate = movieDetailPageVM.Movie.DurationTime,
            };
            MessagingCenter.Send<App, Ticket>((App)Application.Current, "AddTicket", ticket);
            await DisplayAlert("","Payment Successful", "Ok");
            Navigation.PopToRootAsync();
        }



    }
}