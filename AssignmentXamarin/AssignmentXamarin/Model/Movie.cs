using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentXamarin.Model
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string MoviePoster { get; set; }
        public string MovieTrailerLink { get; set; }
        public double RatingStar { get; set; }
        public string MovieRating { get; set; } //G //PG //PG13 R
        public int DurationTime { get; set; }
        public string MovieStatus { get; set; } = null;


        //FOR grid
        public int InRow { get; set; }
        public int InColumn { get; set; }
    }
}
