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
    /// Interaction logic for EditCdWindow.xaml
    /// </summary>
    public partial class EditCdWindow : Window
    {
        Cd _editCd;
        Cd _cd;

        public EditCdWindow(Cd cd)
        {
            InitializeComponent();
            _cd = cd;
            Loaded += EditCdWindow_Loaded;
        }

        private void EditCdWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            _editCd = new Cd();
            _editCd.AlbumTitle = _cd.AlbumTitle;
            _editCd.Artist = _cd.Artist;

            grdCdFields.DataContext = _editCd;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            //Änderungen übernehmen
            _cd.Artist = _editCd.Artist;
            _cd.AlbumTitle = _editCd.AlbumTitle;

            Close();
        }
    }
}
