using CdManager.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CdManager.WpfApp.Windows
{
    /// <summary>
    /// Interaction logic for AddCdWindow.xaml
    /// </summary>
    public partial class AddCdWindow : Window
    {
        Cd newCd;
        
        
        public AddCdWindow()
        {
            InitializeComponent();
            Loaded += AddCdWindow_Loaded;
        }

        private void AddCdWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            newCd = new Cd();
            newCd.AlbumTitle = "< hier Titel eingeben>";
            grdCdFields.DataContext = newCd;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //Neue Cd in Repository hinzufügen - ohne Fehlerprüfung
            Repository.GetInstance().AddCd(newCd);
            Close();
        }
    }
}
