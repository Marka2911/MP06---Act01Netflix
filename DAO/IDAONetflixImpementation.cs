using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02___Act01Netflix.DAO
{
    public class IDAONetflixImpementation : IDAONetflix
    {
        public static string ENTRADAFN = "raw_titles.csv";
        public static string PATTERN = ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)";
        public int SelectByGenre(string genre, string outputFile)
        {
            StreamReader sr = new StreamReader(ENTRADAFN);
            StreamWriter sw = new StreamWriter(outputFile);
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
            while (!trobat && linea != null)
            {
                string[] camps = Regex.Split(linea, PATTERN);
                int idx = Convert.ToInt32(camps[0]);
                if (idx == index)
                {
                    for (int i = 0; i < camps.Length; i++)
                    {
                        if (i == camps.Length - 1)
                            record += $"{camps[i]}";
                        else
                            record += $"{camps[i]} ,";
                    }
                    trobat = true;
                }
                linea = sr.ReadLine();
            }
            if (!trobat)
                record = null;
            sr.Close();
            return record;
        }
        public string SelectById(int id)
        {
            StreamReader sr = new StreamReader(ENTRADAFN);
            sr.ReadLine();
            string record = "";
            string linea = sr.ReadLine();
            bool trobat = false;
            while (!trobat && linea != null)
            {
                string val = "";
                string[] camps = Regex.Split(linea, PATTERN);
                string idCSV = camps[1];
                for (int i = 2; i < idCSV.Length; i++)
                {
                    val += idCSV[i];
                }
                int idInInt = Convert.ToInt32(val);
                if (idInInt == id)
                {
                    for (int i = 0; i < camps.Length; i++)
                    {
                        if (i == camps.Length - 1)
                            record += $"{camps[i]}";
                        else
                            record += $"{camps[i]} ,";
                    }
                    trobat = true;
                }
                linea = sr.ReadLine();
            }
            if (!trobat)
                record = null;
            sr.Close();
            return record;
        }
    }
}
