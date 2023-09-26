using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentXamarin.Model
{
    public class Cinema
    {
        public string Name { get; set; }
        public List<DateTime> Dates { get; set; }
        public Dictionary<DateTime, List<string>> Showtimes { get; set; }

        public Cinema(string name)
        {
            Name = name;
            Showtimes = new Dictionary<DateTime, List<string>>();
        }


    }
}
