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


        public SelectSeat(Movie moviedetail)
        {
            InitializeComponent();
            movieDetailPageVM = new MovieDetailPageVM(moviedetail);
            BindingContext = movieDetailPageVM;


            var mygridlayout = MyGrid as Grid;

            for (int i = 0; i < 5; i++)
            {
                for (int z = 0; z < 5; z++)
                {
                    var NewStack = new StackLayout
                    {
                        BackgroundColor = Color.White,
                        Children =
                        { new Label { Text = $"R{i} C{z}", FontSize = 20, HorizontalOptions = LayoutOptions.Center },
                        }
                    };

                    TapGestureRecognizer tapGesture = new TapGestureRecognizer();

                    tapGesture.Tapped += async (s, arg) =>
                    {
                        var clickedItem = s as StackLayout;

                        var selectedSeatPosition = clickedItem.GestureRecognizers[0] as TapGestureRecognizer;

                        var selectedSeat = clickedItem.Children[0] as Image;


                        if (selectedSeat.Source.ToString() == "File: unselect.ppg")
                        {
                            selectedSeat.Source = "selected.jpg";
                            CheckOutSelectedSeat.Add(selectedSeatPosition.CommandParameter.ToString());
                            SelectedSeatList.Text = string.Join(",", CheckOutSelectedSeat);
                        }
                        else
                        {
                            selectedSeat.Source = "unselect.jpg";
                            CheckOutSelectedSeat.Remove(selectedSeatPosition.CommandParameter.ToString());
                            SelectedSeatList.Text = string.Join(",", CheckOutSelectedSeat);
                        }

                    };

                }

            }
        }



        private MovieDetailPageVM movieDetailPageVM;


    }
}