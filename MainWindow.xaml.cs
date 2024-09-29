using _02___Act01Netflix.DAO;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _02___Act01Netflix
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string FIRSTHALF = "FIRSTHALF.CSV";
        public static string SECONDHALF = "SECONDHALF.CSV";
        public static string MERGED = "MERGED.CSV";
        private DAOFactoryNetflix factory = new DAOFactoryNetflix();
        private IDAONetflix dao = new IDAONetflixImpementation();

        private RawTitle[] titles;

        private string genere;
        private string outputFile;
        private int index;
        private string id;

        public MainWindow()
        {
            List<RawTitle> primeraPart = dao.LlegirTitols(0, FIRSTHALF);
            List<RawTitle> segonaPart = dao.LlegirTitols(3000, SECONDHALF);

            dao.MergeTitols(primeraPart, segonaPart, MERGED);
            InitializeComponent();
            
        }

        private void Genere_Click(object sender, RoutedEventArgs e)
        {
            genere = txt_genere.Text;
            outputFile = txt_outputFile.Text;

            int numRecords = dao.SelectByGenre(genere, outputFile);

            if (numRecords == 0)
                num_generes.Text = $"No hi ha el genere - {genere}";
            
            else num_generes.Text = numRecords.ToString();
        }
        private void Index_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_index.Text == "")
                {
                    throw new Exception("El input no pot ser null");
                }
                index = Convert.ToInt32(txt_index.Text);

                string record = dao.SelectByIndex(index);
                if (record == null)
                    txt_record.Text = $"No hi ha ningun record amb l'index {index}";
                else
                    txt_record.Text = record;
            }
            catch (FormatException)
            {

                txt_record.Text = "Input mal formatat torna a intentar-ho";
            }
            catch (Exception ex)
            {
                txt_record.Text = ex.Message;
            }
        }

        private void ID_Click(object sender, RoutedEventArgs e)
        {
            string val = id;
            for (int i = 2; i < txt_ID.Text.Length; i++)
            {
                val += txt_ID.Text[i];
            }

            if (val == null)
                txt_record_ID.Text = "Input mal formatat, no pot ser null o tindre 2 o menys caracters";
            else
                try
                {
                    int sId = Convert.ToInt32(val);
                    string record = dao.SelectById(sId);
                    if (record == null)
                        txt_record_ID.Text = $"No hi ha ningun record amb l'id {val}";
                    else
                        txt_record_ID.Text = record;
                }
                catch (FormatException)
                {

                    txt_record_ID.Text = "Input mal formatat torna a intentar-ho";
                }
        }

        private void btn_readTitles_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_rdTitles_index.Text == "" || txt_rdTitles_lenght.Text == "")
                {
                    throw new Exception("El input no pot ser null");
                }

                int index = Convert.ToInt32(txt_rdTitles_index.Text);
                int length = Convert.ToInt32(txt_rdTitles_lenght.Text);
                titles = dao.ReadTitles(index, length);
                txt_RawTitle.Text = $"Ha funcionat tot correctament";

            }
            catch (FormatException)
            {

                txt_RawTitle.Text = "Input mal formatat torna a intentar-ho";
            }
            catch (Exception ex)
            {
                txt_RawTitle.Text = ex.Message;
            }          
        }

        private void btn_WriteTitles_Click(object sender, RoutedEventArgs e)
        {
            int numTitles = 0;
            try
            {
                if (txt_outFileForTitles.Text == "")
                {
                    throw new Exception("El input no pot ser null");
                }

                string otutputFile = txt_outFileForTitles.Text;
                numTitles = dao.PreMerge(titles, otutputFile);
                txt_PreMerge.Text = $"Ha funcionat tot correctament... num de titlesFormatats - {numTitles}";

            }
            catch (FormatException)
            {
                txt_PreMerge.Text = "Input mal formatat torna a intentar-ho";
            }
            catch (Exception ex)
            {
                txt_PreMerge.Text = ex.Message;
            }

        }
    }
}