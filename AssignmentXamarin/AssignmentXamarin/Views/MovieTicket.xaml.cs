using AssignmentXamarin.Model;
using AssignmentXamarin.ViewModel;
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
    public partial class MovieTicket : ContentPage
    {
        private MovieTicketVM viewModel;


        public MovieTicket()
        {
            InitializeComponent();
            viewModel= new MovieTicketVM();
            this.BindingContext= viewModel;
            MessagingCenter.Subscribe<App, Ticket>((App)Application.Current, "AddTicket", (sender, ticket) =>
            {
                viewModel.AddNewTicket(ticket);
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing(); 
            if(this.BindingContext is BaseViewModel viewModel)
                viewModel.LoadCommand.Execute(null);
        }
    }
}