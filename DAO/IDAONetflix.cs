using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___Act01Netflix.DAO
{
    public interface IDAONetflix
    {
        int SelectByGenre(String genre, String outputFile);
        String SelectByIndex(int index);
        String SelectById(int id);
        RawTitle[] ReadTitles(int index, int lenght);
        int PreMerge(RawTitle[] titles, String outFileName);
        List<RawTitle> LlegirTitols(int nTitols, string fitxer);
        List<RawTitle> MergeTitols(List<RawTitle> primerPart, List<RawTitle> segonaPart, string fitxer);

        List<String> RangeScore(double min, double max);

    }
}
