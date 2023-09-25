using AssignmentXamarin.Model;
using AssignmentXamarin.ViewModel;
using CarouselView.FormsPlugin.Abstractions;
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

        public MovieLocation(Movie movie) : this()
        {
            this.movie = movie; // 保存传递的Movie对象
            BindingContext = movie; // 设置 BindingContext 为 Movie 对象
            ShowDateStackLayouts(movie.MovieEndTime);
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

            // 添加日期的StackLayout
            while (currentDate <= movieEndTime.Date)
            {
                // 创建日期的StackLayout
                StackLayout dateStackLayout = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Padding = new Thickness(10),
                    Spacing = 5,
                    BackgroundColor = Color.Red,
                    Margin = new Thickness(0,20,0,0)

                };

            

                // 创建日期标签
                Label dateLabel = new Label
                {
                    Text = currentDate.ToString("yyyy-MM-dd"),
                    TextColor = Color.White
                };

                dateStackLayout.Children.Add(dateLabel);

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
        }

        private void MovieData_Clicked(object sender, EventArgs e)
        {
            var stack = sender as StackLayout;
            var tapGesture = stack.GestureRecognizers[0] as TapGestureRecognizer;
            var date = tapGesture.CommandParameter.ToString();
            DisplayAlert("halo", date, "ok");
            
        }
    }
}