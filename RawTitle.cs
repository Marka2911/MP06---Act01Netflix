using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___Act01Netflix
{
    public class RawTitle : IComparable<RawTitle>
    {
        int index;
        string id;
        string title;
        string type;
        int release_Year;
        int seasons;
        double imdb_score;
        double imdb_votes;
        public RawTitle(int index, string id, string title, string type, int release_Year, int seasons, double imdb_score, double imdb_votes)
        {
            this.Index = index;
            this.Id = id;
            this.Title = title;
            this.Type = type;
            this.Release_Year = release_Year;
            this.Seasons = seasons;
            this.Imdb_score = imdb_score;
            this.Imdb_votes = imdb_votes;
        }

        public int Index { get => index; set => index = value; }
        public string Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Type { get => type; set => type = value; }
        public int Release_Year { get => release_Year; set => release_Year = value; }
        public int Seasons { get => seasons; set => seasons = value; }
        public double Imdb_score { get => imdb_score; set => imdb_score = value; }
        public double Imdb_votes { get => imdb_votes; set => imdb_votes = value; }

        public int CompareTo(RawTitle? other)
        {
            int retornar = 0;
            if (other != null)
                retornar = other.Imdb_score.CompareTo(this.Imdb_score);
            return retornar;
        }

    }
}
