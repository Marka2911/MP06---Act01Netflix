using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___Act01Netflix
{
    public class Program
    {
        static string ENTRADAFN = "raw_titles.csv";
        static string FIRSTHALF = "FIRSTHALF.CSV";
        static string SECONDHALF = "SECONDHALF.CSV";
        static string MERGED = "MERGED.CSV";
        static string PATTERN = ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)";
        static void Main(string[] args)
        {
            LlegirTitols(0, FIRSTHALF);
            LlegirTitols(3000, SECONDHALF);
            MergeFiles(FIRSTHALF, SECONDHALF, MERGED);
        }
    }
}
