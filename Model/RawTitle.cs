using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___Act01Netflix.Model
{
    public class RawTitle : IComparable<RawTitle>
    {
        int index;
        string id;
        string title;
        string type;
        int? release_Year;
        int? seasons;
        double? imdb_score;
        double? imdb_votes;
        public RawTitle(int index, string id, string title, string type, int release_Year, int seasons, double imdb_score, double imdb_votes)
        {
            Index = index;
            Id = id;
            Title = title;
            Type = type;
            Release_Year = release_Year;
            Seasons = seasons;
            Imdb_score = imdb_score;
            Imdb_votes = imdb_votes;
        }

        public int Index { get => index; set => index = value; }
        public string Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Type { get => type; set => type = value; }
        public int? Release_Year { get => release_Year; set => release_Year = value; }
        public int? Seasons { get => seasons; set => seasons = value; }
        public double? Imdb_score { get => imdb_score; set => imdb_score = value; }
        public double? Imdb_votes { get => imdb_votes; set => imdb_votes = value; }

        public override string ToString()
        {
            return $"{Index}; {Id}; {Title}; {Type}; {Release_Year}; {Seasons}; {Imdb_score}; {imdb_votes}";
        }
        public int CompareTo(RawTitle? other)
        {
            int retornar = 0;
            if (other != null && other.Imdb_score != null & imdb_score != null)
            {
                if (other.imdb_score.Value == imdb_score.Value)
                {
                    title.CompareTo(other.title);
                }
                retornar = other.Imdb_score.Value.CompareTo(Imdb_score.Value);

            }
            return retornar;
        }

    }
}
