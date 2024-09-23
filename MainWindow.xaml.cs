using _02___Act01Netflix.DAO;
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
        private DAOFactoryNetflix factory = new DAOFactoryNetflix();
        private IDAONetflix dao = new IDAONetflixImpementation();

        private string genere;
        private string outputFile;
        private int index;
        private string id;

        public MainWindow()
        {
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
            index = Convert.ToInt32(txt_index.Text);
            string record = dao.SelectByIndex(index);
            if (record == null)
                txt_record.Text = $"No hi ha ningun record amb l'index {index}";
            else
                txt_record.Text = record;
        }

        private void ID_Click(object sender, RoutedEventArgs e)
        {
            string val = id;
            for (int i = 2; i < txt_ID.Text.Length; i++)
            {
                val += txt_ID.Text[i];
            }
            int sId = Convert.ToInt32(val);
            string record = dao.SelectById(sId);
            if (record == null)
                txt_record_ID.Text = $"No hi ha ningun record amb l'index {index}";
            else
                txt_record_ID.Text = record;
        }
    }
}