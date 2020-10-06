using CdManager.Model;
using CdManager.WpfApp.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CdManager.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Cd> _cds;
        
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

            btnNew.Click += BtnNew_Click;
            btnDel.Click += BtnDel_Click;
            btnEdit.Click += BtnEdit_Click;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbxCds.SelectedItem is Cd cdToEdit)
            {
                EditCdWindow editCdWindow = new EditCdWindow(cdToEdit);
                editCdWindow.ShowDialog();

                Repository rep = Repository.GetInstance();
                _cds = rep.GetAllCds();
                lbxCds.ItemsSource = _cds;
            }
            else
            {
                MessageBox.Show("Keine CD angewählt");
            }
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (lbxCds.SelectedItem is Cd cdToDelete)
            {
                Repository rep = Repository.GetInstance();
                rep.RemoveCd(cdToDelete);

                _cds = rep.GetAllCds();
                lbxCds.ItemsSource = _cds;
            }
            else
            {
                MessageBox.Show("Keine CD angewählt");
            }
        }

        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            AddCdWindow addCdWindow = new AddCdWindow();
            addCdWindow.ShowDialog();

            Repository rep = Repository.GetInstance();
            _cds = rep.GetAllCds();
            lbxCds.ItemsSource = _cds;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Repository rep = Repository.GetInstance();
            _cds = rep.GetAllCds();
            lbxCds.ItemsSource = _cds;
        }
    }
}
