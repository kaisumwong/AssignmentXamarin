using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentXamarin.Model
{
    public class Ticket
    {
        public string MovieTitle { get; set; }
        public TimeSpan ShowingDate { get; set; }
        public string Image { get; set; }
        public string Seats { get; set; }
        public string PurchaseDate { get; set; }
        public string PurchaseTime { get; set; }
    }
}
