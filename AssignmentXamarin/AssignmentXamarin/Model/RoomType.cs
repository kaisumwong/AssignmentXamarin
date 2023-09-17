using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentXamarin.Model
{
    public class RoomType
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public int TotalSeatCount { get; set; } //3
        public string TotalSeatList { get; set; } // "A01,A02,A03"

    }
}
