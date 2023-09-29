using AssignmentXamarin.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AssignmentXamarin.ViewModel
{
    public class MovieTicketVM : BaseViewModel
    {
        protected override void OnLoadCommandExecute()
        {

        }

        private ObservableCollection<Ticket> ticketlist = new ObservableCollection<Ticket>();

        public ObservableCollection<Ticket> Ticketlist
        {
            get => ticketlist;
            set => SetProperty(ref ticketlist, value);
        }
        public void AddNewTicket(Ticket ticket)
        {
            Ticketlist.Add(ticket);

        }


    }
}
