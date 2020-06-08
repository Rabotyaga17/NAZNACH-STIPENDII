using Microsoft.Win32;
using Otdelenie.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace Otdelenie.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChequePage.xaml
    /// </summary>
    public partial class ChequePage : Page
    {
        public ChequePage()
        {
            InitializeComponent();

            this.Scroll.Document = ChequeBuilder.GetCheque();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveDialog = new System.Windows.Forms.SaveFileDialog
            {
                AddExtension = true,
                Filter = "(*.txt)|*.txt|Все файлы (*.*)|*.* "
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(saveDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    FlowDocument flow = new FlowDocument();
                    flow = ChequeBuilder.GetCheque();
                    TextRange textRange = new TextRange(flow.ContentStart, flow.ContentEnd);
                    textRange.Save(fs, System.Windows.DataFormats.Text);
                }
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            FlowDocument d = new FlowDocument();
            Document = d;

            System.Windows.Controls.PrintDialog printDialog = new System.Windows.Controls.PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(((IDocumentPaginatorSource)CurrentDocument.Document).DocumentPaginator, "Cheque");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NewScholarshipPage());
        }
    }
}
