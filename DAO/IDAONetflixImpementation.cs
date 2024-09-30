using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using _02___Act01Netflix.Model;

namespace _02___Act01Netflix.DAO
{
    public class IDAONetflixImpementation : IDAONetflix
    {
        public static string ENTRADAFN = "raw_titles.csv";
        public static string PATTERN = ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)";
        public static string MERGED = "MERGED.CSV";

        public int SelectByGenre(string genre, string outputFile)
        {
            StreamReader sr = new StreamReader(ENTRADAFN);
            StreamWriter sw = new StreamWriter(outputFile + ".txt");
            string linea = sr.ReadLine();
            string[] camps = linea.Split(',');
            sw.WriteLine($"{camps[0].ToUpper()}, {camps[1].ToUpper()}, {camps[2].ToUpper()}, {camps[7].ToUpper()}");
            linea = sr.ReadLine();
            int count = 0;
            while ( linea != null)
            {
                camps = Regex.Split(linea , PATTERN);
                if (camps[7].Contains(genre))
                {
                    sw.WriteLine($"{camps[0].ToUpper()}, {camps[1].ToUpper()}, {camps[2].ToUpper()}, {camps[7].ToUpper()}");
                    count++;    
                }
                linea = sr.ReadLine();
            }
            sw.Close();
            sr.Close();
            return count;
        }

        public string SelectByIndex(int index)
        {
            StreamReader sr = new StreamReader(ENTRADAFN);
            sr.ReadLine();
            string record = "";
            string linea = sr.ReadLine();
            bool trobat = false;
            bool pasat = false;
            while (!trobat && linea != null && !pasat) //controlar que si et passa 
            {
                string[] camps = Regex.Split(linea, PATTERN);
                int idx = Convert.ToInt32(camps[0]);
                if (idx == index)
                {
                    record = linea;
                    trobat = true;
                }
                else if (index < idx)
                {
                    pasat = true;
                }
                linea = sr.ReadLine();
            }
            if (!trobat)
                record = null;
            sr.Close();
            return record;
        }
        public string SelectById(string id)
        {
            StreamReader sr = new StreamReader(ENTRADAFN);
            sr.ReadLine();
            string record = "";
            string val = "";
            string linea = sr.ReadLine();
            bool trobat = false;
            //string idCsv = "";
            //for (int i = 2; i < id.Length; i++)
            //{
            //    idCsv += id[i];
            //}
            while (!trobat && linea != null)
            {
                string[] camps = Regex.Split(linea, PATTERN);
                val = camps[1];
                //string idCSV = camps[1];
                //for (int i = 2; i < idCSV.Length; i++)
                //{
                //    val += idCSV[i];
                //}
                //for (int i = 2; i < idCSV.Length; i++)
                //{
                //    val += idCSV[i];
                //}
                if (val == id)
                {
                    record = linea;
                    trobat = true;
                }
                linea = sr.ReadLine();
            }
            if (!trobat)
                record = null;
            sr.Close();
            return record;
        }

        public RawTitle[] ReadTitles(int index, int lenght)
        {
            StreamReader sr = new StreamReader(ENTRADAFN);
            RawTitle[] rawTitles = new RawTitle[lenght];
            int j = 0;
            string linea = sr.ReadLine();
            for (int i = 0; i <= index; i++)
            {
                linea = sr.ReadLine();
            }
            int totalLength = lenght + index;
            while (index < totalLength && linea != null)
            {
                int idx = 0 ; string id = ""; string csvTitle = ""; string type = ""; int release = 0; double score = 0.0; double votes = 0.0;
                string[] camps = Regex.Split(linea, PATTERN);

                int intSeasons = 0;
                double seasons;
                if (camps[9] != "")
                {
                    seasons = Convert.ToDouble(camps[9]);
                    intSeasons = Convert.ToInt32(seasons);
                }
                if (camps[0] != "")
                    idx = Convert.ToInt32(camps[0]);
                if (camps[1] != "")
                    id = camps[1];
                if (camps[2] != "")
                    csvTitle = camps[2];
                if (camps[3] != "")
                    type = camps[3];
                if (camps[4] != "")
                    release = Convert.ToInt32(camps[4]);
                if (camps[11] != "")
                    score = Convert.ToDouble(camps[11]);
                if (camps[12] != "")
                    votes = Convert.ToDouble(camps[12]);
                RawTitle title = new RawTitle(idx, id, csvTitle, type, release, intSeasons, score, votes);
                
                index++;
                rawTitles[j] = title;
                j++;
                linea = sr.ReadLine();
            }
            sr.Close();
            return rawTitles;

        }

        public int PreMerge(RawTitle[] titles, string outFileName)
        {
            StreamWriter sw = new StreamWriter(outFileName + ".csv");
            foreach (RawTitle rawTitle in titles)
            {
                if (rawTitle != null)
                {
                    sw.WriteLine(rawTitle.ToString());
                }
            }
            sw.Close();

            return titles.Length;
        }

        public List<RawTitle> LlegirTitols(int nTitols, string fitxer)
        {
            StreamReader sr = new StreamReader(ENTRADAFN);
            StreamWriter sw = new StreamWriter(fitxer + ".txt");

            string linea;
            int i = 0;
            List<RawTitle> rawTitles = new List<RawTitle>();
            for (i = 0; i < nTitols; i++)
                sr.ReadLine();
            sr.ReadLine();
            linea = sr.ReadLine();
            i = 0;
            while (i < nTitols + 3000 && linea != null)
            {
                int idx = 0; string id = ""; string csvTitle = ""; string type = ""; int release = 0; double score = 0.0; double votes = 0.0;
                string[] camps = Regex.Split(linea, PATTERN);

                int intSeasons = 0;
                double seasons;
                if (camps[9] != "")
                {
                    seasons = Convert.ToDouble(camps[9]);
                    intSeasons = Convert.ToInt32(seasons);
                }
                if (camps[0] != "")
                    idx = Convert.ToInt32(camps[0]);
                if (camps[1] != "")
                    id = camps[1];
                if (camps[2] != "")
                    csvTitle = camps[2];
                if (camps[3] != "")
                    type = camps[3];
                if (camps[4] != "")
                    release = Convert.ToInt32(camps[4]);
                if (camps[11] != "")
                    score = Convert.ToDouble(camps[11]);
                if (camps[12] != "")
                    votes = Convert.ToDouble(camps[12]);

                RawTitle title = new RawTitle(idx, id, csvTitle, type, release, intSeasons, score, votes);
                rawTitles.Add(title);
                linea = sr.ReadLine();
                i++;
            }
            rawTitles.Sort();
            foreach(RawTitle title in rawTitles)
            {
                sw.WriteLine(title.ToString());
            }
            sw.Close();
            sr.Close();
            return rawTitles;
        }

        public List<RawTitle> MergeTitols(List<RawTitle> primerPart, List<RawTitle> segonaPart, string fitxer)
        {
            List<RawTitle> allTitols = new List<RawTitle>();

            foreach(RawTitle title in primerPart)
                allTitols.Add(title);
            
            foreach (RawTitle title in segonaPart)
                allTitols.Add(title);

            StreamWriter sw = new StreamWriter(fitxer);
            allTitols.Sort();
            foreach (RawTitle title in allTitols) { sw.WriteLine(title.ToString()); }
            sw.Close();
            return allTitols;
            
        }

        public List<string> RangeScore(double min, double max)
        {
            
            double score = 0.0;
  
            List<string> titols = new List<string>();
            StreamReader sr = new StreamReader(MERGED);
            string linea = sr.ReadLine();
            string[] camps = linea.Split(';');

            if (camps[6] != "")
                score = Convert.ToDouble(camps[6]);

            while (score > max)
            {
                linea = sr.ReadLine();
                camps = linea.Split(';');
                if (camps[6] != "")
                    score = Convert.ToDouble(camps[6]);
                
            }
            while (score >= min)
            {
                titols.Add(camps[2]);
                linea = sr.ReadLine();
                camps = linea.Split(';');
                if (camps[6] != "")
                    score = Convert.ToDouble(camps[6]);             
            }
            return titols;
        }
    }
}
