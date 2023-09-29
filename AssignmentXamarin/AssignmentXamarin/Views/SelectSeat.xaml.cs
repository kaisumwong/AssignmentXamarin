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

        public int W = 0;
        public int H = 0;
        public int CSId = 0;

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
                        { new Image { Source="unselect.png", HorizontalOptions = LayoutOptions.CenterAndExpand } },
                    };

                    TapGestureRecognizer tapGesture = new TapGestureRecognizer();

                    tapGesture.Tapped += async (s, arg) =>
                    {
                        var clickedItem = s as StackLayout;

                        var selectedSeatPosition = clickedItem.GestureRecognizers[0] as TapGestureRecognizer;

                        var selectedSeat = clickedItem.Children[0] as Image;


                        if (selectedSeat.Source.ToString() == "File: unselect.ppg")
                        {
                            selectedSeat.Source = "selected.png";
                            CheckOutSelectedSeat.Add(selectedSeatPosition.CommandParameter.ToString());
                            SelectedSeatList.Text = string.Join(",", CheckOutSelectedSeat);
                        }
                        else
                        {
                            selectedSeat.Source = "unselect.png";
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