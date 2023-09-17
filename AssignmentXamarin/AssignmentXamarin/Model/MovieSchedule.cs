using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentXamarin.Model
{
    public class MovieSchedule
    {
        public int CSID { get; set; }
        public DateTime MovieStartTime { get; set; }
        public DateTime MovieEndTime { get; set;}
        public DateTime OrderSeatStartTime { get; set; }
        public DateTime OrderSeatEndTime { get;set; }
        public int Movie_ID { get; set; }
        public int Room_Type { get; set; }
        public int LeftSeatCount { get; set; }
        public string LeftSeatCountList { get; set; }
        public bool IsFullRooms { get; set; }
    }
}
